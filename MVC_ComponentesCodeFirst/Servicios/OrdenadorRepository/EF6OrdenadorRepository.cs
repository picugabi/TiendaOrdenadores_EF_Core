using System.Diagnostics.CodeAnalysis;
using MessagePack.Resolvers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.IdentityModel.Tokens;
using MVC_ComponentesCodeFirst.Data;
using MVC_ComponentesCodeFirst.Models;
using NuGet.Protocol;
using TiendaOrdenadoresA.Ordenador.Validador;

namespace MVC_ComponentesCodeFirst.Servicios.OrdenadorRepository
{
    public class EF6OrdenadorRepository : IOrdenadorRepository
    {
        private readonly TiendaContext _tiendaContext;

        
        public EF6OrdenadorRepository(TiendaContext tiendaContext)
        {
            _tiendaContext = tiendaContext;

            DbInitializerOrdenador.Initialize(_tiendaContext);



        }

        public IEnumerable<Ordenador> ListaOrdenadores()
        {
            var ordenadores = _tiendaContext.Ordenadores!
                .Include(c=>c.ComponentesAgregados)
                .AsNoTracking()
                .ToList();
            foreach (var itemOrdenador in ordenadores)
            {
                DameOrdenador(itemOrdenador.Id);
            }
            return ordenadores;

        }
        
        public void AddOrdenador(Ordenador ordenador)
        {
            _tiendaContext.Add(ordenador);
            _tiendaContext.SaveChanges();
            
        }


        public void BorrarOrdenador(int id)
        {
            var borrarOrdenador = _tiendaContext.Ordenadores!.Find(id);
            _tiendaContext.Ordenadores.Remove(borrarOrdenador!);
            _tiendaContext.SaveChanges();
        }

        public void ActualizarOrdenador(int id, Ordenador ordenador)
        {
            var actualizarOrdenador = _tiendaContext.Ordenadores!.Find(id);
            actualizarOrdenador!.NombreOrdenador = ordenador.NombreOrdenador;
            actualizarOrdenador!.ComponentesAgregados = ordenador.ComponentesAgregados;
            actualizarOrdenador.Calor = ordenador.Calor;
            actualizarOrdenador.Precio = ordenador.Precio;
            actualizarOrdenador.PedidoId = ordenador.PedidoId;
            _tiendaContext.SaveChanges();
        }

        
        public Ordenador? DameOrdenador(int id)
        {
            var ordenador = _tiendaContext.Ordenadores!
                .Include(o => o.ComponentesAgregados)
                .FirstOrDefault(o => o.Id == id);
            if (ordenador != null)
            {
                ordenador.Calor = CalorTotal(id);
                ordenador.Precio = PrecioTotal(id);
                _tiendaContext.SaveChanges();
            }
            return ordenador;
        }

        public double CalorTotal(int id)
        {

            var ordenador = _tiendaContext.Ordenadores!.Find(id);
            if (ordenador != null)
            {
                ordenador.Calor = ordenador.ComponentesAgregados!.Sum(x => x.Calor);

            }
            return ordenador!.Calor;
        }

        public double PrecioTotal(int id)
        {
            var ordenador = _tiendaContext.Ordenadores!.Find(id);
            if (ordenador != null)
            {
                ordenador.Precio = ordenador.ComponentesAgregados!.Sum(x => x.Precio);

            }
            return ordenador!.Precio;
        }


    }
}
