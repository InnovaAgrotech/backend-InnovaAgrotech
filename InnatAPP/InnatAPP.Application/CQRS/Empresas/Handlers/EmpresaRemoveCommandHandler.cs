using MediatR;
using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Application.CQRS.Empresas.Commands;

namespace InnatAPP.Application.CQRS.Empresas.Handlers
{
    public class EmpresaRemoveCommandHandler : IRequestHandler<EmpresaRemoveCommand, Empresa>
    {
        private readonly IEmpresaRepository _empresaRepository;
        public EmpresaRemoveCommandHandler(IEmpresaRepository empresaRepository)
        {
            _empresaRepository = empresaRepository;
        }
        public async Task<Empresa> Handle(EmpresaRemoveCommand request, CancellationToken cancellationToken)
        {
            var empresa = await _empresaRepository.BuscarEmpresaPorIdAsync(request.Id);

            if (empresa == null)
            {
                throw new ApplicationException($"Entidade não pode ser encontrada.");
            }
            else
            {
                var resultado = await _empresaRepository.DeletarEmpresaAsync(empresa);
                return resultado;
            }
        }
    }
}