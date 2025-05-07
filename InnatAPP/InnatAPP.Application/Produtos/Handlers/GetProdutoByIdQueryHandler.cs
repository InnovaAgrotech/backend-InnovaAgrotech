using InnatAPP.Application.Produtos.Queries;
using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnatAPP.Application.Produtos.Handlers
{
    public class GetProdutoByIdQueryHandler : IRequestHandler<GetProdutoByIdQuery, Produto>
    {
        private readonly IProdutoRepository _produtoRepository;
        public GetProdutoByIdQueryHandler(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }
        public async Task<Produto> Handle(GetProdutoByIdQuery request, CancellationToken cancellationToken)
        {
            return await _produtoRepository.BuscarProdutoPorIdAsync(request.Id);
        }
    }
}
