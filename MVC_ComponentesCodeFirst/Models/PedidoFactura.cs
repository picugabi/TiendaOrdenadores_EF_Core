namespace MVC_ComponentesCodeFirst.Models
{
    public class PedidoFactura
    {
        public int PedidoId { get; set; }
        public int FacturaId { get; set; }
        public Factura? Factura { get; set; }
        public Pedido? Pedido { get; set; }

        
    }
}
