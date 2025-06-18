using MediatR;
using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Application.CQRS.Avaliadores.Queries;

namespace InnatAPP.Application.CQRS.Avaliadores.Handlers
{
    public class GetAvaliadorByIdUsuarioQueryHandler : IRequestHandler<GetAvaliadorByIdUsuarioQuery, Avaliador?>
    {
        private readonly IAvaliadorRepository _avaliadorRepository;
        public GetAvaliadorByIdUsuarioQueryHandler(IAvaliadorRepository avaliadorRepository)
        {
            _avaliadorRepository = avaliadorRepository;
        }
        public async Task<Avaliador?> Handle(GetAvaliadorByIdUsuarioQuery request, CancellationToken cancellationToken)
        {
            return await _avaliadorRepository.BuscarAvaliadorPorIdDeUsuarioAsync(request.IdUsuario);
        }
    }
}