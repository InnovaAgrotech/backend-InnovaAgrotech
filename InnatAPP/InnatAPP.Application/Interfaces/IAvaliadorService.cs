using InnatAPP.Application.DTOs;

namespace InnatAPP.Application.Interfaces
{
    public interface IAvaliadorService
    {
        #region Buscas

        Task<AvaliadorDTO?> BuscarAvaliadorPorIdAsync(Guid id);
        Task<AvaliadorDTO?> BuscarAvaliadorPorIdDeUsuarioAsync(Guid idUsuario);
        Task<AvaliadorDTO?> BuscarAvaliadorPorEmailAsync(string email);
        Task<IEnumerable<AvaliadorDTO>> BuscarAvaliadoresAsync();

        #endregion

        #region Comandos

        Task CriarAvaliadorAsync(AvaliadorDTO avaliadorDto);
        Task DeletarAvaliadorAsync(Guid id);

        #endregion
    }
}