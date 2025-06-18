using MediatR;
using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Application.CQRS.Produtos.Queries;

namespace InnatAPP.Application.CQRS.Produtos.Handlers
{
    public class GetProdutosByCategoriaQueryHandler : IRequestHandler<GetProdutosByCategoriaQuery, IEnumerable<Produto>>
    {
        private readonly IProdutoRepository _produtoRepository;
        public GetProdutosByCategoriaQueryHandler(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }
        public async Task<IEnumerable<Produto>> Handle(GetProdutosByCategoriaQuery request, CancellationToken cancellationToken)
        {
            return await _produtoRepository.BuscarProdutosPorCategoriaAsync(request.IdCategoria);
        }
    }
}