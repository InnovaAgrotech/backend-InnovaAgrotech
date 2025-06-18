using MediatR;
using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Application.CQRS.Avaliadores.Queries;

namespace InnatAPP.Application.CQRS.Avaliadores.Handlers
{
    public class GetAvaliadoresQueryHandler : IRequestHandler<GetAvaliadoresQuery, IEnumerable<Avaliador>>
    {
        private readonly IAvaliadorRepository _avaliadorRepository;
        public GetAvaliadoresQueryHandler(IAvaliadorRepository avaliadorRepository)
        {
            _avaliadorRepository = avaliadorRepository;
        }
        public async Task<IEnumerable<Avaliador>> Handle(GetAvaliadoresQuery request, CancellationToken cancellationToken)
        {
            return await _avaliadorRepository.BuscarAvaliadoresAsync();
        }
    }
}