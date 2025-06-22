using MediatR;
using InnatAPP.Domain.Entities;

namespace InnatAPP.Application.CQRS.Mensagens.Queries
{
    public class GetMensagensQuery : IRequest<IEnumerable<Mensagem>>
    {

    }
}