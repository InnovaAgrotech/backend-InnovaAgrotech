using MediatR;
using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Application.CQRS.Mensagens.Commands;

namespace InnatAPP.Application.CQRS.Mensagens.Handlers
{
    public class MensagemCreateCommandHandler : IRequestHandler<MensagemCreateCommand, Mensagem>
    {
        private readonly IMensagemRepository _mensagemRepository;

        public MensagemCreateCommandHandler(IMensagemRepository mensagemRepository)
        {
            _mensagemRepository = mensagemRepository;
        }

        public async Task<Mensagem> Handle(MensagemCreateCommand request, CancellationToken cancellationToken)
        {
            var mensagem = new Mensagem(
                request.Nome,
                request.Email,
                request.Texto
            );

            if (mensagem == null)
            {
                throw new ApplicationException($"Erro ao criar entidade.");
            }
            else
            {
                return await _mensagemRepository.CriarMensagemAsync(mensagem);
            }
        }
    }
}