using MediatR;
using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Application.CQRS.Produtos.Queries;

namespace InnatAPP.Application.CQRS.Produtos.Handlers
{
    public class GetProdutoByIdQueryHandler : IRequestHandler<GetProdutoByIdQuery, Produto?>
    {
        private readonly IProdutoRepository _produtoRepository;
        public GetProdutoByIdQueryHandler(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }
        public async Task<Produto?> Handle(GetProdutoByIdQuery request, CancellationToken cancellationToken)
        {
            return await _produtoRepository.BuscarProdutoPorIdAsync(request.Id);
        }
    }
}