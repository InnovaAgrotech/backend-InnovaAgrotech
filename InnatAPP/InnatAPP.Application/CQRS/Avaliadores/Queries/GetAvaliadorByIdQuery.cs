using MediatR;
using InnatAPP.Domain.Entities;

namespace InnatAPP.Application.CQRS.Avaliadores.Queries
{
    public class GetAvaliadorByIdQuery : IRequest<Avaliador>
    {
        public Guid Id { get; set; }
        public GetAvaliadorByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}