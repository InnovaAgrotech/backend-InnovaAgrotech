using InnatAPP.Application.DTOs;

namespace InnatAPP.Application.Interfaces
{
    public interface ITelefoneService
    {
        #region Buscas

        Task<TelefoneDTO?> BuscarTelefonePorIdAsync(Guid id);
        Task<IEnumerable<TelefoneDTO>> BuscarTelefonesAsync();
        Task<IEnumerable<TelefoneDTO>> BuscarTelefonesPorUsuarioAsync(Guid idUsuario);

        #endregion

        #region Comandos

        Task CriarTelefoneAsync(TelefoneDTO telefoneDto);
        Task AtualizarTelefoneAsync(TelefoneDTO telefoneDto);
        Task DeletarTelefoneAsync(Guid id);

        #endregion
    }
}