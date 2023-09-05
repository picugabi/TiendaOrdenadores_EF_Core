using MVC_ComponentesCodeFirst.Models;
using TiendaOrdenadoresA.Comportamientos;

namespace MVC_ComponentesCodeFirst.Servicios.ComponenteRepository;

public class FakeComponenteRepository : IComponenteRepository
{
    private readonly List<Componente> _componenteList = new();

    public FakeComponenteRepository()
    {
        _componenteList.Add(new Componente() { Id = 0, NumeroDeSerie = "789_XCS", Precio = 134, Almacenamiento = 0, Calor = 10, Cores = 9, TipoComponente = EnumTipoComponente.Procesador });
        _componenteList.Add(new Componente() { Id = 1, NumeroDeSerie = "879FH", Precio = 100, Almacenamiento = 512, Calor = 10, Cores = 0, TipoComponente = EnumTipoComponente.MemoriaRAM });
        _componenteList.Add(new Componente() { Id = 2, NumeroDeSerie = "789_XX_2", Precio = 90, Almacenamiento = 1000000, Calor = 29, Cores = 0, TipoComponente = EnumTipoComponente.Almacenamiento });
    }

    public Componente? DameComponente(int id)
    {
        return _componenteList.Find(x => x.Id == id);
    }

    public void AddComponente(Componente componente)
    {
        _componenteList.Add(componente);
    }

    public void BorrarComponente(int id)
    {
        _componenteList.RemoveAt(id);
    }

    public List<Componente>? ListaComponentes()
    {
        return _componenteList;
    }

    public void ActualizarComponente(int id, Componente componente)
    {
        var componenteEdit = _componenteList.Find(x => x.Id == id);
        componenteEdit!.TipoComponente = componente.TipoComponente;
        componenteEdit!.NumeroDeSerie = componente.NumeroDeSerie;
        componenteEdit!.Precio = componente.Precio;
        componenteEdit!.Almacenamiento = componente.Almacenamiento;
        componenteEdit!.Calor = componente.Calor;
        componenteEdit!.Cores = componente.Cores;
    }
}