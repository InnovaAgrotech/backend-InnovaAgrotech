using InnatAPP.Domain.Entities;

namespace InnatAPP.Domain.Interfaces
{
    public interface IAvaliadorRepository
    {
        #region Buscas

        Task<Avaliador?> BuscarAvaliadorPorIdAsync(Guid id);
        Task<Avaliador?> BuscarAvaliadorPorIdDeUsuarioAsync(Guid idUsuario);
        Task<Avaliador?> BuscarAvaliadorPorEmailAsync(string email);
        Task<IEnumerable<Avaliador>> BuscarAvaliadoresAsync();

        #endregion

        #region Comandos

        Task<Avaliador> CriarAvaliadorAsync(Avaliador avaliador);
        Task<Avaliador> DeletarAvaliadorAsync(Avaliador avaliador);

        #endregion

        #region Verificação de Id de Usuario

        Task<bool> ExistePorUsuarioId(Guid idUsuario);

        #endregion
    }
}