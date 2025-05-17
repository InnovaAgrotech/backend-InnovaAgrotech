using InnatAPP.Application.DTOs;
using InnatAPP.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MensagemDTO>>> GetAll()
        {
            var mensagens = await _mensagemService.BuscarMensagensAsync();
            if (mensagens == null)
            {
                return NotFound("Mensagens não encontradas.");
            }
            return Ok(mensagens);
        }

        [HttpGet("{id:int}", Name = "GetMensagem")]
        public async Task<ActionResult<MensagemDTO>> GetById(int id)
        {
            var mensagem = await _mensagemService.BuscarMensagemPorIdAsync(id);
            if (mensagem == null)
            {
                return NotFound("Mensagem não encontrada.");
            }
            return Ok(mensagem);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] MensagemDTO mensagemDTO)
        {
            if (mensagemDTO == null)
                return BadRequest("Dados inválidos.");

            await _mensagemService.CriarMensagemAsync(mensagemDTO);

            return new CreatedAtRouteResult("GetMensagem", new { id = mensagemDTO.Id }, mensagemDTO);
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] MensagemDTO mensagemDTO)
        {
            if (id != mensagemDTO.Id)
                return BadRequest("Dados inválidos.");

            if (mensagemDTO == null)
                return BadRequest("Mensagem não encontrada.");

            await _mensagemService.AtualizarMensagemAsync(mensagemDTO);

            return Ok(mensagemDTO);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<MensagemDTO>> Delete(int id)
        {
            var mensagem = await _mensagemService.BuscarMensagemPorIdAsync(id);
            if (mensagem == null)
            {
                return NotFound("Mensagem não encontrada.");
            }

            await _mensagemService.DeletarMensagemAsync(id);
            return Ok(mensagem);
        }
    }
}