using InnatAPP.Application.DTOs;
using InnatAPP.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InnatAPP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoEmpresaController : ControllerBase
    {
        private readonly IEnderecoEmpresaService _enderecoEmpresaService;

        public EnderecoEmpresaController(IEnderecoEmpresaService enderecoEmpresaService)
        {
            _enderecoEmpresaService = enderecoEmpresaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EnderecoEmpresaDTO>>> GetAll()
        {
            var enderecosEmpresas = await _enderecoEmpresaService.BuscarEnderecosDeEmpresasAsync();
            if (enderecosEmpresas == null)
            {
                return NotFound("Endereços de empresas não encontrados.");
            }
            return Ok(enderecosEmpresas);
        }

        [HttpGet("{id:int}", Name = "GetEnderecosDeEmpresa")]
        public async Task<ActionResult<EnderecoEmpresaDTO>> GetById(int id)
        {
            var enderecoEmpresa = await _enderecoEmpresaService.BuscarEnderecoDeEmpresaPorIdAsync(id);
            if (enderecoEmpresa == null)
            {
                return NotFound("Endereço de empresa não encontrado.");
            }
            return Ok(enderecoEmpresa);
        }

        [HttpGet("avaliador/{idEmpresa:int}")]
        public async Task<ActionResult<IEnumerable<EnderecoEmpresaDTO>>> GetByAvaliador(int idEmpresa)
        {
            var enderecoEmpresa = await _enderecoEmpresaService.BuscarEnderecosPorEmpresaAsync(idEmpresa);
            if (enderecoEmpresa == null)
            {
                return NotFound("Nenhum endereço encontrado para essa empresa");
            }
            return Ok(enderecoEmpresa);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] EnderecoEmpresaDTO enderecoEmpresaDTO)
        {
            if (enderecoEmpresaDTO == null)
                return BadRequest("Dados inválidos.");

            await _enderecoEmpresaService.CriarEnderecoDeEmpresaAsync(enderecoEmpresaDTO);

            return new CreatedAtRouteResult("GetEnderecosDeEmpresa", new { id = enderecoEmpresaDTO.Id }, enderecoEmpresaDTO);
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] EnderecoEmpresaDTO enderecoEmpresaDTO)
        {
            if (id != enderecoEmpresaDTO.Id)
                return BadRequest("Dados inválidos.");

            if (enderecoEmpresaDTO == null)
                return BadRequest("Endereço de empresa não encontrado.");

            await _enderecoEmpresaService.AtualizarEnderecoDeEmpresaAsync(enderecoEmpresaDTO);

            return Ok(enderecoEmpresaDTO);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<EnderecoEmpresaDTO>> Delete(int id)
        {
            var enderecoEmpresa = await _enderecoEmpresaService.BuscarEnderecoDeEmpresaPorIdAsync(id);
            if (enderecoEmpresa == null)
            {
                return NotFound("Endereço de empresa não encontrado.");
            }

            await _enderecoEmpresaService.DeletarEnderecoDeEmpresaAsync(id);
            return Ok(enderecoEmpresa);
        }
    }
}
