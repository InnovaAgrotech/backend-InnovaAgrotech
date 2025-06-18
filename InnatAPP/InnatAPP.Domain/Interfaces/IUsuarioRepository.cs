using InnatAPP.Domain.Entities;
using InnatAPP.Domain.ValueObjects;

namespace InnatAPP.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        #region Buscas

        Task<Usuario?> BuscarUsuarioPorIdAsync(Guid id);
        Task<Usuario?> BuscarUsuarioPorEmailAsync(string email);
        Task<Usuario?> BuscarUsuarioPorEmailESenhaAsync(string email, string senhaHash);
        Task<IEnumerable<Usuario>> BuscarUsuariosAsync();
        Task<IEnumerable<Usuario>> BuscarUsuariosPorTipoAsync(TipoUsuario tipoUsuario);

        #endregion

        #region Comandos

        Task<Usuario> CriarUsuarioAsync(Usuario usuario);
        Task<Usuario> AtualizarUsuarioAsync(Usuario usuario);
        Task<Usuario> DeletarUsuarioAsync(Usuario usuario);

        #endregion
    }
}