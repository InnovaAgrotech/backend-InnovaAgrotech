using InnatAPP.Application.DTOs;
using InnatAPP.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InnatAPP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoAvaliadorController : ControllerBase
    {
        private readonly IEnderecoAvaliadorService _enderecoAvaliadorService;

        public EnderecoAvaliadorController(IEnderecoAvaliadorService enderecoAvaliadorService)
        {
            _enderecoAvaliadorService = enderecoAvaliadorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EnderecoAvaliadorDTO>>> GetAll()
        {
            var enderecosAvaliadores = await _enderecoAvaliadorService.BuscarEnderecosDeAvaliadoresAsync();
            if (enderecosAvaliadores == null)
            {
                return NotFound("Endereços de avaliadores não encontrados.");
            }
            return Ok(enderecosAvaliadores);
        }

        [HttpGet("{id:int}", Name = "GetEnderecosDeAvaliador")]
        public async Task<ActionResult<EnderecoAvaliadorDTO>> GetById(int id)
        {
            var enderecoAvaliador = await _enderecoAvaliadorService.BuscarEnderecoDeAvaliadorPorIdAsync(id);
            if (enderecoAvaliador == null)
            {
                return NotFound("Endereço de avaliador não encontrado.");
            }
            return Ok(enderecoAvaliador);
        }

        [HttpGet("avaliador/{idAvaliador:int}")]
        public async Task<ActionResult<IEnumerable<EnderecoAvaliadorDTO>>> GetByAvaliador(int idAvaliador)
        {
            var enderecoAvaliador = await _enderecoAvaliadorService.BuscarEnderecosPorAvaliadorAsync(idAvaliador);
            if (enderecoAvaliador == null)
            {
                return NotFound("Nenhum endereço encontrado para esse avaliador");
            }
            return Ok(enderecoAvaliador);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] EnderecoAvaliadorDTO enderecoAvaliadorDTO)
        {
            if (enderecoAvaliadorDTO == null)
                return BadRequest("Dados inválidos.");

            await _enderecoAvaliadorService.CriarEnderecoDeAvaliadorAsync(enderecoAvaliadorDTO);

            return new CreatedAtRouteResult("GetEnderecosDeAvaliador", new { id = enderecoAvaliadorDTO.Id }, enderecoAvaliadorDTO);
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] EnderecoAvaliadorDTO enderecoAvaliadorDTO)
        {
            if (id != enderecoAvaliadorDTO.Id)
                return BadRequest("Dados inválidos.");

            if (enderecoAvaliadorDTO == null)
                return BadRequest("Endereço de avaliador não encontrado.");

            await _enderecoAvaliadorService.AtualizarEnderecoDeAvaliadorAsync(enderecoAvaliadorDTO);

            return Ok(enderecoAvaliadorDTO);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<EnderecoAvaliadorDTO>> Delete(int id)
        {
            var enderecoAvaliador = await _enderecoAvaliadorService.BuscarEnderecoDeAvaliadorPorIdAsync(id);
            if (enderecoAvaliador == null)
            {
                return NotFound("Endereço de avaliador não encontrado.");
            }

            await _enderecoAvaliadorService.DeletarEnderecoDeAvaliadorAsync(id);
            return Ok(enderecoAvaliador);
        }
    }
}
