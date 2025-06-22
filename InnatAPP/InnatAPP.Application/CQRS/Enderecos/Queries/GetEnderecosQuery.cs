using MediatR;
using InnatAPP.Domain.Entities;

namespace InnatAPP.Application.CQRS.Enderecos.Queries
{
    public class GetEnderecosQuery : IRequest<IEnumerable<Endereco>>
    {

    }
}