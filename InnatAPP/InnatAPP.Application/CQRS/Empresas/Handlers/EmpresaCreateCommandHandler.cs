using MediatR;
using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Application.CQRS.Empresas.Commands;

namespace InnatAPP.Application.CQRS.Empresas.Handlers
{
    public class EmpresaCreateCommandHandler : IRequestHandler<EmpresaCreateCommand, Empresa>
    {
        private readonly IEmpresaRepository _empresaRepository;
        private readonly IAvaliadorRepository _avaliadorRepository;

        public EmpresaCreateCommandHandler(IEmpresaRepository empresaRepository, IAvaliadorRepository avaliadorRepository)
        {
            _empresaRepository = empresaRepository;
            _avaliadorRepository = avaliadorRepository;
        }

        public async Task<Empresa> Handle(EmpresaCreateCommand request, CancellationToken cancellationToken)
        {
            if (await _empresaRepository.ExistePorUsuarioId(request.IdUsuario))
                throw new ApplicationException("Este usuário já está registrado como Empresa.");

            if (await _avaliadorRepository.ExistePorUsuarioId(request.IdUsuario))
                throw new ApplicationException("Este usuário já está registrado como Avaliador e não pode ser Empresa.");

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