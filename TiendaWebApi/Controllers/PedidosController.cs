using Microsoft.AspNetCore.Mvc;
using TiendaWebApi.Services.PedidoRepository;
using TiendaWebApi.Models;

namespace TiendaWebApi.Controllers
{
    [Route("api/pedidos")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidoRepository _adoPedidoRepository;

        public PedidosController(IPedidoRepository adoOrdenadorRepository)
        {
            _adoPedidoRepository = adoOrdenadorRepository;
        }

        //GET: api/Componentes
        [HttpGet]
        public ActionResult<IEnumerable<Pedido>> GetPedidos()
        {
            if (_adoPedidoRepository.ListaPedidos() == null)
            {
                return NotFound();
            }
            return _adoPedidoRepository.ListaPedidos()!.ToList()!;
        }

        // GET: api/Componentes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pedido>> GetPedido(int id)
        {
            if (_adoPedidoRepository == null)
            {
                return NotFound();
            }
            var componente = _adoPedidoRepository.DamePedido(id);

            if (componente == null)
            {
                return NotFound();
            }

            return componente;
        }

        //// PUT: api/Componentes/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPedido(int id, Pedido pedido)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            _adoPedidoRepository.ActualizarPedido(id, pedido);
            return NoContent();
        }

        // POST: api/Componentes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ordenador>> PostPedido(Pedido pedido)
        {
            if (_adoPedidoRepository == null)
            {
                return Problem("Entity set 'Componentes'  is null.");
            }
            _adoPedidoRepository.AddPedido(pedido);

            return CreatedAtAction("GetComponente", new { id = pedido.Id }, pedido);
        }

        //// DELETE: api/Componentes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePedido(int id)
        {
            if (_adoPedidoRepository == null)
            {
                return NotFound();
            }
            var componente = _adoPedidoRepository.DamePedido(id);
            if (componente == null)
            {
                return NotFound();
            }

            _adoPedidoRepository.BorrarPedido(id);

            return NoContent();
        }

    }

}
