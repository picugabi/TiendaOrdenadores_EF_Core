using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_ComponentesCodeFirst.Models;
using MVC_ComponentesCodeFirst.Servicios.FacturaRepository;
using MVC_ComponentesCodeFirst.Servicios.PedidoRepository;

namespace MVC_ComponentesCodeFirst.Controllers
{
    public class FacturasController : Controller
    {
        private readonly IFacturaRepository _facturaRepository;
        private readonly TiendaContext _pedidoFactura;

        public FacturasController(IFacturaRepository facturaRepository,TiendaContext pedidoFactura)
        {
            _facturaRepository = facturaRepository;
            _pedidoFactura = pedidoFactura;
        }

        public ActionResult Index()
        {
            return View("Index", _facturaRepository.ListaFacturas());
        }

        // GET: Componentes/Details/5
        public ActionResult Details(int id)
        {
            return View("Details", _facturaRepository.DameFactura(id));
        }

        // GET: Componentes/Create
        public ActionResult Create()
        { 
            ViewData["Pedido"] = new SelectList(_pedidoFactura.Pedidos, "Id", "NombrePedido");
            return View();
        }
        

        // POST: Componentes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Factura factura)
        {

            if (ModelState.IsValid)
            {

                _facturaRepository.AddDFactura(factura);
                return RedirectToAction(nameof(Index));
            }
            ViewData["Pedido"] = new SelectList(_pedidoFactura.Pedidos, "Id",
                "NombrePedido",
                factura.PedidoFactura!.Select(x=>x.PedidoId));

            


            return View();
        }

        // GET: Componentes/Edit/5
        public ActionResult Edit(int? id)
        {

            ViewData["PedidoId"] = new SelectList(_pedidoFactura.Pedidos, "Id",
                "NombrePedido");
            return View(_facturaRepository.DameFactura((int)id!));
        }

        // POST: Componentes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Factura factura)
        {

            try
            { 
                _facturaRepository.ActualizarFactura(id, factura);
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View(_facturaRepository.DameFactura(id));
        }

        // POST: HomeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Factura factura)
        {
            try
            {
                var facturaBorrar = _facturaRepository.DameFactura(id);
                _facturaRepository.BorrarFactura(facturaBorrar!.Id);

                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View("index");
            }

        }
        
        public ActionResult AgregaFactura()
        {
            ViewData["FacturaId"] = new SelectList(_pedidoFactura.Facturas, "Id", "NombreFactura");
            ViewData["PedidoId"] = new SelectList(_pedidoFactura.Pedidos, "Id", "NombrePedido");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgregaFactura(PedidoFactura pedidoFactura)
        {
            if (ModelState.IsValid)
            {
                _pedidoFactura.Add(pedidoFactura);
                _pedidoFactura.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FacturaId"] = new SelectList(_pedidoFactura.Facturas, "Id", "NombreFactura", pedidoFactura.FacturaId);
            ViewData["PedidoId"] = new SelectList(_pedidoFactura.Pedidos, "Id", "NombrePedido", pedidoFactura.PedidoId);
            return View(pedidoFactura);
        }


    }
}