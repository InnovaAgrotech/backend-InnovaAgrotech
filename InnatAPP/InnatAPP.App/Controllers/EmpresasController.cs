using InnatAPP.Application.DTOs;
using InnatAPP.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpresaDTO>>> GetAll()
        {
            var empresas = await _empresaService.BuscarEmpresasAsync();
            if (empresas == null)
            {
                return NotFound("Empresas não encontradas.");
            }
            return Ok(empresas);
        }

        [HttpGet("{id:int}", Name = "GetEmpresa")]
        public async Task<ActionResult<EmpresaDTO>> GetById(int id)
        {
            var empresa = await _empresaService.BuscarEmpresaPorIdAsync(id);
            if (empresa == null)
            {
                return NotFound("Empresa não encontrada.");
            }
            return Ok(empresa);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] EmpresaDTO empresaDTO)
        {
            if (empresaDTO == null)
                return BadRequest("Dados inválidos.");

            await _empresaService.CriarEmpresaAsync(empresaDTO);

            return new CreatedAtRouteResult("GetEmpresa", new { id = empresaDTO.Id }, empresaDTO);
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] EmpresaDTO empresaDTO)
        {
            if (id != empresaDTO.Id)
                return BadRequest("Dados inválidos.");

            if (empresaDTO == null)
                return BadRequest("Empresa não encontrada.");

            await _empresaService.AtualizarEmpresaAsync(empresaDTO);

            return Ok(empresaDTO);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<EmpresaDTO>> Delete(int id)
        {
            var empresa = await _empresaService.BuscarEmpresaPorIdAsync(id);
            if (empresa == null)
            {
                return NotFound("Empresa não encontrada.");
            }

            await _empresaService.DeletarEmpresaAsync(id);
            return Ok(empresa);
        }
    }
}
