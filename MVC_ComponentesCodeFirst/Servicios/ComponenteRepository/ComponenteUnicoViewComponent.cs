using Microsoft.AspNetCore.Mvc;

namespace MVC_ComponentesCodeFirst.Servicios.ComponenteRepository;

public class ComponenteUnicoViewComponent : ViewComponent
{
    private readonly IComponenteRepository _componenteRepository;

    public ComponenteUnicoViewComponent(IComponenteRepository componenteRepository)
    {
        _componenteRepository= componenteRepository;
    }

    public async Task<IViewComponentResult> InvokeAsync(int id)
    {
        var  componente =_componenteRepository.DameComponente(id);
        return View("Componenteunico",componente);
    }
}