using InnatAPP.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InnatAPP.Domain.Interfaces
{
    public interface ICategoriaRepository
    {
        Task<IEnumerable<Categoria>> BuscarCategoriasAsync();
        Task<Categoria> BuscarPorIdAsync(int? id);

        Task<Categoria> AdicionarAsync(Categoria categoria);

        Task<Categoria> AtualizarAsync(Categoria categoria);

        Task<Categoria> RemoverAsync(Categoria categoria);
    }
}
