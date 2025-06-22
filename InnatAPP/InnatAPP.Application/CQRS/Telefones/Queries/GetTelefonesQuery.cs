using MediatR;
using InnatAPP.Domain.Entities;

namespace InnatAPP.Application.CQRS.Telefones.Queries
{
    public class GetTelefonesQuery :IRequest<IEnumerable<Telefone>>
    {

    }
}