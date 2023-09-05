using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_ComponentesCodeFirst.Models;
using MVC_ComponentesCodeFirst.Servicios.ComponenteRepository;
using MVC_ComponentesCodeFirst.Servicios.OrdenadorRepository;
using NuGet.Packaging;
using TiendaOrdenadoresA.Comportamientos;

namespace MVC_ComponentesCodeFirst.Controllers
{
    public class OrdenadoresController : Controller
    {
        private readonly IOrdenadorRepository _ordenadorRepository;


        public OrdenadoresController(IOrdenadorRepository context)
        {
            _ordenadorRepository = context;
            
        }

        // GET: Componentes
        public ActionResult Index()
        {
            return View("Index", _ordenadorRepository.ListaOrdenadores());
        }

        // GET: Componentes/Details/5
        public ActionResult Details(int id)
        {

            return View("Details", _ordenadorRepository.DameOrdenador(id));
        }


        // GET: Componentes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Componentes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  ActionResult Create(Ordenador ordenador)
        {
            
            if (ModelState.IsValid)
            {
                
                _ordenadorRepository.AddOrdenador(ordenador);
                return RedirectToAction(nameof(Index));
            }
            return View(ordenador);
        }

        // GET: Componentes/Edit/5
        public ActionResult Edit(int? id)
        {
            return View(_ordenadorRepository.DameOrdenador((int)id!));
        }

        // POST: Componentes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Ordenador ordenador)
        {

            try
            {
                _ordenadorRepository.ActualizarOrdenador(id,ordenador);

                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();
            }
        }
        public ActionResult Delete(int id)
        {
            return View(_ordenadorRepository.DameOrdenador(id));
        }

        // POST: HomeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Ordenador ordenador)
        {
            try
            {
                var ordenador1 = _ordenadorRepository.DameOrdenador(id);
                _ordenadorRepository.BorrarOrdenador(ordenador1!.Id);

                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View("index");
            }
        }
    }
}
