using System.Collections;
using System.Data;
using System.Runtime.InteropServices;
using Humanizer;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Data.SqlClient;
using NuGet.Packaging;
using NuGet.Protocol;
using TiendaWebApi.Models;

namespace TiendaWebApi.Services.Ordenadores
{
    public class ADOOrdenadorRepository : IOrdenadorRepository
    {
        public IConfiguration Configuration;

        public ADOOrdenadorRepository(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public Ordenador? DameOrdenador(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ordenador>? ListaOrdenadores()
        {
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"]!;


            SqlConnection connection = new SqlConnection(connectionString);
            string sql = "Select o.Id,o.NombreOrdenador,o.PedidoId,c.Almacenamiento,c.Calor," +
                "c.Cores,c.NumeroDeSerie,c.OrdenadorId,c.Precio,c.TipoComponente From" +
                " Ordenadores as o left join Componentes as c on c.OrdenadorId = o.Id";

            SqlCommand command = new SqlCommand(sql, connection);
            List<Ordenador> listaOrdenadores = new List<Ordenador>();
            List<Componente> componentes = new List<Componente>();
            connection.Open();
            using (SqlDataReader dataReader = command.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    Ordenador ordenador = new Ordenador();

                    ordenador.Id = Convert.ToInt32(dataReader["Id"]);
                    ordenador.NombreOrdenador = Convert.ToString(dataReader["NombreOrdenador"]);
                    Componente componente = new Componente();
                    componente.Almacenamiento = dataReader.IsDBNull("Almacenamiento") ? 0 : Convert.ToDouble(dataReader["Almacenamiento"]);
                    componente.Calor = dataReader.IsDBNull("Calor") ? 0 : Convert.ToDouble(dataReader["Calor"]);
                    componente.Cores = dataReader.IsDBNull("Cores") ? 0 : Convert.ToInt32(dataReader["Cores"]);
                    componente.NumeroDeSerie = dataReader.IsDBNull("NumeroDeSerie") ? null : Convert.ToString(dataReader["NumeroDeSerie"]);
                    componente.OrdenadorId = dataReader.IsDBNull("OrdenadorId") ? componente.OrdenadorId : Convert.ToInt32(dataReader["OrdenadorId"]);
                    componente.Precio = dataReader.IsDBNull("Precio") ? 0 : Convert.ToInt32(dataReader["Precio"]);
                    componente.TipoComponente = dataReader.IsDBNull("TipoComponente") ? componente.TipoComponente : (EnumTipoComponente)Convert.ToInt32(dataReader["TipoComponente"]);
                    componentes.Add(componente);


                    ordenador.ComponentesAgregados = new List<Componente>();
                    ordenador.ComponentesAgregados!.AddRange(componentes.Where(x => x.OrdenadorId == ordenador.Id));


                    //ordenador.Calor = CalorTotal(ordenador.Id);
                    //ordenador.Precio = PrecioTotal(ordenador.Id);

                    //if (dataReader["PedidoId"] == DBNull.Value)
                    //{
                    //    ordenador.PedidoId = null;
                    //}
                    //else
                    //{
                    //    ordenador.PedidoId = Convert.ToInt32(dataReader["PedidoId"]);
                    //}
                    listaOrdenadores.Add(ordenador);



                }
                listaOrdenadores.ForEach(x =>
                {
                });

            }
            connection.Close();

            return listaOrdenadores;
        }

        public void AddOrdenador(Ordenador ordenador)
        {
            throw new NotImplementedException();
        }

        public void BorrarOrdenador(int id)
        {
            throw new NotImplementedException();
        }

        public void ActualizarOrdenador(int id, Ordenador ordenador)
        {
            throw new NotImplementedException();
        }

        public double CalorTotal(int id)
        {
            double calorTotal = 0;
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"]!;

            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select Componentes.Calor from Componentes where Componentes.OrdenadorId =" + id;
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            using (SqlDataReader dataReader = command.ExecuteReader())
            {
                var nuevo = Convert.ToDouble(dataReader["Componentes.Calor"]);
                calorTotal += nuevo;
            }
            connection.Close();
            return calorTotal;
        }

        public double PrecioTotal(int id)
        {
            double calorTotal = 0;
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"]!;

            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select Componentes.Calor from Componentes where Componentes.OrdenadorId =" + id;
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            using (SqlDataReader dataReader = command.ExecuteReader())
            {
                calorTotal += Convert.ToDouble(dataReader["Precio"]);
            }
            connection.Close();
            return calorTotal;
        }


    }

}
