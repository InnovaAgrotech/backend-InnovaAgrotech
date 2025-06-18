using InnatAPP.Domain.Entities;

namespace InnatAPP.Domain.Interfaces
{
    public interface IMensagemRepository
    {
        #region Buscas

        Task<Mensagem?> BuscarMensagemPorIdAsync(Guid id);
        Task<IEnumerable<Mensagem>> BuscarMensagensAsync();

        #endregion

        #region Comandos

        Task<Mensagem> CriarMensagemAsync(Mensagem mensagem);

        #endregion
    }
}