using Microsoft.AspNetCore.Mvc;
using TiendaWebApi.Models;
using TiendaWebApi.Services.Ordenadores;

namespace TiendaWebApi.Controllers
{
    [Route("api/ordenadores")]
    [ApiController]
    public class OrdenadoresController : ControllerBase
    {
        private readonly IOrdenadorRepository _adoOrdenadorRepository;

        public OrdenadoresController(IOrdenadorRepository adoOrdenadorRepository)
        {
            _adoOrdenadorRepository = adoOrdenadorRepository;
        }

        //GET: api/Componentes
       [HttpGet]
        public ActionResult<IEnumerable<Ordenador>> GetOrdenadores()
        {
            if (_adoOrdenadorRepository.ListaOrdenadores() == null)
            {
                return NotFound();
            }
            return _adoOrdenadorRepository.ListaOrdenadores()!.ToList()!;
        }

        // GET: api/Componentes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ordenador>> GetComponente(int id)
        {
            if (_adoOrdenadorRepository == null)
            {
                return NotFound();
            }
            var componente = _adoOrdenadorRepository.DameOrdenador(id);

            if (componente == null)
            {
                return NotFound();
            }

            return componente;
        }

        //// PUT: api/Componentes/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComponente(int id, Ordenador ordenador)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            _adoOrdenadorRepository.ActualizarOrdenador(id, ordenador);
            return NoContent();
        }

        // POST: api/Componentes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ordenador>> PostComponente(Ordenador ordenador)
        {
            if (_adoOrdenadorRepository == null)
            {
                return Problem("Entity set 'Componentes'  is null.");
            }
            _adoOrdenadorRepository.AddOrdenador(ordenador);

            return CreatedAtAction("GetComponente", new { id = ordenador.Id }, ordenador);
        }

        //// DELETE: api/Componentes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComponente(int id)
        {
            if (_adoOrdenadorRepository == null)
            {
                return NotFound();
            }
            var componente = _adoOrdenadorRepository.DameOrdenador(id);
            if (componente == null)
            {
                return NotFound();
            }

            _adoOrdenadorRepository.BorrarOrdenador(id);

            return NoContent();
        }

    }

}
