using MediatR;
using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Application.CQRS.Categorias.Queries;

namespace InnatAPP.Application.CQRS.Categorias.Handlers
{
    public class GetCategoriasQueryHandler : IRequestHandler<GetCategoriasQuery, IEnumerable<Categoria>>
    {
        private readonly ICategoriaRepository _categoriaRepository;
        public GetCategoriasQueryHandler(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }
        public async Task<IEnumerable<Categoria>> Handle(GetCategoriasQuery request, CancellationToken cancellationToken)
        {
            return await _categoriaRepository.BuscarCategoriasAsync();
        }
    }
}