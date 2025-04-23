using System.Threading.Tasks;
using InnatAPP.Domain.Entities;
using System.Collections.Generic;

namespace InnatAPP.Domain.Interfaces
{
    public interface ICategoriaRepository
    {
        Task<IEnumerable<Categoria>> BuscarCategoriasAsync();
        Task<Categoria> BuscarCategoriaPorIdAsync(int id);

        Task<Categoria> CriarCategoriaAsync(Categoria categoria);
        Task<Categoria> AtualizarCategoriaAsync(Categoria categoria);
        Task<Categoria> DeletarCategoriaAsync(Categoria categoria);
    }
}
