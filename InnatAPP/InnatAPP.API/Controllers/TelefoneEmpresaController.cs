using InnatAPP.Application.DTOs;
using InnatAPP.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InnatAPP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelefoneEmpresaController : ControllerBase
    {
        private readonly ITelefoneEmpresaService _telefoneEmpresaService;

        public TelefoneEmpresaController(ITelefoneEmpresaService telefoneEmpresaService)
        {
            _telefoneEmpresaService = telefoneEmpresaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TelefoneEmpresaDTO>>> GetAll()
        {
            var telefonesEmpresas = await _telefoneEmpresaService.BuscarTelefonesDeEmpresasAsync();
            if (telefonesEmpresas == null)
            {
                return NotFound("Telefones de empresas não encontrados.");
            }
            return Ok(telefonesEmpresas);
        }

        [HttpGet("{id:int}", Name = "GetTelefonesDeEmpresas")]
        public async Task<ActionResult<TelefoneEmpresaDTO>> GetById(int id)
        {
            var telefoneEmpresa = await _telefoneEmpresaService.BuscarTelefoneDeEmpresaPorIdAsync(id);
            if (telefoneEmpresa == null)
            {
                return NotFound("Telefone de empresa não encontrado.");
            }
            return Ok(telefoneEmpresa);
        }

        [HttpGet("avaliador/{idEmpresa:int}")]
        public async Task<ActionResult<IEnumerable<TelefoneEmpresaDTO>>> GetByEmpresa(int idEmpresa)
        {
            var telefoneEmpresa = await _telefoneEmpresaService.BuscarTelefonesPorEmpresaAsync(idEmpresa);
            if (telefoneEmpresa == null)
            {
                return NotFound("Nenhum telefone encontrado para essa empresa");
            }
            return Ok(telefoneEmpresa);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TelefoneEmpresaDTO telefoneEmpresaDTO)
        {
            if (telefoneEmpresaDTO == null)
                return BadRequest("Dados inválidos.");

            await _telefoneEmpresaService.CriarTelefoneDeEmpresaAsync(telefoneEmpresaDTO);

            return new CreatedAtRouteResult("GetTelefonesDeEmpresas", new { id = telefoneEmpresaDTO.Id }, telefoneEmpresaDTO);
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] TelefoneEmpresaDTO telefoneEmpresaDTO)
        {
            if (id != telefoneEmpresaDTO.Id)
                return BadRequest("Dados inválidos.");

            if (telefoneEmpresaDTO == null)
                return BadRequest("Telefone de empresa não encontrado.");

            await _telefoneEmpresaService.AtualizarTelefoneDeEmpresaAsync(telefoneEmpresaDTO);

            return Ok(telefoneEmpresaDTO);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<TelefoneEmpresaDTO>> Delete(int id)
        {
            var telefoneEmpresa = await _telefoneEmpresaService.BuscarTelefoneDeEmpresaPorIdAsync(id);
            if (telefoneEmpresa == null)
            {
                return NotFound("Telefone de empresa não encontrado.");
            }

            await _telefoneEmpresaService.DeletarTelefoneDeEmpresaAsync(id);
            return Ok(telefoneEmpresa);
        }
    }
}
