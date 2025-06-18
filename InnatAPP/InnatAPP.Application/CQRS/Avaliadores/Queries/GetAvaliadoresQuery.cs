using MediatR;
using InnatAPP.Domain.Entities;

namespace InnatAPP.Application.CQRS.Avaliadores.Queries
{
    public class GetAvaliadoresQuery : IRequest<IEnumerable<Avaliador>>
    {

    }
}