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
    public class GetProdutosPorCategoriaQueryHandler : IRequestHandler<GetProdutosPorCategoriaQuery, IEnumerable<Produto>>
    {
        private readonly IProdutoRepository _produtoRepository;
        public GetProdutosPorCategoriaQueryHandler(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<IEnumerable<Produto>> Handle(GetProdutosPorCategoriaQuery request, CancellationToken cancellationToken)
        {
            return await _produtoRepository.BuscarProdutosPorCategoriaAsync(request.IdCategoria);
        }
    }
}
