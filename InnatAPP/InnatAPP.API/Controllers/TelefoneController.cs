using Microsoft.AspNetCore.Mvc;
using InnatAPP.Application.DTOs;
using InnatAPP.Application.Interfaces;

namespace InnatAPP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelefoneController : ControllerBase
    {
        private readonly ITelefoneService _telefoneService;

        public TelefoneController(ITelefoneService telefoneService)
        {
            _telefoneService = telefoneService;
        }

        #region Buscas

        [HttpGet("{id:Guid}", Name = "GetTelefone")]
        public async Task<ActionResult<TelefoneDTO>> GetById(Guid id)
        {
            var telefone = await _telefoneService.BuscarTelefonePorIdAsync(id);
            if (telefone == null)
            {
                return NotFound("Telefone não encontrado.");
            }
            return Ok(telefone);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<TelefoneDTO>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<IEnumerable<TelefoneDTO>>> GetAll()
        {
            var telefones = await _telefoneService.BuscarTelefonesAsync();
            if (telefones == null || !telefones.Any())
            {
                return NotFound("Telefones não encontrados.");
            }
            return Ok(telefones);
        }

        [HttpGet("usuario/{idUsuario:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<TelefoneDTO>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<IEnumerable<TelefoneDTO>>> GetAllByUsuario(Guid idUsuario)
        {
            var telefones = await _telefoneService.BuscarTelefonesPorUsuarioAsync(idUsuario);
            if (telefones == null || !telefones.Any())
            {
                return NotFound("Telefones não encontrados.");
            }
            return Ok(telefones);
        }

        #endregion

        #region Comandos

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TelefoneDTO telefoneDTO)
        {
            if (telefoneDTO == null)
                return BadRequest("Dados inválidos.");

            await _telefoneService.CriarTelefoneAsync(telefoneDTO);

            return new CreatedAtRouteResult("GetTelefone", new { id = telefoneDTO.Id }, telefoneDTO);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Guid id, [FromBody] TelefoneDTO telefoneDTO)
        {
            if (telefoneDTO == null)
                return BadRequest("Telefone não encontrado.");

            if (id != telefoneDTO.Id)
                return BadRequest("Dados inválidos.");

            await _telefoneService.AtualizarTelefoneAsync(telefoneDTO);

            return Ok(telefoneDTO);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult<TelefoneDTO>> Delete(Guid id)
        {
            var telefone = await _telefoneService.BuscarTelefonePorIdAsync(id);
            if (telefone == null)
            {
                return NotFound("Endereço não encontrado.");
            }

            await _telefoneService.DeletarTelefoneAsync(id);
            return Ok(telefone);
        }

        #endregion
    }
}