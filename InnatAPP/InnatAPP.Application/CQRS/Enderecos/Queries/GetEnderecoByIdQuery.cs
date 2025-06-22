using MediatR;
using InnatAPP.Domain.Entities;

namespace InnatAPP.Application.CQRS.Enderecos.Queries
{
    public class GetEnderecoByIdQuery : IRequest<Endereco>
    {
        public Guid Id { get; set; }
        public GetEnderecoByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}