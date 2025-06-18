using InnatAPP.Domain.Entities;

namespace InnatAPP.Domain.Interfaces
{
    public interface ICategoriaRepository
    {
        #region Buscas

        Task<Categoria?> BuscarCategoriaPorIdAsync(Guid id);
        Task<IEnumerable<Categoria>> BuscarCategoriasAsync();

        #endregion

        #region Comandos

        Task<Categoria> CriarCategoriaAsync(Categoria categoria);
        Task<Categoria> AtualizarCategoriaAsync(Categoria categoria);
        Task<Categoria> DeletarCategoriaAsync(Categoria categoria);

        #endregion
    }
}