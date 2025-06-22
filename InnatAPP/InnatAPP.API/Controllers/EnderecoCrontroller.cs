using Microsoft.AspNetCore.Mvc;
using InnatAPP.Application.DTOs;
using InnatAPP.Application.Interfaces;

namespace InnatAPP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoCrontroller : ControllerBase
    {
        private readonly IEnderecoService _enderecoService;

        public EnderecoCrontroller(IEnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
        }

        #region Buscas

        [HttpGet("{id:Guid}", Name = "GetEndereco")]
        public async Task<ActionResult<EnderecoDTO>> GetById(Guid id)
        {
            var endereco = await _enderecoService.BuscarEnderecoPorIdAsync(id);
            if (endereco == null)
            {
                return NotFound("Endereço não encontrado.");
            }
            return Ok(endereco);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<EnderecoDTO>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<IEnumerable<EnderecoDTO>>> GetAll()
        {
            var enderecos = await _enderecoService.BuscarEnderecosAsync();
            if (enderecos == null || !enderecos.Any())
            {
                return NotFound("Endereços não encontrados.");
            }
            return Ok(enderecos);
        }

        [HttpGet("usuario/{idUsuario:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<EnderecoDTO>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<IEnumerable<EnderecoDTO>>> GetAllByUsuario(Guid idUsuario)
        {
            var enderecos = await _enderecoService.BuscarEnderecosPorUsuarioAsync(idUsuario);
            if (enderecos == null || !enderecos.Any())
            {
                return NotFound("Enderecos não encontrados.");
            }
            return Ok(enderecos);
        }

        #endregion

        #region Comandos

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] EnderecoDTO enderecoDTO)
        {
            if (enderecoDTO == null)
                return BadRequest("Dados inválidos.");

            await _enderecoService.CriarEnderecoAsync(enderecoDTO);

            return new CreatedAtRouteResult("GetEndereco", new { id = enderecoDTO.Id }, enderecoDTO);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Guid id, [FromBody] EnderecoDTO enderecoDTO)
        {
            if (enderecoDTO == null)
                return BadRequest("Endereço não encontrado.");

            if (id != enderecoDTO.Id)
                return BadRequest("Dados inválidos.");

            await _enderecoService.AtualizarEnderecoAsync(enderecoDTO);

            return Ok(enderecoDTO);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult<EnderecoDTO>> Delete(Guid id)
        {
            var endereco = await _enderecoService.BuscarEnderecoPorIdAsync(id);
            if (endereco == null)
            {
                return NotFound("Endereço não encontrado.");
            }

            await _enderecoService.DeletarEnderecoAsync(id);
            return Ok(endereco);
        }

        #endregion
    }
}