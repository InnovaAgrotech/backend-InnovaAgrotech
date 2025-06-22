using MediatR;
using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Application.CQRS.Avaliadores.Commands;

namespace InnatAPP.Application.CQRS.Avaliadores.Handlers
{
    public class AvaliadorRemoveByUsuarioIdCommandHandler : IRequestHandler<AvaliadorRemoveByUsuarioIdCommand, Avaliador?>
    {
        private readonly IAvaliadorRepository _avaliadorRepository;

        public AvaliadorRemoveByUsuarioIdCommandHandler(IAvaliadorRepository avaliadorRepository)
        {
            _avaliadorRepository = avaliadorRepository;
        }

        public async Task<Avaliador?> Handle(AvaliadorRemoveByUsuarioIdCommand request, CancellationToken cancellationToken)
        {
            var avaliador = await _avaliadorRepository.BuscarAvaliadorPorIdDeUsuarioAsync(request.IdUsuario);

            if (avaliador == null)
                return null;

            await _avaliadorRepository.DeletarAvaliadorAsync(avaliador);
            return avaliador;
        }
    }
}
