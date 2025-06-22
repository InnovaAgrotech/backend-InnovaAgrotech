using Microsoft.AspNetCore.Mvc;
using InnatAPP.Application.DTOs;
using InnatAPP.Application.Interfaces;

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

        #region Buscas

        [HttpGet("{id:Guid}", Name = "GetAvaliador")]
        public async Task<ActionResult<AvaliadorDTO>> GetById(Guid id)
        {
            var avaliador = await _avaliadorService.BuscarAvaliadorPorIdAsync(id);
            if (avaliador == null)
            {
                return NotFound("Avaliador não encontrado.");
            }
            return Ok(avaliador);
        }

        [HttpGet("usuario/{idUsuario:Guid}")]
        public async Task<ActionResult<AvaliadorDTO>> GetByUsuario(Guid idUsuario)
        {
            var avaliador = await _avaliadorService.BuscarAvaliadorPorIdDeUsuarioAsync(idUsuario);
            if (avaliador == null)
            {
                return NotFound("Nenhum avaliador encontrado.");
            }
            return Ok(avaliador);
        }

        [HttpGet("email:/{email}", Name = "GetAvaliadorByEmail")]
        public async Task<ActionResult<AvaliadorDTO>> GetByEmail(string email)
        {
            var avaliador = await _avaliadorService.BuscarAvaliadorPorEmailAsync(email);
            if (avaliador == null)
            {
                return NotFound("Avaliador não encontrado.");
            }
            return Ok(avaliador);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<AvaliadorDTO>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<IEnumerable<AvaliadorDTO>>> GetAll()
        {
            var avaliadores = await _avaliadorService.BuscarAvaliadoresAsync();
            if (avaliadores == null || !avaliadores.Any())
            {
                return NotFound("Avaliadores não encontrados.");
            }
            return Ok(avaliadores);
        }

        #endregion

        #region Comandos

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AvaliadorDTO avaliadorDTO)
        {
            if (avaliadorDTO == null)
                return BadRequest("Dados inválidos.");

            await _avaliadorService.CriarAvaliadorAsync(avaliadorDTO);

            return new CreatedAtRouteResult("GetAvaliador", new { id = avaliadorDTO.Id }, avaliadorDTO);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult<AvaliadorDTO>> Delete(Guid id)
        {
            var avaliador = await _avaliadorService.BuscarAvaliadorPorIdAsync(id);
            if (avaliador == null)
            {
                return NotFound("Avaliador não encontrado.");
            }

            await _avaliadorService.DeletarAvaliadorAsync(id);
            return Ok(avaliador);
        }

        #endregion
    }
}