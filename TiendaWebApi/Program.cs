
using Microsoft.EntityFrameworkCore;
using TiendaWebApi.Controllers;
using TiendaWebApi.Models;
using TiendaWebApi.Services;
using TiendaWebApi.Services.Componentes;
using TiendaWebApi.Services.FacturaRepository;
using TiendaWebApi.Services.Ordenadores;
using TiendaWebApi.Services.OrdenadorRepository;
using TiendaWebApi.Services.PedidoRepository;

namespace TiendaWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddScoped<IComponenteRepository, AdoComponenteRepository>();
            //builder.Services.AddSingleton<IOrdenadorRepository, FakeOrdenadorRepository>();
            //builder.Services.AddSingleton<IPedidoRepository, FakePedidoRepository>();
            //builder.Services.AddSingleton<IFacturaRepository, FakeFacturaRepository>();
            
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}