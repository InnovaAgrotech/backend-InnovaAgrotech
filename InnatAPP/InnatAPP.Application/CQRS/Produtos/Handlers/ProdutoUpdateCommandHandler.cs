using MediatR;
using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Application.CQRS.Produtos.Commands;

namespace InnatAPP.Application.CQRS.Produtos.Handlers
{
    public class ProdutoUpdateCommandHandler : IRequestHandler<ProdutoUpdateCommand, Produto>
    {
        private readonly IProdutoRepository _produtoRepository;
        public ProdutoUpdateCommandHandler(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }
        public async Task<Produto> Handle(ProdutoUpdateCommand request, CancellationToken cancellationToken)
        {
            var produto = await _produtoRepository.BuscarProdutoPorIdAsync(request.Id);

            if (produto == null)
            {
                throw new ApplicationException($"Entidade não pode ser encontrada.");
            }
            else
            {
                produto.Alterar(request.Nome, request.Descricao, request.Foto, request.IdCategoria);
                return await _produtoRepository.AtualizarProdutoAsync(produto);
            }
        }
    }
}