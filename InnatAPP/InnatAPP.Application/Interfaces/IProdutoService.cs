using InnatAPP.Application.DTOs;

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

        Task CriarProdutoAsync(ProdutoDTO produtoDto);
        Task AtualizarProdutoAsync(ProdutoDTO produtoDto);
        Task DeletarProdutoAsync(Guid id);

        #endregion
    }
}