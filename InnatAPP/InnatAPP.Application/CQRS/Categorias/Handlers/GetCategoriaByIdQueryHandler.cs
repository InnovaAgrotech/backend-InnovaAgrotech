using MediatR;
using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Application.CQRS.Categorias.Queries;

namespace InnatAPP.Application.CQRS.Categorias.Handlers
{
    public class GetCategoriaByIdQueryHandler : IRequestHandler<GetCategoriaByIdQuery, Categoria?>
    {
        private readonly ICategoriaRepository _categoriaRepository;
        public GetCategoriaByIdQueryHandler(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }
        public async Task<Categoria?> Handle(GetCategoriaByIdQuery request, CancellationToken cancellationToken)
        {
            return await _categoriaRepository.BuscarCategoriaPorIdAsync(request.Id);
        }
    }
}