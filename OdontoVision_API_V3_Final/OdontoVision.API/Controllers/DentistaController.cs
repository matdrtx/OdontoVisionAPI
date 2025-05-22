using Microsoft.AspNetCore.Mvc;
using OdontoVision.Application.Services;
using OdontoVision.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OdontoVision.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DentistaController : ControllerBase
    {
        private readonly DentistaService _dentistaService;

        public DentistaController(DentistaService dentistaService)
        {
            _dentistaService = dentistaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dentista>>> GetDentistas()
        {
            return Ok(await _dentistaService.GetAllDentistasAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Dentista>> GetDentista(int id)
        {
            var dentista = await _dentistaService.GetDentistaByIdAsync(id);
            if (dentista == null)
            {
                return NotFound();
            }
            return Ok(dentista);
        }

        [HttpPost]
        public async Task<IActionResult> AddDentista(Dentista dentista)
        {
            await _dentistaService.AddDentistaAsync(dentista);
            return CreatedAtAction(nameof(GetDentista), new { id = dentista.Id }, dentista);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDentista(int id, Dentista dentista)
        {
            if (id != dentista.Id)
            {
                return BadRequest();
            }
            await _dentistaService.UpdateDentistaAsync(dentista);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDentista(int id)
        {
            await _dentistaService.DeleteDentistaAsync(id);
            return NoContent();
        }
    }
}
