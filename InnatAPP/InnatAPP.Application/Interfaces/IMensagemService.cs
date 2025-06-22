using InnatAPP.Application.DTOs;

namespace InnatAPP.Application.Interfaces
{
    public interface IMensagemService
    {
        #region Buscas

        Task<MensagemDTO?> BuscarMensagemPorIdAsync(Guid id);
        Task<IEnumerable<MensagemDTO>> BuscarMensagensAsync();

        #endregion

        #region Comandos

        Task CriarMensagemAsync(MensagemDTO mensagemDto);

        #endregion
    }
}