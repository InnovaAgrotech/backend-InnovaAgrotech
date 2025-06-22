using MediatR;
using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Application.CQRS.Telefones.Queries;

namespace InnatAPP.Application.CQRS.Telefones.Handlers
{
    public class GetTelefonesQueryHandler : IRequestHandler<GetTelefonesQuery, IEnumerable<Telefone>>
    {
        private readonly ITelefoneRepository _telefoneRepository;
        public GetTelefonesQueryHandler(ITelefoneRepository telefoneRepository)
        {
            _telefoneRepository = telefoneRepository;
        }
        public async Task<IEnumerable<Telefone>> Handle(GetTelefonesQuery request, CancellationToken cancellationToken)
        {
            return await _telefoneRepository.BuscarTelefonesAsync();
        }
    }
}