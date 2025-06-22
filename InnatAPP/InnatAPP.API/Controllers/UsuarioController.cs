using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using InnatAPP.Application.Interfaces;
using InnatAPP.Application.DTOs.Usuario;

namespace InnatAPP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;

        public UsuarioController(IUsuarioService usuarioService, IMapper mapper)
        {
            _usuarioService = usuarioService;
            _mapper = mapper;
        }

        #region Buscas

        [HttpGet("{id:Guid}", Name = "GetUsuario")]
        public async Task<ActionResult<UsuarioRespostaDTO>> GetById(Guid id)
        {
            var usuario = await _usuarioService.BuscarUsuarioPorIdAsync(id);
            if (usuario == null)
                return NotFound("Usuário não encontrado.");

            return Ok(usuario);
        }

        [HttpGet("email/{email}", Name = "GetUsuarioByEmail")]
        public async Task<ActionResult<UsuarioRespostaDTO>> GetByEmail(string email)
        {
            var usuario = await _usuarioService.BuscarUsuarioPorEmailAsync(email);
            if (usuario == null)
                return NotFound("Usuário não encontrado.");

            return Ok(usuario);
        }

        [HttpGet("loginSemToken")]
        public async Task<ActionResult<UsuarioRespostaDTO>> Login([FromQuery] string email, [FromQuery] string senha)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(senha))
                return BadRequest("Email e senha são obrigatórios.");

            var usuario = await _usuarioService.BuscarUsuarioPorEmailESenhaAsync(new LoginUsuarioDTO { Email = email, Senha = senha });
            if (usuario == null)
                return Unauthorized("Credenciais inválidas.");

            return Ok(usuario);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioRespostaDTO>>> GetAll()
        {
            var usuarios = await _usuarioService.BuscarUsuariosAsync();
            if (usuarios == null || !usuarios.Any())
                return NoContent();

            return Ok(usuarios);
        }

        [HttpGet("tipo/{tipoUsuarioTexto}")]
        public async Task<ActionResult<IEnumerable<UsuarioRespostaDTO>>> GetByTipo(string tipoUsuarioTexto)
        {
            try
            {
                Console.WriteLine($"Valor recebido: [{tipoUsuarioTexto}]");

                var tipoUsuario = Domain.ValueObjects.TipoUsuario.FromString(tipoUsuarioTexto);
                var usuarios = await _usuarioService.BuscarUsuariosPorTipoAsync(tipoUsuario);
                if (usuarios == null || !usuarios.Any())
                    return NoContent();

                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao converter tipo de usuário: {ex.Message}");
                return BadRequest("Tipo de usuário inválido.");
            }
        }

        #endregion

        #region Comandos

        [HttpPost("cadastro")]
        public async Task<ActionResult> Cadastro([FromBody] UsuarioCreateDTO usuarioCreateDto)
        {
            try
            {
                if (usuarioCreateDto == null)
                    return BadRequest("Dados inválidos.");

                var usuarioCriado = await _usuarioService.CriarUsuarioAsync(usuarioCreateDto);
                var usuarioDto = _mapper.Map<UsuarioRespostaDTO>(usuarioCriado);

                return CreatedAtRoute("GetUsuario", new { id = usuarioDto.Id }, usuarioDto);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensagem = "Erro interno ao criar usuário.", detalhes = ex.Message });
            }
        }

        [HttpPut("{id:Guid}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] UsuarioUpdateDTO usuarioDto)
        {
            if (usuarioDto == null || id != usuarioDto.Id)
                return BadRequest("Dados inválidos.");

            await _usuarioService.AtualizarUsuarioAsync(usuarioDto);
            return Ok(usuarioDto);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult<UsuarioRespostaDTO>> Delete(Guid id)
        {
            var usuario = await _usuarioService.BuscarUsuarioPorIdAsync(id);
            if (usuario == null)
                return NotFound("Usuário não encontrado.");

            await _usuarioService.DeletarUsuarioAsync(id);
            return Ok(usuario);
        }

        #endregion
    }
}