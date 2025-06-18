using MediatR;
using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Application.CQRS.Produtos.Commands;

namespace InnatAPP.Application.CQRS.Produtos.Handlers
{
    public class ProdutoRemoveCommandHandler : IRequestHandler<ProdutoRemoveCommand, Produto>
    {
        private readonly IProdutoRepository _produtoRepository;
        public ProdutoRemoveCommandHandler(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
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
                var resultado = await _produtoRepository.DeletarProdutoAsync(produto);
                return resultado;
            }
        }
    }
}