using MediatR;
using InnatAPP.Domain.Entities;

namespace InnatAPP.Application.CQRS.Usuarios.Queries
{
    public class GetUsuarioByIdQuery : IRequest<Usuario>
    {
        public Guid Id { get; set; }
        public GetUsuarioByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}