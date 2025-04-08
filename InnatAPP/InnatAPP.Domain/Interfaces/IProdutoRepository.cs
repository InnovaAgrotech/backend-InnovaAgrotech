using InnatAPP.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InnatAPP.Domain.Interfaces
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<Produto>> BuscarProdutosAsync();
        Task<Produto> BuscarPorIdAsync(int? id);

        Task<Produto> BuscarProdutoCategoriaAsync(int? id);

        Task<Produto> AdicionarAsync(Produto produto);

        Task<Produto> AtualizarAsync(Produto produto);

        Task<Produto> RemoverAsync(Produto produto);
    }
}
