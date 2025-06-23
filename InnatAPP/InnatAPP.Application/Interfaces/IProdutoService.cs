using InnatAPP.Application.DTOs.Produto;
using InnatAPP.Domain.Entities;

namespace InnatAPP.Application.Interfaces
{
    public interface IProdutoService
    {
        #region Buscas

        Task<ProdutoDTO?> BuscarProdutoPorIdAsync(Guid id);
        Task<IEnumerable<ProdutoDTO>> BuscarProdutosAsync();
        Task<IEnumerable<ProdutoDTO>> BuscarProdutosPorCategoriaAsync(Guid idCategoria);
        Task<IEnumerable<ProdutoDTO>> BuscarProdutosPorEmpresaAsync(Guid idEmpresa);

        #endregion

        #region Comandos

        Task<Produto> CriarProdutoAsync(ProdutoCreateDTO produtoDto);
        Task AtualizarProdutoAsync(ProdutoUpdateDTO produtoDto);
        Task DeletarProdutoAsync(Guid id);

        #endregion
    }
}