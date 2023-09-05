using System;
using System.Data;
using System.Text;
using System.Text.Json;
using Azure.Messaging.ServiceBus;
using Microsoft.AspNetCore.Components.RenderTree;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using NuGet.Protocol.Plugins;
using TiendaWebApi.Models;

namespace TiendaWebApi.Services.Componentes
{
    public class AdoComponenteRepository : IComponenteRepository
    {
        public IConfiguration Configuration;


        public AdoComponenteRepository(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public List<Componente>? ListaComponentes()
        {


            string connectionString = Configuration["ConnectionStrings:DefaultConnection"]!;

            SqlConnection connection = new SqlConnection(connectionString);
            string sql = "Select * from Componentes";
            SqlCommand command = new SqlCommand(sql, connection);
            List<Componente> listaComponentes = new List<Componente>();
            connection.Open();
            using (SqlDataReader dataReader = command.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    Componente componente = new Componente();
                    componente.Id = Convert.ToInt32(dataReader["Id"]);
                    componente.Almacenamiento = Convert.ToDouble(dataReader["Almacenamiento"]);
                    componente.Calor = Convert.ToDouble(dataReader["Calor"]);
                    componente.Cores = Convert.ToInt32(dataReader["Cores"]);
                    componente.NumeroDeSerie = Convert.ToString(dataReader["NumeroDeSerie"]);

                    if (dataReader["OrdenadorId"] == DBNull.Value)
                    {
                        componente.OrdenadorId = null;
                    }
                    else
                    {
                        componente.OrdenadorId = Convert.ToInt32(dataReader["OrdenadorId"]);
                    }

                    componente.Precio = Convert.ToDouble(dataReader["Precio"]);
                    componente.TipoComponente =
                        (EnumTipoComponente)Convert.ToInt32(
                            dataReader["TipoComponente"]);
                    listaComponentes.Add(componente);
                }

            }
            connection.Close();

            return listaComponentes;
        }


        public Componente DameComponente(int id)
        {
            Componente componente = new Componente();
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"]!;

            SqlConnection connection = new SqlConnection(connectionString);
            string sql = "Select * from Componentes WHERE Id=" + id;
            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {

                componente.Id = Convert.ToInt32(dataReader["Id"]);
                componente.Almacenamiento = Convert.ToDouble(dataReader["Almacenamiento"]);
                componente.Calor = Convert.ToDouble(dataReader["Calor"]);
                componente.Cores = Convert.ToInt32(dataReader["Cores"]);
                componente.NumeroDeSerie = Convert.ToString(dataReader["NumeroDeSerie"]);

                if (dataReader["OrdenadorId"] == DBNull.Value)
                {
                    componente.OrdenadorId = null;
                }
                else
                {
                    componente.OrdenadorId = Convert.ToInt32(dataReader["OrdenadorId"]);
                }

                componente.Precio = Convert.ToDouble(dataReader["Precio"]);
                componente.TipoComponente =
                    (EnumTipoComponente)Convert.ToInt32(
                        dataReader["TipoComponente"]);

            }
            connection.Close();
            return componente;
        }

        public async void AddComponente(Componente componente)
        {
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"]!;
            SqlConnection connection = new SqlConnection(connectionString);


            string sql = $"Insert into Componentes" +
                         $"(Almacenamiento,Calor,Cores,NumeroDeSerie,OrdenadorId,Precio,TipoComponente) Values" +
                         $"(@Almacenamiento,@Calor,@Cores,@NumeroDeSerie,@OrdenadorId,@Precio,@TipoComponente)";
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.CommandType = CommandType.Text;
                connection.Open();
                command.Parameters.AddWithValue("@Almacenamiento", componente.Almacenamiento);
                command.Parameters.AddWithValue("@Calor", componente.Calor);
                command.Parameters.AddWithValue("@Cores", componente.Cores);
                command.Parameters.AddWithValue("@NumeroDeSerie", componente.NumeroDeSerie);
                if (componente.OrdenadorId == 0 || componente.OrdenadorId == null)
                {
                    command.Parameters.AddWithValue(
                        "@OrdenadorId", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@OrdenadorId", componente.OrdenadorId);
                }
                command.Parameters.AddWithValue("@Precio", componente.Precio);
                command.Parameters.AddWithValue("@TipoComponente", (int)componente.TipoComponente);
                command.ExecuteNonQuery();
                connection.Close();

                ServiceBusClient client = new ServiceBusClient(Configuration["BusServiceComponente"]);
                var receiver = client.CreateReceiver(Configuration["QueueName"]);
                var message = receiver.ReceiveMessageAsync();
                await receiver.CompleteMessageAsync(message.Result);



            }

        }
        public void BorrarComponente(int id)
        {
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"]!;
            SqlConnection connection = new SqlConnection(connectionString);
            string sql = "DELETE FROM Componentes WHERE Id = " + id;
            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();
            if (rowsAffected == 0)
            {

                throw new Exception("No se encontró ningún registro para eliminar.");
            }
        }
        public void ActualizarComponente(int id, Componente componente)
        {

            {
                string connectionString = Configuration["ConnectionStrings:DefaultConnection"]!;
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                string updateSql = "UPDATE Componentes " +
                                   "SET Almacenamiento = @Almacenamiento, " +
                                   "Calor = @Calor, " +
                                   "NumeroDeSerie = @NumeroDeSerie, " +
                                   "Precio = @Precio, " +
                                   "TipoComponente = @TipoComponente, " +
                                   "Cores = @Cores, " +
                                   "OrdenadorId = @OrdenadorId " +
                                   "WHERE Id = " + id;
                using (SqlCommand command = new SqlCommand(updateSql, connection))
                {
                    command.Parameters.AddWithValue("@Almacenamiento", componente.Almacenamiento);
                    command.Parameters.AddWithValue("@Calor", componente.Calor);
                    command.Parameters.AddWithValue("@NumeroDeSerie", componente.NumeroDeSerie);
                    command.Parameters.AddWithValue("@Precio", componente.Precio);
                    command.Parameters.AddWithValue("@TipoComponente", (int)componente.TipoComponente);
                    command.Parameters.AddWithValue("@Cores", componente.Cores);
                    if (componente.OrdenadorId == 0 || componente.OrdenadorId == null)
                    {
                        command.Parameters.AddWithValue(
                            "@OrdenadorId", DBNull.Value);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@OrdenadorId", componente.OrdenadorId);
                    }

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected == 0)
                    {
                        throw new Exception("No se encontró ningún registro para actualizar.");
                    }
                }
                connection.Close();
            }
        }
    }
}
