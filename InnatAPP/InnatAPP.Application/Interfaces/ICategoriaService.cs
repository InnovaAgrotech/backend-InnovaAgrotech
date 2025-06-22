using InnatAPP.Application.DTOs;

namespace InnatAPP.Application.Interfaces
{
    public interface ICategoriaService
    {
        #region Buscas

        Task<CategoriaDTO?> BuscarCategoriaPorIdAsync(Guid id);
        Task<IEnumerable<CategoriaDTO>> BuscarCategoriasAsync();

        #endregion

        #region Comandos

        Task CriarCategoriaAsync(CategoriaDTO categoriaDto);
        Task AtualizarCategoriaAsync(CategoriaDTO categoriaDto);
        Task DeletarCategoriaAsync(Guid id);

        #endregion
    }
}