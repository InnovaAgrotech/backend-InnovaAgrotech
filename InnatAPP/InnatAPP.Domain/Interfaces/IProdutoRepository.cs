using InnatAPP.Domain.Entities;

namespace InnatAPP.Domain.Interfaces
{
    public interface IProdutoRepository
    {
        #region Buscas

        Task<Produto?> BuscarProdutoPorIdAsync(Guid id);
        Task<IEnumerable<Produto>> BuscarProdutosAsync();
        Task<IEnumerable<Produto>> BuscarProdutosPorCategoriaAsync(Guid idCategoria);
        Task<IEnumerable<Produto>> BuscarProdutosPorEmpresaAsync(Guid idEmpresa);

        #endregion

        #region Comandos

        Task<Produto> CriarProdutoAsync(Produto produto);
        Task<Produto> AtualizarProdutoAsync(Produto produto);
        Task<Produto> DeletarProdutoAsync(Produto produto);

        #endregion
    }
}