using MediatR;
using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Application.CQRS.Empresas.Queries;

namespace InnatAPP.Application.CQRS.Empresas.Handlers
{
    public class GetEmpresaByEmailQueryHandler : IRequestHandler<GetEmpresaByEmailQuery, Empresa?>
    {
        private readonly IEmpresaRepository _empresaRepository;
        public GetEmpresaByEmailQueryHandler(IEmpresaRepository empresaRepository)
        {
            _empresaRepository = empresaRepository;
        }
        public async Task<Empresa?> Handle(GetEmpresaByEmailQuery request, CancellationToken cancellationToken)
        {
            return await _empresaRepository.BuscarEmpresaPorEmailAsync(request.Email);
        }
    }
}