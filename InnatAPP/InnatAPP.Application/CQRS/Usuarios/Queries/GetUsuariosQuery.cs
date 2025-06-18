using MediatR;
using InnatAPP.Domain.Entities;

namespace InnatAPP.Application.CQRS.Usuarios.Queries
{
    public class GetUsuariosQuery : IRequest<IEnumerable<Usuario>>
    {
    }
}