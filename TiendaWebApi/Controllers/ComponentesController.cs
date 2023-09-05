using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TiendaWebApi.Services;
using NuGet.Protocol;
using TiendaWebApi.Models;
using TiendaWebApi.Services.Componentes;

namespace TiendaWebApi.Controllers
{
    [Route("api/componentes")]
    [ApiController]
    public class ComponentesController : ControllerBase
    {
        private readonly  IComponenteRepository _adoComponenteRepository;

        public ComponentesController(IComponenteRepository adoComponenteRepository)
        {
            _adoComponenteRepository = adoComponenteRepository;
        }

        // GET: api/Componentes
        [HttpGet]
        public  ActionResult<IEnumerable<Componente>> GetComponentes()
        {
          if (_adoComponenteRepository.ListaComponentes() == null)
          {
              return NotFound();
          }
          return _adoComponenteRepository.ListaComponentes()!;
        }

        // GET: api/Componentes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Componente>> GetComponente(int id)
        {
            if (_adoComponenteRepository == null)
            {
                return NotFound();
            }
            var componente = _adoComponenteRepository.DameComponente(id);

            if (componente == null)
            {
                return NotFound();
            }

            return componente;
        }

        //// PUT: api/Componentes/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComponente(int id, Componente componente)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            _adoComponenteRepository.ActualizarComponente(id,componente);
            return NoContent();
        }

        // POST: api/Componentes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Componente>> PostComponente(Componente componente)
        {
            if (_adoComponenteRepository == null)
            {
                return Problem("Entity set 'Componentes'  is null.");
            }
            _adoComponenteRepository.AddComponente(componente);

            return CreatedAtAction("GetComponente", new { id = componente.Id }, componente);
        }

        //// DELETE: api/Componentes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComponente(int id)
        {
            if (_adoComponenteRepository == null)
            {
                return NotFound();
            }
            var componente = _adoComponenteRepository.DameComponente(id);
            if (componente == null)
            {
                return NotFound();
            }

            _adoComponenteRepository.BorrarComponente(id);

            return NoContent();
        }

    }

    
}
