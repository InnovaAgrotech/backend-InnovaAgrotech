using MediatR;
using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Application.CQRS.Mensagens.Queries;

namespace InnatAPP.Application.CQRS.Mensagens.Handlers
{
    public class GetMensagemByIdQueryHandler : IRequestHandler<GetMensagemByIdQuery, Mensagem?>
    {
        private readonly IMensagemRepository _mensagemRepository;
        public GetMensagemByIdQueryHandler(IMensagemRepository mensagemRepository)
        {
            _mensagemRepository = mensagemRepository;
        }
        public async Task<Mensagem?> Handle(GetMensagemByIdQuery request, CancellationToken cancellationToken)
        {
            return await _mensagemRepository.BuscarMensagemPorIdAsync(request.Id);
        }
    }
}