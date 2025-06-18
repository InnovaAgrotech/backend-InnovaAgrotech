using MediatR;
using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Application.CQRS.Avaliadores.Commands;

namespace InnatAPP.Application.CQRS.Avaliadores.Handlers
{
    public class AvaliadorCreateCommandHandler : IRequestHandler<AvaliadorCreateCommand, Avaliador>
    {
        private readonly IAvaliadorRepository _avaliadorRepository;

        public AvaliadorCreateCommandHandler(IAvaliadorRepository avaliadorRepository)
        {
            _avaliadorRepository = avaliadorRepository;
        }

        public async Task<Avaliador> Handle(AvaliadorCreateCommand request, CancellationToken cancellationToken)
        {
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