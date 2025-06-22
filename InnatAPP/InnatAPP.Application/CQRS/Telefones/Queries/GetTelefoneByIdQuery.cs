using MediatR;
using InnatAPP.Domain.Entities;

namespace InnatAPP.Application.CQRS.Telefones.Queries
{
    public class GetTelefoneByIdQuery : IRequest<Telefone>
    {
        public Guid Id { get; set; }
        public GetTelefoneByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}