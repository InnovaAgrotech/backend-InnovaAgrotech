using InnatAPP.Application.DTOs;
using InnatAPP.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InnatAPP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailAlternativoAvaliadorController : ControllerBase
    {
        private readonly IEmailAlternativoAvaliadorService _emailAlternativoAvaliadorService;

        public EmailAlternativoAvaliadorController(IEmailAlternativoAvaliadorService emailAlternativoAvaliadorService)
        {
            _emailAlternativoAvaliadorService = emailAlternativoAvaliadorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmailAlternativoAvaliadorDTO>>> GetAll()
        {
            var emailsAlternativosAvaliadores = await _emailAlternativoAvaliadorService.BuscarEmailsAlternativosDeAvaliadoresAsync();
            if (emailsAlternativosAvaliadores == null)
            {
                return NotFound("E-mails Alternativos de avaliadores não encontrados.");
            }
            return Ok(emailsAlternativosAvaliadores);
        }

        [HttpGet("{id:int}", Name = "GetEmailAlternativoDeAvaliador")]
        public async Task<ActionResult<EmailAlternativoAvaliadorDTO>> GetById(int id)
        {
            var emailAlternativoAvaliador = await _emailAlternativoAvaliadorService.BuscarEmailAlternativoDeAvaliadorPorIdAsync(id);
            if (emailAlternativoAvaliador == null)
            {
                return NotFound("E-mail alternativo de avaliador não encontrado.");
            }
            return Ok(emailAlternativoAvaliador);
        }

        [HttpGet("avaliador/{idAvaliador:int}")]
        public async Task<ActionResult<IEnumerable<EmailAlternativoAvaliadorDTO>>> GetByAvaliador(int idAvaliador)
        {
            var emailAlternativoAvaliador = await _emailAlternativoAvaliadorService.BuscarEmailsAlternativosPorAvaliadorAsync(idAvaliador);
            if (emailAlternativoAvaliador == null)
            {
                return NotFound("Nenhum e-mail alternativo encontrado para esse avaliador.");
            }
            return Ok(emailAlternativoAvaliador);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] EmailAlternativoAvaliadorDTO emailAlternativoAvaliadorDTO)
        {
            if (emailAlternativoAvaliadorDTO == null)
                return BadRequest("Dados inválidos.");

            await _emailAlternativoAvaliadorService.CriarEmailAlternativoDeAvaliadorAsync(emailAlternativoAvaliadorDTO);

            return new CreatedAtRouteResult("GetEmailAlternativoDeAvaliador", new { id = emailAlternativoAvaliadorDTO.Id }, emailAlternativoAvaliadorDTO);
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] EmailAlternativoAvaliadorDTO emailAlternativoAvaliadorDTO)
        {
            if (id != emailAlternativoAvaliadorDTO.Id)
                return BadRequest("Dados inválidos.");

            if (emailAlternativoAvaliadorDTO == null)
                return BadRequest("E-mail alternativo de avaliador não encontrado.");

            await _emailAlternativoAvaliadorService.AtualizarEmailAlternativoDeAvaliadorAsync(emailAlternativoAvaliadorDTO);

            return Ok(emailAlternativoAvaliadorDTO);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<EmailAlternativoAvaliadorDTO>> Delete(int id)
        {
            var emailAlternativoAvaliador = await _emailAlternativoAvaliadorService.BuscarEmailAlternativoDeAvaliadorPorIdAsync(id);
            if (emailAlternativoAvaliador == null)
            {
                return NotFound("E-mail alternativo de avaliador não encontrado.");
            }

            await _emailAlternativoAvaliadorService.DeletarEmailAlternativoDeAvaliadorAsync(id);
            return Ok(emailAlternativoAvaliador);
        }
    }
}