using Microsoft.AspNetCore.Mvc;
using InnatAPP.Application.DTOs;
using InnatAPP.Application.Interfaces;

namespace InnatAPP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresasController : ControllerBase
    {
        private readonly IEmpresaService _empresaService;

        public EmpresasController(IEmpresaService empresaService)
        {
            _empresaService = empresaService;
        }

        #region Buscas

        [HttpGet("{id:Guid}", Name = "GetEmpresa")]
        public async Task<ActionResult<EmpresaDTO>> GetById(Guid id)
        {
            var empresa = await _empresaService.BuscarEmpresaPorIdAsync(id);
            if (empresa == null)
            {
                return NotFound("Empresa não encontrada.");
            }
            return Ok(empresa);
        }

        [HttpGet("usuario/{idUsuario:Guid}")]
        public async Task<ActionResult<EmpresaDTO>> GetByUsuario(Guid idUsuario)
        {
            var empresa = await _empresaService.BuscarEmpresaPorIdDeUsuarioAsync(idUsuario);
            if (empresa == null)
            {
                return NotFound("Nenhuma empresa encontrada.");
            }
            return Ok(empresa);
        }

        [HttpGet("email:/{email}", Name = "GetEmpresaByEmail")]
        public async Task<ActionResult<EmpresaDTO>> GetByEmail(string email)
        {
            var empresa = await _empresaService.BuscarEmpresaPorEmailAsync(email);
            if (empresa == null)
            {
                return NotFound("Empresa não encontrada.");
            }
            return Ok(empresa);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<EmpresaDTO>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<IEnumerable<EmpresaDTO>>> GetAll()
        {
            var empresas = await _empresaService.BuscarEmpresasAsync();
            if (empresas == null || !empresas.Any())
            {
                return NotFound("Empresas não encontradas.");
            }
            return Ok(empresas);
        }

        #endregion

        #region Comandos

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] EmpresaDTO empresaDTO)
        {
            if (empresaDTO == null)
                return BadRequest("Dados inválidos.");

            await _empresaService.CriarEmpresaAsync(empresaDTO);

            return new CreatedAtRouteResult("GetEmpresa", new { id = empresaDTO.Id }, empresaDTO);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult<EmpresaDTO>> Delete(Guid id)
        {
            var empresa = await _empresaService.BuscarEmpresaPorIdAsync(id);
            if (empresa == null)
            {
                return NotFound("Empresa não encontrada.");
            }

            await _empresaService.DeletarEmpresaAsync(id);
            return Ok(empresa);
        }

        #endregion
    }
}