using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_ComponentesCodeFirst.Data;
using MVC_ComponentesCodeFirst.Models;
using TiendaOrdenadoresA.Ordenador;

namespace MVC_ComponentesCodeFirst.Servicios.PedidoRepository
{
    public class EF6PedidosRepository : IPedidoRepository
    {
        private readonly TiendaContext _tiendaContext;

        public EF6PedidosRepository(TiendaContext tiendaContext)
        {
            _tiendaContext = tiendaContext;

        }
        public Pedido? DamePedido(int id)
        {

            var pedido = _tiendaContext.Pedidos!
                .Include(o => o.OrdenadoresAgregados)!
                .ThenInclude(c => c.ComponentesAgregados)!
                .FirstOrDefault(o => o.Id == id);
            if (pedido != null)
            {
                pedido.Calor = CalorTotal(id);
                pedido.Precio = PrecioTotal(id);
                _tiendaContext.SaveChanges();
            }
            return pedido;
        }

        public IEnumerable<Pedido> ListaPedidos()
        {

            var pedidos = _tiendaContext.Pedidos!
                .Include(x => x.OrdenadoresAgregados!)
                .ThenInclude(c => c.ComponentesAgregados)
                .AsNoTracking()
                .ToList();
            foreach (var itemPedido in pedidos!)
            {
                DamePedido(itemPedido.Id);
            }
            return pedidos;


        }

        public Pedido AddPedido(Pedido pedido)
        {
            
            _tiendaContext.Add(pedido);
            _tiendaContext.SaveChanges();
            return pedido;

        }

        public void BorrarPedido(int id)
        {
            var borrarPedido = _tiendaContext.Pedidos!.Find(id);
            _tiendaContext.Pedidos.Remove(borrarPedido!);
            _tiendaContext.SaveChanges();
        }

        public void ActualizarPedido(int id, Pedido pedido)
        {
            var actualizarPedido = DamePedido(id);
            
            actualizarPedido!.NombrePedido = pedido.NombrePedido;
            actualizarPedido!.OrdenadoresAgregados = pedido.OrdenadoresAgregados;
            actualizarPedido.Calor = pedido.Calor;
            actualizarPedido.Precio = pedido.Precio;
            _tiendaContext.SaveChanges();
        }

        public double CalorTotal(int id)
        {

            var pedido = _tiendaContext.Pedidos!.Find(id);
            if (pedido != null)
            {
                pedido.Calor = pedido.OrdenadoresAgregados!.Sum(x => x.Calor);

            }
            return pedido!.Calor;
        }

        public double PrecioTotal(int id)
        {

            var pedido = _tiendaContext.Pedidos!.Find(id);
            if (pedido != null)
            {
                pedido.Precio = pedido.OrdenadoresAgregados!.Sum(x => x.Precio);

            }

            return pedido!.Precio;
        }
    }
}
