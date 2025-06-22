using Microsoft.AspNetCore.Mvc;
using InnatAPP.Application.DTOs;
using InnatAPP.Application.Interfaces;

namespace InnatAPP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MensagemController : ControllerBase
    {
        private readonly IMensagemService _mensagemService;

        public MensagemController(IMensagemService mensagemService)
        {
            _mensagemService = mensagemService;
        }

        #region Buscas

        [HttpGet("{id:Guid}", Name = "GetMensagem")]
        public async Task<ActionResult<MensagemDTO>> GetById(Guid id)
        {
            var mensagem = await _mensagemService.BuscarMensagemPorIdAsync(id);
            if (mensagem == null)
            {
                return NotFound("Mensagem não encontrada.");
            }
            return Ok(mensagem);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<MensagemDTO>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<IEnumerable<MensagemDTO>>> GetAll()
        {
            var mensagens = await _mensagemService.BuscarMensagensAsync();
            if (mensagens == null || !mensagens.Any())
            {
                return NotFound("Mensagens não encontradas.");
            }
            return Ok(mensagens);
        }

        #endregion

        #region Comandos

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] MensagemDTO mensagemDTO)
        {
            if (mensagemDTO == null)
                return BadRequest("Dados inválidos.");

            await _mensagemService.CriarMensagemAsync(mensagemDTO);

            return new CreatedAtRouteResult("GetMensagem", new { id = mensagemDTO.Id }, mensagemDTO);
        }

        #endregion
    }
}