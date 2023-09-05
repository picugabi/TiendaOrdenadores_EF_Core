using Microsoft.AspNetCore.Mvc;
using TiendaWebApi.Services.FacturaRepository;
using TiendaWebApi.Models;

namespace TiendaWebApi.Controllers
{
    [Route("api/facturas")]
    [ApiController]
    public class FacturasController : ControllerBase
    {
        private readonly IFacturaRepository _adoFacturaRepository;

        public FacturasController(IFacturaRepository adoOrdenadorRepository)
        {
            _adoFacturaRepository = adoOrdenadorRepository;
        }

        //GET: api/Componentes
        [HttpGet]
        public ActionResult<IEnumerable<Factura>> GetPedidos()
        {
            if (_adoFacturaRepository.ListaFacturas() == null)
            {
                return NotFound();
            }
            return _adoFacturaRepository.ListaFacturas()!.ToList()!;
        }

        // GET: api/Componentes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Factura>> GetPedido(int id)
        {
            if (_adoFacturaRepository == null)
            {
                return NotFound();
            }
            var componente = _adoFacturaRepository.DameFactura(id);

            if (componente == null)
            {
                return NotFound();
            }

            return componente;
        }

        //// PUT: api/Componentes/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPedido(int id, Factura pedido)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            _adoFacturaRepository.ActualizarFactura(id, pedido);
            return NoContent();
        }

        // POST: api/Componentes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ordenador>> PostPedido(Factura pedido)
        {
            if (_adoFacturaRepository == null)
            {
                return Problem("Entity set 'Componentes'  is null.");
            }
            _adoFacturaRepository.AddDFactura(pedido);

            return CreatedAtAction("GetComponente", new { id = pedido.Id }, pedido);
        }

        //// DELETE: api/Componentes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePedido(int id)
        {
            if (_adoFacturaRepository == null)
            {
                return NotFound();
            }
            var componente = _adoFacturaRepository.DameFactura(id);
            if (componente == null)
            {
                return NotFound();
            }

            _adoFacturaRepository.BorrarFactura(id);

            return NoContent();
        }

    }

}
