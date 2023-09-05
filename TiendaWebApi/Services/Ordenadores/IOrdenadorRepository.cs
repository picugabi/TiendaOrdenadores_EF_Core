using Microsoft.EntityFrameworkCore.Query;
using TiendaWebApi.Models;

namespace TiendaWebApi.Services.Ordenadores
{
    public interface IOrdenadorRepository
    {
        public Ordenador? DameOrdenador(int id);
        public IEnumerable<Ordenador>? ListaOrdenadores();
        public void AddOrdenador(Ordenador ordenador);
        public void BorrarOrdenador(int id);
        public void ActualizarOrdenador(int id, Ordenador ordenador);
        public double CalorTotal(int id);
        public double PrecioTotal(int id);
    }
}
