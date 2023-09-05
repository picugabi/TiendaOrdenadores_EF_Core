using Microsoft.EntityFrameworkCore.Query;
using MVC_ComponentesCodeFirst.Models;

namespace MVC_ComponentesCodeFirst.Servicios.OrdenadorRepository
{
    public interface IOrdenadorRepository
    {
        public Ordenador? DameOrdenador(int id);
        public IEnumerable<Ordenador> ListaOrdenadores();
        public Ordenador AddOrdenador(Ordenador ordenador);
        public void BorrarOrdenador(int id);
        public void ActualizarOrdenador(int id, Ordenador ordenador);
        public double CalorTotal(int id);
        public double PrecioTotal(int id);
    }
}
