using MVC_ComponentesCodeFirst.Models;

namespace MVC_ComponentesCodeFirst.Servicios.PedidoRepository
{
    public interface IPedidoRepository
    {
        public Pedido? DamePedido(int id);
        public IEnumerable<Pedido> ListaPedidos();
        public Pedido AddPedido(Pedido pedido);
        public void BorrarPedido(int id);
        public void ActualizarPedido(int id, Pedido pedido);
        public double CalorTotal(int id);
        public double PrecioTotal(int id);

    }
}
