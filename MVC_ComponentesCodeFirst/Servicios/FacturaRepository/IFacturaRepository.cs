using MVC_ComponentesCodeFirst.Models;

namespace MVC_ComponentesCodeFirst.Servicios.FacturaRepository
{
    public interface IFacturaRepository
    {
        public Factura? DameFactura(int id);
        public IEnumerable<Factura> ListaFacturas();
        public Factura AddDFactura(Factura factura);
        public void BorrarFactura(int id);
        public void ActualizarFactura(int id, Factura factura);
        public double CalorTotal(int id);
        public double PrecioTotal(int id);
    }
}
