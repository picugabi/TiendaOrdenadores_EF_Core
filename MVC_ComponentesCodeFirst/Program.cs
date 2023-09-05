using System.Runtime.InteropServices.ComTypes;
using System.Security.Policy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MVC_ComponentesCodeFirst.Controllers;
using MVC_ComponentesCodeFirst.Models;
using MVC_ComponentesCodeFirst.Servicios.ComponenteRepository;
using MVC_ComponentesCodeFirst.Servicios.FacturaRepository;
using MVC_ComponentesCodeFirst.Servicios.OrdenadorRepository;
using MVC_ComponentesCodeFirst.Servicios.PedidoRepository;

namespace MVC_ComponentesCodeFirst
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddScoped<IComponenteRepository, ComponenteApiService>();
            builder.Services.AddScoped<IOrdenadorRepository, EF6OrdenadorRepository>();
            builder.Services.AddScoped<IPedidoRepository, EF6PedidosRepository>();
            builder.Services.AddScoped<IFacturaRepository, EF6FacturaRepository>();


  
            

            // Add services to the container.
            builder.Services.AddControllersWithViews();

                        builder.Services.AddEndpointsApiExplorer();

                        builder.Services.AddSwaggerGen();

                        builder.Services.AddDbContext<TiendaContext>(options =>
                            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


            builder.Services.AddHttpClient("ComponenteApi",
                config =>
                {
                    config.BaseAddress = new Uri(builder.Configuration["ServicesUrl:Componente"]);

                });



            var app = builder.Build();
            

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Componentes}/{action=Index}/{id?}");

            app.Run();
        }
    }
}