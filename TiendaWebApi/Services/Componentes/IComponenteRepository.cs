using TiendaWebApi.Models;

namespace TiendaWebApi.Services.Componentes;

public interface IComponenteRepository
{
    public Componente? DameComponente(int id);
    public void AddComponente(Componente componente);
    public void BorrarComponente(int id);
    public List<Componente>? ListaComponentes();
    public void ActualizarComponente(int id, Componente componente);
}