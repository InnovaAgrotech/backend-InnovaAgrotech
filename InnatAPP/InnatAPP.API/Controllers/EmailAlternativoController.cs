using Microsoft.AspNetCore.Mvc;
using InnatAPP.Application.DTOs;
using InnatAPP.Application.Interfaces;

namespace InnatAPP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailAlternativoController : ControllerBase
    {
        private readonly IEmailAlternativoService _emailAlternativoService;

        public EmailAlternativoController(IEmailAlternativoService emailAlternativoService)
        {
            _emailAlternativoService = emailAlternativoService;
        }

        #region Buscas

        [HttpGet("{id:Guid}", Name = "GetEmailAlternativo")]
        public async Task<ActionResult<EmailAlternativoDTO>> GetById(Guid id)
        {
            var emailAlternativo = await _emailAlternativoService.BuscarEmailAlternativoPorIdAsync(id);
            if (emailAlternativo == null)
            {
                return NotFound("Email alternativo não encontrado.");
            }
            return Ok(emailAlternativo);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<EmailAlternativoDTO>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<IEnumerable<EmailAlternativoDTO>>> GetAll()
        {
            var emailsAlternativos = await _emailAlternativoService.BuscarEmailsAlternativosAsync();
            if (emailsAlternativos == null || !emailsAlternativos.Any())
            {
                return NotFound("Emails alternativos não encontrados.");
            }
            return Ok(emailsAlternativos);
        }

        [HttpGet ("usuario/{idUsuario:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<EmailAlternativoDTO>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<IEnumerable<EmailAlternativoDTO>>> GetAllByUsuario(Guid idUsuario)
        {
            var emailsAlternativos = await _emailAlternativoService.BuscarEmailsAlternativosPorUsuarioAsync(idUsuario);
            if (emailsAlternativos == null || !emailsAlternativos.Any())
            {
                return NotFound("Emails alternativos não encontrados.");
            }
            return Ok(emailsAlternativos);
        }

        #endregion

        #region Comandos

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] EmailAlternativoDTO emailAlternativoDTO)
        {
            if (emailAlternativoDTO == null)
                return BadRequest("Dados inválidos.");

            await _emailAlternativoService.CriarEmailAlternativoAsync(emailAlternativoDTO);

            return new CreatedAtRouteResult("GetEmailAlternativo", new { id = emailAlternativoDTO.Id }, emailAlternativoDTO);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Guid id, [FromBody] EmailAlternativoDTO emailAlternativoDTO)
        {
            if (emailAlternativoDTO == null)
                return BadRequest("Email Alternativo não encontrado.");

            if (id != emailAlternativoDTO.Id)
                return BadRequest("Dados inválidos.");

            await _emailAlternativoService.AtualizarEmailAlternativoAsync(emailAlternativoDTO);

            return Ok(emailAlternativoDTO);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult<EmailAlternativoDTO>> Delete(Guid id)
        {
            var emailAlternativo = await _emailAlternativoService.BuscarEmailAlternativoPorIdAsync(id);
            if (emailAlternativo == null)
            {
                return NotFound("Email alternativo não encontrado.");
            }

            await _emailAlternativoService.DeletarEmailAlternativoAsync(id);
            return Ok(emailAlternativo);
        }

        #endregion
    }
}