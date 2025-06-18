using MediatR;
using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Application.CQRS.Produtos.Queries;

namespace InnatAPP.Application.CQRS.Produtos.Handlers
{
    public class GetProdutosByEmpresaQueryHandler : IRequestHandler<GetProdutosByEmpresaQuery, IEnumerable<Produto>>
    {
        private readonly IProdutoRepository _produtoRepository;
        public GetProdutosByEmpresaQueryHandler(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }
        public async Task<IEnumerable<Produto>> Handle(GetProdutosByEmpresaQuery request, CancellationToken cancellationToken)
        {
            return await _produtoRepository.BuscarProdutosPorEmpresaAsync(request.IdEmpresa);
        }
    }
}