using InnatAPP.Domain.Entities;

namespace InnatAPP.Domain.Interfaces
{
    public interface ITelefoneRepository
    {
        #region Buscas

        Task<Telefone?> BuscarTelefonePorIdAsync(Guid id);
        Task<IEnumerable<Telefone>> BuscarTelefonesAsync();
        Task<IEnumerable<Telefone>> BuscarTelefonesPorUsuarioAsync(Guid idUsuario);

        #endregion

        #region Comandos

        Task<Telefone> CriarTelefoneAsync(Telefone telefone);
        Task<Telefone> AtualizarTelefoneAsync(Telefone telefone);
        Task<Telefone> DeletarTelefoneAsync(Telefone telefone);

        #endregion
    }
}