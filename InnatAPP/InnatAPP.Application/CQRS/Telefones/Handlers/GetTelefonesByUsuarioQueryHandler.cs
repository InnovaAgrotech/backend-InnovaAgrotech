using MediatR;
using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Application.CQRS.Telefones.Queries;

namespace InnatAPP.Application.CQRS.Telefones.Handlers
{
    public class GetTelefonesByUsuarioQueryHandler : IRequestHandler<GetTelefonesByUsuarioQuery, IEnumerable<Telefone>>
    {
        private readonly ITelefoneRepository _telefoneRepository;
        public GetTelefonesByUsuarioQueryHandler(ITelefoneRepository telefoneRepository)
        {
            _telefoneRepository = telefoneRepository;
        }
        public async Task<IEnumerable<Telefone>> Handle(GetTelefonesByUsuarioQuery request, CancellationToken cancellationToken)
        {
            return await _telefoneRepository.BuscarTelefonesPorUsuarioAsync(request.IdUsuario);
        }
    }
}