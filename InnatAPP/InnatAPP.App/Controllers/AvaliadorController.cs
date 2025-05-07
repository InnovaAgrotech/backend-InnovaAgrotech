using InnatAPP.Application.DTOs;
using InnatAPP.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InnatAPP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvaliadorController : ControllerBase
    {
        private readonly IAvaliadorService _avaliadorService;

        public AvaliadorController(IAvaliadorService avaliadorService)
        {
            _avaliadorService = avaliadorService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<AvaliadorDTO>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<IEnumerable<AvaliadorDTO>>> GetAll()
        {
            var avaliadores = await _avaliadorService.BuscarAvaliadoresAsync();
            if (avaliadores == null)
            {
                return NotFound("Avaliadores não encontrados.");
            }
            return Ok(avaliadores);
        }

        [HttpGet("{id:int}", Name = "GetAvaliador")]
        public async Task<ActionResult<AvaliadorDTO>> GetById(int id)
        {
            var avaliador = await _avaliadorService.BuscarAvaliadorPorIdAsync(id);
            if (avaliador == null)
            {
                return NotFound("Avaliador não encontrado.");
            }
            return Ok(avaliador);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AvaliadorDTO avaliadorDTO)
        {
            if (avaliadorDTO == null)
                return BadRequest("Dados inválidos.");

            await _avaliadorService.CriarAvaliadorAsync(avaliadorDTO);

            return new CreatedAtRouteResult("GetAvaliador", new { id = avaliadorDTO.Id }, avaliadorDTO);
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] AvaliadorDTO avaliadorDTO)
        {
            if (id != avaliadorDTO.Id)
                return BadRequest("Dados inválidos.");

            if (avaliadorDTO == null)
                return BadRequest("Avaliador não encontrado.");

            await _avaliadorService.AtualizarAvaliadorAsync(avaliadorDTO);

            return Ok(avaliadorDTO);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<AvaliadorDTO>> Delete(int id)
        {
            var avaliador = await _avaliadorService.BuscarAvaliadorPorIdAsync(id);
            if (avaliador == null)
            {
                return NotFound("Avaliador não encontrado.");
            }

            await _avaliadorService.DeletarAvaliadorAsync(id);
            return Ok(avaliador);
        }
    }
}
