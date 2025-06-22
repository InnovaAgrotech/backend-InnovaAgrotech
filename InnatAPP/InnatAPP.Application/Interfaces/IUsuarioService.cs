using InnatAPP.Application.DTOs.Usuario;
using InnatAPP.Domain.Entities;
using InnatAPP.Domain.ValueObjects;

namespace InnatAPP.Application.Interfaces
{
    public interface IUsuarioService
    {
        #region Buscas

        Task<UsuarioRespostaDTO?> BuscarUsuarioPorIdAsync(Guid id);
        Task<UsuarioRespostaDTO?> BuscarUsuarioPorEmailAsync(string email);
        Task<UsuarioRespostaDTO?> BuscarUsuarioPorEmailESenhaAsync(LoginUsuarioDTO loginDto);
        Task<IEnumerable<UsuarioRespostaDTO>> BuscarUsuariosAsync();
        Task<IEnumerable<UsuarioRespostaDTO>> BuscarUsuariosPorTipoAsync(TipoUsuario tipoUsuario);

        #endregion

        #region Comandos

        Task<Usuario> CriarUsuarioAsync(UsuarioCreateDTO usuarioDto);
        Task AtualizarUsuarioAsync(UsuarioUpdateDTO usuarioDto);
        Task DeletarUsuarioAsync(Guid id);

        #endregion
    }
}