using MediatR;
using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Application.CQRS.Empresas.Queries;

namespace InnatAPP.Application.CQRS.Empresas.Handlers
{
    public class GetEmpresaByIdUsuarioQueryHandler : IRequestHandler<GetEmpresaByIdUsuarioQuery, Empresa?>
    {
        private readonly IEmpresaRepository _empresaRepository;
        public GetEmpresaByIdUsuarioQueryHandler(IEmpresaRepository empresaRepository)
        {
            _empresaRepository = empresaRepository;
        }
        public async Task<Empresa?> Handle(GetEmpresaByIdUsuarioQuery request, CancellationToken cancellationToken)
        {
            return await _empresaRepository.BuscarEmpresaPorIdDeUsuarioAsync(request.IdUsuario);
        }
    }
}