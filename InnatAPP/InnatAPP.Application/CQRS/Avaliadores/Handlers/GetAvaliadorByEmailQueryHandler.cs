using MediatR;
using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Application.CQRS.Avaliadores.Queries;

namespace InnatAPP.Application.CQRS.Avaliadores.Handlers
{
    public class GetAvaliadorByEmailQueryHandler : IRequestHandler<GetAvaliadorByEmailQuery, Avaliador?>
    {
        private readonly IAvaliadorRepository _avaliadorRepository;
        public GetAvaliadorByEmailQueryHandler(IAvaliadorRepository avaliadorRepository)
        {
            _avaliadorRepository = avaliadorRepository;
        }
        public async Task<Avaliador?> Handle(GetAvaliadorByEmailQuery request, CancellationToken cancellationToken)
        {
            return await _avaliadorRepository.BuscarAvaliadorPorEmailAsync(request.Email);
        }
    }
}