using MediatR;
using InnatAPP.Domain.Entities;

namespace InnatAPP.Application.CQRS.Usuarios.Queries
{
    public class GetUsuarioByEmailESenhaQuery : IRequest<Usuario>
    {
        public string Email { get; set; }
        public string SenhaHash { get; set; }

        public GetUsuarioByEmailESenhaQuery(string email, string senhaHash)
        {
            Email = email;
            SenhaHash = senhaHash;
        }
    }
}