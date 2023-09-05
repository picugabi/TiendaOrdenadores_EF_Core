using MVC_ComponentesCodeFirst.Models;
using System.Drawing;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore.Internal;
using MVC_ComponentesCodeFirst.Data;
using NuGet.Versioning;
using TiendaOrdenadoresA.Comportamientos;

namespace MVC_ComponentesCodeFirst.Data
{
    public static class DbInitializerOrdenador
    {
        public static void Initialize(TiendaContext context)
        {
            context.Database.EnsureCreated();

            if (context.Ordenadores != null && context.Ordenadores.Any())
            {
                return; // DB has been seeded
            }
            
            

            
            

            var ordenadores = new Ordenador[]
            {
                new Ordenador()
                {
                    NombreOrdenador = "OrdenadorMaria",
                    ComponentesAgregados =  new[]
                    {

                        context.Componentes!.FirstOrDefault(x=>x.NumeroDeSerie == "789_XCS".ToUpper()),
                        context.Componentes!.FirstOrDefault(x=>x.NumeroDeSerie == "789_Xx".ToUpper()),
                        context.Componentes!.FirstOrDefault(x=>x.NumeroDeSerie == "879fh".ToUpper())
                    }!

                },
                new Ordenador()
                {
                    NombreOrdenador = "OrdenadorAndres",
                    ComponentesAgregados =  new[]
                    {
                        context.Componentes!.FirstOrDefault(x=>x.NumeroDeSerie == "879fh_t".ToUpper()),
                        context.Componentes!.FirstOrDefault(x=>x.NumeroDeSerie == "789_xx_3".ToUpper()),
                        context.Componentes!.FirstOrDefault(x=>x.NumeroDeSerie == "797_x3".ToUpper()),
                    }!
                },

            };
                
            context.Ordenadores!.AddRange(ordenadores);
            context.SaveChanges();
        }
    }
}
