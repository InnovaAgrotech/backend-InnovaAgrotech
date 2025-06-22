using MediatR;
using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Application.CQRS.Avaliadores.Commands;

namespace InnatAPP.Application.CQRS.Avaliadores.Handlers
{
    public class AvaliadorCreateCommandHandler : IRequestHandler<AvaliadorCreateCommand, Avaliador>
    {
        private readonly IAvaliadorRepository _avaliadorRepository;
        private readonly IEmpresaRepository _empresaRepository;

        public AvaliadorCreateCommandHandler(IAvaliadorRepository avaliadorRepository, IEmpresaRepository empresaRepository)
        {
            _avaliadorRepository = avaliadorRepository;
            _empresaRepository = empresaRepository;
        }

        public async Task<Avaliador> Handle(AvaliadorCreateCommand request, CancellationToken cancellationToken)
        {
            if (await _avaliadorRepository.ExistePorUsuarioId(request.IdUsuario))
                throw new ApplicationException("Este usuário já está registrado como Avaliador.");

            if (await _empresaRepository.ExistePorUsuarioId(request.IdUsuario))
                throw new ApplicationException("Este usuário já está registrado como Empresa e não pode ser Avaliador.");

            var avaliador = new Avaliador(
                request.IdUsuario
            );

            if (avaliador == null)
            {
                throw new ApplicationException($"Erro ao criar entidade.");
            }
            else
            {
                return await _avaliadorRepository.CriarAvaliadorAsync(avaliador);
            }
        }
    }
}