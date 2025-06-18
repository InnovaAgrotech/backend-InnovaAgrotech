using MediatR;
using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Application.CQRS.Empresas.Queries;

namespace InnatAPP.Application.CQRS.Empresas.Handlers
{
    public class GetEmpresasQueryHandler : IRequestHandler<GetEmpresasQuery, IEnumerable<Empresa>>
    {
        private readonly IEmpresaRepository _empresaRepository;
        public GetEmpresasQueryHandler(IEmpresaRepository empresaRepository)
        {
            _empresaRepository = empresaRepository;
        }
        public async Task<IEnumerable<Empresa>> Handle(GetEmpresasQuery request, CancellationToken cancellationToken)
        {
            return await _empresaRepository.BuscarEmpresasAsync();
        }
    }
}