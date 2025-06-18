using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace InnatAPP.Infra.Data.Repositories
{
    public class AvaliadorRepository : IAvaliadorRepository
    {
        private readonly ApplicationDbContext _avaliadorContext;

        public AvaliadorRepository(ApplicationDbContext context)
        {
            _avaliadorContext = context;
        }

        #region Buscas

        public async Task<Avaliador?> BuscarAvaliadorPorIdAsync(Guid id)
            => await _avaliadorContext.Avaliadores
                                      .Include(a => a.Reviews)
                                      .FirstOrDefaultAsync(a => a.Id == id);
        public async Task<Avaliador?> BuscarAvaliadorPorIdDeUsuarioAsync(Guid idUsuario)
            => await _avaliadorContext.Avaliadores
                                      .Include(a => a.Reviews)
                                      .FirstOrDefaultAsync(a => a.IdUsuario == idUsuario);
        public async Task<Avaliador?> BuscarAvaliadorPorEmailAsync(string email)
            => await _avaliadorContext.Avaliadores
                                      .Include(a => a.Usuario)
                                      .FirstOrDefaultAsync(a => a.Usuario.Email == email);
        public async Task<IEnumerable<Avaliador>> BuscarAvaliadoresAsync()
            => await _avaliadorContext.Avaliadores
                                      .Include(a => a.Usuario)
                                      .AsNoTracking()
                                      .ToListAsync();
        #endregion

        #region Comandos

        public async Task<Avaliador> CriarAvaliadorAsync(Avaliador avaliador)
        {
            _avaliadorContext.Add(avaliador);
            await _avaliadorContext.SaveChangesAsync();
            return avaliador;
        }

        public async Task<Avaliador> DeletarAvaliadorAsync(Avaliador avaliador)
        {
            _avaliadorContext.Remove(avaliador);
            await _avaliadorContext.SaveChangesAsync();
            return avaliador;
        }

        #endregion

        #region Verificação de Id de Usuário

        public async Task<bool> ExistePorUsuarioId(Guid idUsuario)
            => await _avaliadorContext.Avaliadores.AnyAsync(a => a.IdUsuario == idUsuario);

        #endregion
    }

}