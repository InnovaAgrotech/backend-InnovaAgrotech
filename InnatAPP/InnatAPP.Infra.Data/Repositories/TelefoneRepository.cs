using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace InnatAPP.Infra.Data.Repositories
{
    public class TelefoneRepository : ITelefoneRepository
    {
        private readonly ApplicationDbContext _telefoneContext;

        public TelefoneRepository(ApplicationDbContext context)
        {
            _telefoneContext = context;
        }

        public async Task<Telefone?> BuscarTelefonePorIdAsync(Guid id)
        {
            return await _telefoneContext.Telefones.FindAsync(id);
        }

        public async Task<IEnumerable<Telefone>> BuscarTelefonesAsync()
        {
            return await _telefoneContext.Telefones.ToListAsync();
        }

        public async Task<IEnumerable<Telefone>> BuscarTelefonesPorUsuarioAsync(Guid idUsuario)
        {
            return await _telefoneContext.Telefones
                .Include(t => t.Usuario)
                .Where(t => t.IdUsuario == idUsuario)
                .ToListAsync();
        }

        #region Buscas

        #endregion

        #region Comandos

        public async Task<Telefone> CriarTelefoneAsync(Telefone telefone)
        {
            _telefoneContext.Add(telefone);
            await _telefoneContext.SaveChangesAsync();
            return telefone;
        }

        public async Task<Telefone> AtualizarTelefoneAsync(Telefone telefone)
        {
            _telefoneContext.Update(telefone);
            await _telefoneContext.SaveChangesAsync();
            return telefone;
        }

        public async Task<Telefone> DeletarTelefoneAsync(Telefone telefone)
        {
            _telefoneContext.Remove(telefone);
            await _telefoneContext.SaveChangesAsync();
            return telefone;
        }

        #endregion
    }
}