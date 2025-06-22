using MediatR;
using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Application.CQRS.Empresas.Commands;

namespace InnatAPP.Application.CQRS.Empresas.Handlers
{
    public class EmpresaRemoveByUsuarioIdCommandHandler : IRequestHandler<EmpresaRemoveByUsuarioIdCommand, Empresa?>
    {
        private readonly IEmpresaRepository _empresaRepository;

        public EmpresaRemoveByUsuarioIdCommandHandler(IEmpresaRepository empresaRepository)
        {
            _empresaRepository = empresaRepository;
        }

        public async Task<Empresa?> Handle(EmpresaRemoveByUsuarioIdCommand request, CancellationToken cancellationToken)
        {
            var empresa = await _empresaRepository.BuscarEmpresaPorIdDeUsuarioAsync(request.IdUsuario);

            if (empresa == null)
                return null;

            await _empresaRepository.DeletarEmpresaAsync(empresa);
            return empresa;
        }
    }
}