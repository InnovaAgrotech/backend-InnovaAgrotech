using MediatR;
using InnatAPP.Domain.Entities;

namespace InnatAPP.Application.CQRS.Usuarios.Queries
{
    public class GetUsuarioByEmailQuery : IRequest<Usuario>
    {
        public string Email { get; set; }
        public GetUsuarioByEmailQuery(string email)
        {
            Email = email;
        }
    }
}