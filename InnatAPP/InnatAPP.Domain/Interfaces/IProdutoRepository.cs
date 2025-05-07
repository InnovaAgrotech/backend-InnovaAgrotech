using InnatAPP.Domain.Entities;

namespace InnatAPP.Domain.Interfaces
{
    public interface IProdutoRepository
    {
        Task<Produto> BuscarProdutoPorIdAsync(int id);
        Task<IEnumerable<Produto>> BuscarProdutosAsync();
        Task<IEnumerable<Produto>> BuscarProdutosPorCategoriaAsync(int idCategoria);
        Task<IEnumerable<Produto>> BuscarProdutosPorEmpresaAsync(int idEmpresa);

        Task<Produto> CriarProdutoAsync(Produto produto);
        Task<Produto> AtualizarProdutoAsync(Produto produto);
        Task<Produto> DeletarProdutoAsync(Produto produto);
    }
}
