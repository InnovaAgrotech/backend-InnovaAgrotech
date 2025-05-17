using InnatAPP.Application.DTOs;
using InnatAPP.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InnatAPP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailAlternativoEmpresaController : ControllerBase
    {
        private readonly IEmailAlternativoEmpresaService _emailAlternativoEmpresaService;

        public EmailAlternativoEmpresaController(IEmailAlternativoEmpresaService emailAlternativoEmpresaService)
        {
            _emailAlternativoEmpresaService = emailAlternativoEmpresaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmailAlternativoEmpresaDTO>>> GetAll()
        {
            var emailsAlternativosEmpresas = await _emailAlternativoEmpresaService.BuscarEmailsAlternativosDeEmpresasAsync();
            if (emailsAlternativosEmpresas == null)
            {
                return NotFound("E-mails Alternativos de empresas não encontrados.");
            }
            return Ok(emailsAlternativosEmpresas);
        }

        [HttpGet("{id:int}", Name = "GetEmailAlternativoDeEmpresa")]
        public async Task<ActionResult<EmailAlternativoEmpresaDTO>> GetById(int id)
        {
            var emailAlternativoEmpresa = await _emailAlternativoEmpresaService.BuscarEmailAlternativoDeEmpresaPorIdAsync(id);
            if (emailAlternativoEmpresa == null)
            {
                return NotFound("E-mail alternativo de empresa não encontrado.");
            }
            return Ok(emailAlternativoEmpresa);
        }

        [HttpGet("avaliador/{idAvaliador:int}")]
        public async Task<ActionResult<IEnumerable<EmailAlternativoEmpresaDTO>>> GetByAvaliador(int idEmpresas)
        {
            var emailAlternativoEmpresa = await _emailAlternativoEmpresaService.BuscarEmailsAlternativosPorEmpresaAsync(idEmpresas);
            if (emailAlternativoEmpresa == null)
            {
                return NotFound("Nenhum e-mail alternativo encontrado para essa empresa");
            }
            return Ok(emailAlternativoEmpresa);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] EmailAlternativoEmpresaDTO emailAlternativoEmpresaDTO)
        {
            if (emailAlternativoEmpresaDTO == null)
                return BadRequest("Dados inválidos.");

            await _emailAlternativoEmpresaService.CriarEmailAlternativoEmpresaAsync(emailAlternativoEmpresaDTO);

            return new CreatedAtRouteResult("GetEmailAlternativoDeEmpresa", new { id = emailAlternativoEmpresaDTO.Id }, emailAlternativoEmpresaDTO);
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] EmailAlternativoEmpresaDTO emailAlternativoEmpresaDTO)
        {
            if (id != emailAlternativoEmpresaDTO.Id)
                return BadRequest("Dados inválidos.");

            if (emailAlternativoEmpresaDTO == null)
                return BadRequest("E-mail alternativo de empresa não encontrado.");

            await _emailAlternativoEmpresaService.AtualizarEmailAlternativoEmpresaAsync(emailAlternativoEmpresaDTO);

            return Ok(emailAlternativoEmpresaDTO);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<EmailAlternativoEmpresaDTO>> Delete(int id)
        {
            var emailAlternativoEmpresa = await _emailAlternativoEmpresaService.BuscarEmailAlternativoDeEmpresaPorIdAsync(id);
            if (emailAlternativoEmpresa == null)
            {
                return NotFound("E-mail alternativo de empresa não encontrado");
            }

            await _emailAlternativoEmpresaService.DeletarEmailAlternativoEmpresaAsync(id);
            return Ok(emailAlternativoEmpresa);
        }
    }
}
