using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using MVC_ComponentesCodeFirst.Models;
using TiendaOrdenadoresA.Ordenador;

namespace MVC_ComponentesCodeFirst.Servicios.FacturaRepository
{
    public class EF6FacturaRepository : IFacturaRepository
    {
        private readonly TiendaContext _tiendaContext;

        public EF6FacturaRepository(TiendaContext tiendaContext)
        {
            _tiendaContext = tiendaContext;
        }

        public void ActualizarFactura(int id, Factura factura)
        {
            var actualizarFactura = DameFactura(id);
            actualizarFactura!.NombreFactura = factura.NombreFactura;
            actualizarFactura!.PedidoFactura = factura.PedidoFactura;
            actualizarFactura.Calor = factura.Calor;
            actualizarFactura.Precio = factura.Precio;

            _tiendaContext.SaveChanges();
        }

        public void AddDFactura(Factura factura)
        {
            _tiendaContext.Add(factura);
            _tiendaContext.SaveChangesAsync();
            
        }

        public void BorrarFactura(int id)
        {
            var borrarFactura = _tiendaContext.Facturas!.Find(id);
            _tiendaContext.Facturas.Remove(borrarFactura!);
            _tiendaContext.SaveChanges();
        }

        public double CalorTotal(int id)
        {

            var factura = _tiendaContext.Facturas!.Find(id);
            if (factura != null)
            {
                factura.Calor = factura.PedidoFactura!.Sum(x => x.Pedido!.Calor);

            }
            return factura!.Calor;
        }

        public Factura? DameFactura(int id)
        {
            var factura = _tiendaContext.Facturas!
                .Include(pf => pf.PedidoFactura)!
                .ThenInclude(p => p.Pedido)!
                .ThenInclude(o => o!.OrdenadoresAgregados)!
                .ThenInclude(c => c.ComponentesAgregados)!
                .FirstOrDefault(o => o.Id == id);
            if (factura != null && factura.PedidoFactura != null)
            {
                factura.Calor = CalorTotal(id);
                factura.Precio = PrecioTotal(id);
                _tiendaContext.SaveChanges();
            }
            return factura;
        }

        public IEnumerable<Factura> ListaFacturas()
        {
            var facturas = _tiendaContext.Facturas!
                .Include(pf => pf.PedidoFactura)!
                .ThenInclude(p => p.Pedido)
                .AsNoTracking()
                .ToList();
                
            foreach (var itemOrdenador in facturas)
            {
                DameFactura(itemOrdenador.Id);
            }
            return facturas;
        }

        public double PrecioTotal(int id)
        {
            var factura = _tiendaContext.Facturas!.Find(id);
            if (factura != null)
            {
                foreach (var item in factura.PedidoFactura!)
                {
                    factura.Precio = factura.PedidoFactura!.Sum(x => x.Pedido!.Precio);
                }

            }
            return factura!.Precio;
        }
    }
}
