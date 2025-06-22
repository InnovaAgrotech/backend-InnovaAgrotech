using InnatAPP.Domain.Account;
using Microsoft.AspNetCore.Mvc;
using InnatAPP.Domain.Entities;
using InnatAPP.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace InnatAPP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IAuthenticate _authenticate;
        private readonly IUsuarioService _usuarioService;

        public LoginController(IAuthenticate authenticate, IUsuarioService usuarioService)
        {
            _authenticate = authenticate;
            _usuarioService = usuarioService;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<UserToken>> LoginComToken([FromBody] LoginRequest login)
        {
            var autenticado = await _authenticate.AuthenticateAsync(login.Email, login.SenhaHash);
            if (!autenticado)
                return Unauthorized("Usuário ou senha inválidos");

            var usuario = await _usuarioService.BuscarUsuarioPorEmailAsync(login.Email);
            if (usuario == null)
                return Unauthorized("Usuário não encontrado");

            var token = _authenticate.GetUserToken(usuario.Id, usuario.Email, usuario.ToTipoUsuario()); 
            return Ok(token);
        }
    }
}