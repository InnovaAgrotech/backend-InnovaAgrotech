using InnatAPP.Application.Produtos.Commands;
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
    public class ProdutoRemoveCommandHandler : IRequestHandler<ProdutoRemoveCommand, Produto>
    {
        private readonly IProdutoRepository _produtoRepository;
        public ProdutoRemoveCommandHandler(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository ??
                throw new ArgumentNullException(nameof(produtoRepository));
        }
        public async Task<Produto> Handle(ProdutoRemoveCommand request, CancellationToken cancellationToken)
        {
            var produto = await _produtoRepository.BuscarProdutoPorIdAsync(request.Id);

            if (produto == null)
            {
                throw new ApplicationException($"Entidade não pode ser encontrada.");
            }
            else
            {
                var result = await _produtoRepository.DeletarProdutoAsync(produto);
                return result;
            }
        }
    }
}
