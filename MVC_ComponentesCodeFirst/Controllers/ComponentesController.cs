using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_ComponentesCodeFirst;
using MVC_ComponentesCodeFirst.Data;
using MVC_ComponentesCodeFirst.Models;
using MVC_ComponentesCodeFirst.Servicios.ComponenteRepository;
using TiendaOrdenadoresA.Comportamientos;

namespace MVC_ComponentesCodeFirst.Controllers
{
    public class ComponentesController : Controller
    {
        private readonly IComponenteRepository _componenteRepository;
        
        public ComponentesController(IComponenteRepository componenteRepository)
        {
            _componenteRepository=componenteRepository;
        }

        // GET: Componentes
        public async Task<ActionResult> Index()
        {
            return View("Index", _componenteRepository.ListaComponentes()!);
        }

        // GET: Componentes/Details/5
        public ActionResult Details(int id)
        {
          
            return View("Details",_componenteRepository.DameComponente(id));
        }

        // GET: Componentes/Create
        public ActionResult Create()
        {
            ViewData["Tipo"] = new SelectList(Enum.GetNames(typeof(EnumTipoComponente)));
            return View();
        }

        // POST: Componentes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Componente componente)
        {
            if (ModelState.IsValid)
            {
                _componenteRepository.AddComponente(componente);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: Componentes/Edit/5
        public ActionResult Edit(int? id)
        {
            return View(_componenteRepository.DameComponente((int)id!));
        }

        // POST: Componentes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Componente componente)
        {

            try
            {
                    _componenteRepository.ActualizarComponente(id,componente); 

                    return RedirectToAction(nameof(Index));
                
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Delete(int id)
        {
            return View(_componenteRepository.DameComponente(id));
        }

        // POST: HomeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Componente componente)
        {
            try
            {
                _componenteRepository.BorrarComponente(id);

                return RedirectToAction(nameof(Index));
                
            }
            catch
            {
                return View("index");
            }
        }

    }
}
