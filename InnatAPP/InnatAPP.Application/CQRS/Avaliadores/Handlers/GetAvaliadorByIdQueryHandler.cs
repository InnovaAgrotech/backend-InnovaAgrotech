using MediatR;
using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Application.CQRS.Avaliadores.Queries;

namespace InnatAPP.Application.CQRS.Avaliadores.Handlers
{
    public class GetAvaliadorByIdQueryHandler : IRequestHandler<GetAvaliadorByIdQuery, Avaliador?>
    {
        private readonly IAvaliadorRepository _avaliadorRepository;
        public GetAvaliadorByIdQueryHandler(IAvaliadorRepository avaliadorRepository)
        {
            _avaliadorRepository = avaliadorRepository;
        }
        public async Task<Avaliador?> Handle(GetAvaliadorByIdQuery request, CancellationToken cancellationToken)
        {
            return await _avaliadorRepository.BuscarAvaliadorPorIdAsync(request.Id);
        }
    }
}