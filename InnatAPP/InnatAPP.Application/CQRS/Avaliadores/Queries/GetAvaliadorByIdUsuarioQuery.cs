using MediatR;
using InnatAPP.Domain.Entities;

namespace InnatAPP.Application.CQRS.Avaliadores.Queries
{
    public class GetAvaliadorByIdUsuarioQuery : IRequest<Avaliador>
    {
        public Guid IdUsuario { get; set; }
        public GetAvaliadorByIdUsuarioQuery(Guid idUsuario)
        {
            IdUsuario = idUsuario;
        }

    }
}