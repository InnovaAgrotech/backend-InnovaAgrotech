using InnatAPP.Application.DTOs;
using InnatAPP.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InnatAPP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelefoneAvaliadorController : ControllerBase
    {
        private readonly ITelefoneAvaliadorService _telefoneAvaliadorService;

        public TelefoneAvaliadorController(ITelefoneAvaliadorService telefoneAvaliadorService)
        {
            _telefoneAvaliadorService = telefoneAvaliadorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TelefoneAvaliadorDTO>>> GetAll()
        {
            var telefonesAvaliadores = await _telefoneAvaliadorService.BuscarTelefonesDeAvaliadoresAsync();
            if (telefonesAvaliadores == null)
            {
                return NotFound("Telefones de avaliadores não encontrados.");
            }
            return Ok(telefonesAvaliadores);
        }

        [HttpGet("{id:int}", Name = "GetTelefonesDeAvaliador")]
        public async Task<ActionResult<TelefoneAvaliadorDTO>> GetById(int id)
        {
            var telefoneAvaliador = await _telefoneAvaliadorService.BuscarTelefoneDeAvaliadorPorIdAsync(id);
            if (telefoneAvaliador == null)
            {
                return NotFound("Telefone de avaliador não encontrado.");
            }
            return Ok(telefoneAvaliador);
        }

        [HttpGet("avaliador/{idAvaliador:int}")]
        public async Task<ActionResult<IEnumerable<TelefoneAvaliadorDTO>>> GetByAvaliador(int idAvaliador)
        {
            var telefoneAvaliador = await _telefoneAvaliadorService.BuscarTelefonesPorAvaliadorAsync(idAvaliador);
            if (telefoneAvaliador == null)
            {
                return NotFound("Nenhum telefone encontrado para esse avaliador");
            }
            return Ok(telefoneAvaliador);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TelefoneAvaliadorDTO telefoneAvaliadorDTO)
        {
            if (telefoneAvaliadorDTO == null)
                return BadRequest("Dados inválidos.");

            await _telefoneAvaliadorService.CriarTelefoneDeAvaliadorAsync(telefoneAvaliadorDTO);

            return new CreatedAtRouteResult("GetTelefonesDeAvaliador", new { id = telefoneAvaliadorDTO.Id }, telefoneAvaliadorDTO);
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] TelefoneAvaliadorDTO telefoneAvaliadorDTO)
        {
            if (id != telefoneAvaliadorDTO.Id)
                return BadRequest("Dados inválidos.");

            if (telefoneAvaliadorDTO == null)
                return BadRequest("Telefone de avaliador não encontrado.");

            await _telefoneAvaliadorService.AtualizarTelefoneDeAvaliadorAsync(telefoneAvaliadorDTO);

            return Ok(telefoneAvaliadorDTO);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<TelefoneAvaliadorDTO>> Delete(int id)
        {
            var telefoneAvaliador = await _telefoneAvaliadorService.BuscarTelefoneDeAvaliadorPorIdAsync(id);
            if (telefoneAvaliador == null)
            {
                return NotFound("Telefone de avaliador não encontrado.");
            }

            await _telefoneAvaliadorService.DeletarTelefoneDeAvaliadorAsync(id);
            return Ok(telefoneAvaliador);
        }
    }
}
