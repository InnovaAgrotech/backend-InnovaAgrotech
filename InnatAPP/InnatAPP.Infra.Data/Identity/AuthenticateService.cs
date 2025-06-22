using System.Security.Claims;
using InnatAPP.Domain.Account;
using InnatAPP.Domain.Entities;
using InnatAPP.Infra.Data.Context;
using InnatAPP.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;

namespace InnatAPP.Infra.Data.Identity
{
    public class AuthenticateService : IAuthenticate
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthenticateService(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public async Task<bool> AuthenticateAsync(string email, string password)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(x => string.Equals(x.Email, email, StringComparison.OrdinalIgnoreCase) && x.SenhaHash == password);
            if (usuario == null)
            {
                return false;
            }
            return true;
        }

        public UserToken GetUserToken(Guid id, string email, TipoUsuario tipoUsuario)
        {
            var claims = new[]
            {
                new Claim("id", id.ToString()),
                new Claim("email", email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role, tipoUsuario.Valor)
            };

            var privateKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]!));

            var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddHours(5);

            JwtSecurityToken token = new(
                issuer: _configuration["Jwt:ValidUser"],
                audience: _configuration["Jwt:ValidAudience"],
                claims: claims,
                expires: expiration,
                signingCredentials: credentials);

            var userToken = new UserToken
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };

            return userToken;
        }

        public async Task<bool> UserExist(string email)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(x => string.Equals(x.Email, email, StringComparison.OrdinalIgnoreCase));

            if (usuario == null)
            {
                return false;
            }

            return true;
        }
    }
}