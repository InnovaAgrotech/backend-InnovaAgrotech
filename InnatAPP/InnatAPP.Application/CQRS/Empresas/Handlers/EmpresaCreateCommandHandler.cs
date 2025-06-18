using MediatR;
using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Application.CQRS.Empresas.Commands;

namespace InnatAPP.Application.CQRS.Empresas.Handlers
{
    public class EmpresaCreateCommandHandler : IRequestHandler<EmpresaCreateCommand, Empresa>
    {
        private readonly IEmpresaRepository _empresaRepository;

        public EmpresaCreateCommandHandler(IEmpresaRepository empresaRepository)
        {
            _empresaRepository = empresaRepository;
        }

        public async Task<Empresa> Handle(EmpresaCreateCommand request, CancellationToken cancellationToken)
        {
            var empresa = new Empresa(
                request.IdUsuario
            );

            if (empresa == null)
            {
                throw new ApplicationException($"Erro ao criar entidade.");
            }
            else
            {
                return await _empresaRepository.CriarEmpresaAsync(empresa);
            }
        }
    }
}