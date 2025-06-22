using MediatR;
using InnatAPP.Domain.Entities;

namespace InnatAPP.Application.CQRS.Mensagens.Commands
{
    public abstract class MensagemCommand : IRequest<Mensagem>
    {
        public string Nome { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string Texto { get; private set; } = string.Empty;
    }
}