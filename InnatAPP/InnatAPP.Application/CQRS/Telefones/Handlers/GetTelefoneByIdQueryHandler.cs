using MediatR;
using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Application.CQRS.Telefones.Queries;

namespace InnatAPP.Application.CQRS.Telefones.Handlers
{
    public class GetTelefoneByIdQueryHandler : IRequestHandler<GetTelefoneByIdQuery, Telefone?>
    {
        private readonly ITelefoneRepository _telefoneRepository;
        public GetTelefoneByIdQueryHandler(ITelefoneRepository telefoneRepository)
        {
            _telefoneRepository = telefoneRepository;
        }
        public async Task<Telefone?> Handle(GetTelefoneByIdQuery request, CancellationToken cancellationToken)
        {
            return await _telefoneRepository.BuscarTelefonePorIdAsync(request.Id);
        }
    }
}