

using System.Diagnostics.CodeAnalysis;
using MVC_ComponentesCodeFirst.Models;
using TiendaOrdenadoresA.Comportamientos;

namespace MVC_ComponentesCodeFirst.Data
{
    public static class DbInitializerComponente
    {
        
        public static void Initialize(TiendaContext context)
        {
            context.Database.EnsureCreated();

            if (context.Componentes != null && context.Componentes.Any())
            {
                return;   // DB has been seeded
            }

            var componentes = new Models.Componente[]
            {
                new Models.Componente{NumeroDeSerie = "789_XCS",Precio = 134,Almacenamiento = 0,Calor = 10,Cores = 9,TipoComponente = EnumTipoComponente.Procesador},
                new Models.Componente{NumeroDeSerie = "789_XCS",Precio = 134,Almacenamiento = 0,Calor = 10,Cores = 9,TipoComponente = EnumTipoComponente.Procesador},
                new Models.Componente{NumeroDeSerie = "789_XCD",Precio = 138,Almacenamiento = 0,Calor = 12,Cores = 10,TipoComponente = EnumTipoComponente.Procesador},
                new Models.Componente{NumeroDeSerie = "789_XCT",Precio = 138,Almacenamiento = 0,Calor = 22,Cores = 11,TipoComponente = EnumTipoComponente.Procesador},
                new Models.Componente{NumeroDeSerie = "879FH",Precio = 100,Almacenamiento = 512,Calor = 10,Cores = 0,TipoComponente = EnumTipoComponente.MemoriaRAM},
                new Models.Componente{NumeroDeSerie = "879FH",Precio = 100,Almacenamiento = 512,Calor = 10,Cores = 0,TipoComponente = EnumTipoComponente.MemoriaRAM},
                new Models.Componente{NumeroDeSerie = "879FH_L",Precio = 125,Almacenamiento = 1000,Calor = 15,Cores = 0,TipoComponente = EnumTipoComponente.MemoriaRAM},
                new Models.Componente{NumeroDeSerie = "879FH_T",Precio = 150,Almacenamiento = 2000,Calor = 24,Cores = 0,TipoComponente = EnumTipoComponente.MemoriaRAM},
                new Models.Componente{NumeroDeSerie = "879FH_T",Precio = 150,Almacenamiento = 2000,Calor = 24,Cores = 0,TipoComponente = EnumTipoComponente.MemoriaRAM},
                new Models.Componente{NumeroDeSerie = "789_XX",Precio = 50,Almacenamiento = 500000,Calor = 10,Cores = 0,TipoComponente = EnumTipoComponente.Almacenamiento},
                new Models.Componente{NumeroDeSerie = "789_XX",Precio = 50,Almacenamiento = 500000,Calor = 10,Cores = 0,TipoComponente = EnumTipoComponente.Almacenamiento},
                new Models.Componente{NumeroDeSerie = "789_XX_2",Precio = 90,Almacenamiento = 1000000,Calor = 29,Cores = 0,TipoComponente = EnumTipoComponente.Almacenamiento},
                new Models.Componente{NumeroDeSerie = "789_XX_3",Precio = 128,Almacenamiento = 2000000,Calor = 39,Cores = 0,TipoComponente = EnumTipoComponente.Almacenamiento},
                new Models.Componente{NumeroDeSerie = "789_XX_3",Precio = 128,Almacenamiento = 2000000,Calor = 39,Cores = 0,TipoComponente = EnumTipoComponente.Almacenamiento},
                new Models.Componente{NumeroDeSerie = "789_XX_3",Precio = 128,Almacenamiento = 2000000,Calor = 39,Cores = 0,TipoComponente = EnumTipoComponente.Almacenamiento},
                new Models.Componente{NumeroDeSerie = "797_X",Precio = 78,Almacenamiento = 0,Calor = 30,Cores = 10,TipoComponente = EnumTipoComponente.Procesador},
                new Models.Componente{NumeroDeSerie = "797_X2",Precio = 178,Almacenamiento = 0,Calor = 30,Cores = 29,TipoComponente = EnumTipoComponente.Procesador},
                new Models.Componente{NumeroDeSerie = "797_X3",Precio = 228,Almacenamiento = 0,Calor = 60,Cores = 34,TipoComponente = EnumTipoComponente.Procesador},
                new Models.Componente{NumeroDeSerie = "797_X3",Precio = 228,Almacenamiento = 0,Calor = 60,Cores = 34,TipoComponente = EnumTipoComponente.Procesador},
                new Models.Componente{NumeroDeSerie = "788_fg",Precio = 37,Almacenamiento = 250,Calor = 35,Cores = 0,TipoComponente = EnumTipoComponente.Almacenamiento},
                new Models.Componente{NumeroDeSerie = "788_fg",Precio = 37,Almacenamiento = 250,Calor = 35,Cores = 0,TipoComponente = EnumTipoComponente.Almacenamiento},
                new Models.Componente{NumeroDeSerie = "788_fg_2",Precio = 67,Almacenamiento = 250,Calor = 35,Cores = 0,TipoComponente = EnumTipoComponente.Almacenamiento},
                new Models.Componente{NumeroDeSerie = "788_fg_3",Precio = 97,Almacenamiento = 250,Calor = 35,Cores = 0,TipoComponente = EnumTipoComponente.Almacenamiento},
                new Models.Componente{NumeroDeSerie = "1789_XCS",Precio = 134,Almacenamiento = 9000000,Calor = 10,Cores = 0,TipoComponente = EnumTipoComponente.Almacenamiento},
                new Models.Componente{NumeroDeSerie = "1789_XCD",Precio = 138,Almacenamiento = 1000000,Calor = 12,Cores = 0,TipoComponente = EnumTipoComponente.Almacenamiento},
                new Models.Componente{NumeroDeSerie = "1789_XCT",Precio = 140,Almacenamiento = 11000000,Calor = 22,Cores = 0,TipoComponente = EnumTipoComponente.Almacenamiento}
            };
            
            context.Componentes!.AddRange(componentes);

            context.SaveChanges();
        }
    }

}
