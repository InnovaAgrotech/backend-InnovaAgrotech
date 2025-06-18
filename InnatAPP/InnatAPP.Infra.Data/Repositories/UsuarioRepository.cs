using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Infra.Data.Context;
using InnatAPP.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace InnatAPP.Infra.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext _usuarioContext;

        public UsuarioRepository(ApplicationDbContext context)
        {
            _usuarioContext = context;
        }

        #region Buscas

        public async Task<Usuario?> BuscarUsuarioPorIdAsync(Guid id)
            => await _usuarioContext.Usuarios
                                    .FirstOrDefaultAsync(u => u.Id == id);

        public async Task<Usuario?> BuscarUsuarioPorEmailAsync(string email)
            => await _usuarioContext.Usuarios
                                    .FirstOrDefaultAsync(u => u.Email == email);

        public async Task<Usuario?> BuscarUsuarioPorEmailESenhaAsync(string email, string senhaHash)
            => await _usuarioContext.Usuarios
                                    .FirstOrDefaultAsync(u => u.Email == email && u.SenhaHash == senhaHash);

        public async Task<IEnumerable<Usuario>> BuscarUsuariosAsync()
            => await _usuarioContext.Usuarios
                                    .AsNoTracking()
                                    .ToListAsync();

        public async Task<IEnumerable<Usuario>> BuscarUsuariosPorTipoAsync(TipoUsuario tipoUsuario)
            => await _usuarioContext.Usuarios
                                    .Where(u => u.TipoUsuario == tipoUsuario)
                                    .AsNoTracking()
                                    .ToListAsync();
        #endregion

        #region Comandos

        public async Task<Usuario> CriarUsuarioAsync(Usuario usuario)
        {
            _usuarioContext.Add(usuario);
            await _usuarioContext.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario> AtualizarUsuarioAsync(Usuario usuario)
        {
            _usuarioContext.Update(usuario);
            await _usuarioContext.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario> DeletarUsuarioAsync(Usuario usuario)
        {
            _usuarioContext.Remove(usuario);
            await _usuarioContext.SaveChangesAsync();
            return usuario;
        }

        #endregion
    }
}