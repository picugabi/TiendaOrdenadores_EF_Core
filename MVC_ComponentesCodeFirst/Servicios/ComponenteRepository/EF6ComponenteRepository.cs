using Microsoft.EntityFrameworkCore;
using MVC_ComponentesCodeFirst.Data;
using MVC_ComponentesCodeFirst.Models;

namespace MVC_ComponentesCodeFirst.Servicios.ComponenteRepository;

public class EF6ComponenteRepository : IComponenteRepository
{
    private readonly TiendaContext _tiendaContext;

    public EF6ComponenteRepository(TiendaContext tiendaContext)
    {
        _tiendaContext = tiendaContext;
        DbInitializerComponente.Initialize(_tiendaContext);
    }

    public Componente? DameComponente(int id)
    {
        if (_tiendaContext.Componentes is not null)
        {
            var componente = _tiendaContext.Componentes.Find(id);
            return componente;
        }
        return null;
    }

    public void AddComponente(Componente componente)
    {
        if (_tiendaContext.Componentes == null) return;
        _tiendaContext.Componentes.Add(componente);
        _tiendaContext.SaveChanges();

    }

    public void BorrarComponente(int id)
    {
        if (_tiendaContext.Componentes != null)
        {
            var borrarComponente = _tiendaContext.Componentes.Find(id);
            if (borrarComponente != null)
            {
                _tiendaContext.Componentes.Remove(borrarComponente);
                _tiendaContext.SaveChanges();
            }
        }
    }

    public List<Componente>? ListaComponentes()
    {
        if (_tiendaContext.Componentes is not null)
        {
            return _tiendaContext.Componentes.AsNoTracking().ToList();
        }
        return null;
    }

    public void ActualizarComponente(int id, Componente componente)
    {
        var componenteEdit = _tiendaContext.Componentes!.Find(id);
        componenteEdit!.TipoComponente = componente.TipoComponente;
        componenteEdit!.NumeroDeSerie = componente.NumeroDeSerie;
        componenteEdit!.Precio = componente.Precio;
        componenteEdit!.Almacenamiento = componente.Almacenamiento;
        componenteEdit!.Calor = componente.Calor;
        componenteEdit!.Cores = componente.Cores;
        componenteEdit!.OrdenadorId = componente.OrdenadorId;
        _tiendaContext.SaveChanges();


    }

}