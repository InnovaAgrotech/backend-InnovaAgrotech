using MediatR;
using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Application.CQRS.Mensagens.Queries;

namespace InnatAPP.Application.CQRS.Mensagens.Handlers
{
    public class GetMensagensQueryHandler : IRequestHandler<GetMensagensQuery, IEnumerable<Mensagem>>
    {
        private readonly IMensagemRepository _mensagemRepository;
        public GetMensagensQueryHandler(IMensagemRepository mensagemRepository)
        {
            _mensagemRepository = mensagemRepository;
        }
        public async Task<IEnumerable<Mensagem>> Handle(GetMensagensQuery request, CancellationToken cancellationToken)
        {
            return await _mensagemRepository.BuscarMensagensAsync();
        }
    }
}