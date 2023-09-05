using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_ComponentesCodeFirst.Migrations;
using MVC_ComponentesCodeFirst.Models;
using MVC_ComponentesCodeFirst.Servicios.OrdenadorRepository;
using MVC_ComponentesCodeFirst.Servicios.PedidoRepository;

namespace MVC_ComponentesCodeFirst.Controllers
{
    public class PedidosController : Controller
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidosController(IPedidoRepository pedidoRepository,TiendaContext ordenadores )
        {
            _pedidoRepository = pedidoRepository;
        }

        
        public ActionResult Index()
        {
            return View("Index", _pedidoRepository.ListaPedidos());
        }

        // GET: Componentes/Details/5
        public ActionResult Details(int id)
        {
            return View("Details", _pedidoRepository.DamePedido(id));
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
        public ActionResult Create(Pedido pedido)
        {
            
            if(ModelState.IsValid)
            {
                _pedidoRepository.AddPedido(pedido);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: Componentes/Edit/5
        public ActionResult Edit(int? id)
        {
            return View(_pedidoRepository.DamePedido((int)id!));
        }

        // POST: Componentes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,  Pedido pedido)
        {

            try
            {

                _pedidoRepository.ActualizarPedido(id,pedido);

                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();
            }
        }
        public ActionResult Delete(int id)
        {
            return View(_pedidoRepository.DamePedido(id));
        }

        // POST: HomeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Pedido pedido)
        {
            try
            {
                _pedidoRepository.BorrarPedido(pedido.Id);

                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View("index");
            }
        }
    }
}