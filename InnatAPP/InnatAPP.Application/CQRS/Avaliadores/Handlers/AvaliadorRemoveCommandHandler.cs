using MediatR;
using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Application.CQRS.Avaliadores.Commands;

namespace InnatAPP.Application.CQRS.Avaliadores.Handlers
{
    public class AvaliadorRemoveCommandHandler : IRequestHandler<AvaliadorRemoveCommand, Avaliador>
    {
        private readonly IAvaliadorRepository _avaliadorRepository;
        public AvaliadorRemoveCommandHandler(IAvaliadorRepository avaliadorRepository)
        {
            _avaliadorRepository = avaliadorRepository;
        }
        public async Task<Avaliador> Handle(AvaliadorRemoveCommand request, CancellationToken cancellationToken)
        {
            var avaliador = await _avaliadorRepository.BuscarAvaliadorPorIdAsync(request.Id);

            if (avaliador == null)
            {
                throw new ApplicationException($"Entidade não pode ser encontrada.");
            }
            else
            {
                var resultado = await _avaliadorRepository.DeletarAvaliadorAsync(avaliador);
                return resultado;
            }
        }
    }
}