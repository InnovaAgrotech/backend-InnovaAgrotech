using InnatAPP.Application.DTOs;

namespace InnatAPP.Application.Interfaces
{
    public interface IProdutoService
    {
        Task<ProdutoDTO> BuscarProdutoPorIdAsync(int id);
        Task<IEnumerable<ProdutoDTO>> BuscarProdutosAsync();
        Task<IEnumerable<ProdutoDTO>> BuscarProdutosPorCategoriaAsync(int idCategoria);
        Task<IEnumerable<ProdutoDTO>> BuscarProdutosPorEmpresaAsync(int idEmpresa);

        Task CriarProdutoAsync(ProdutoDTO produtoDto);
        Task AtualizarProdutoAsync(ProdutoDTO produtoDto);
        Task DeletarProdutoAsync(int id);
    }
}