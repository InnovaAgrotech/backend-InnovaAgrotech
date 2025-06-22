using MediatR;
using InnatAPP.Domain.Entities;

namespace InnatAPP.Application.CQRS.Mensagens.Queries
{
    public class GetMensagemByIdQuery : IRequest<Mensagem>
    {
        public Guid Id { get; set; }
        public GetMensagemByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}