using Microsoft.AspNetCore.Mvc;

namespace MVC_ComponentesCodeFirst.Servicios.ComponenteRepository;

public class ComponenteListaViewComponent :ViewComponent
{
    private readonly IComponenteRepository _componenteRepository;

    public ComponenteListaViewComponent(IComponenteRepository componenteRepository )
    {
        _componenteRepository= componenteRepository;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var listaComponentes = _componenteRepository.ListaComponentes();
        return View("ComponenteLista",listaComponentes);
    }
}