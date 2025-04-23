using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace InnatAPP.Infra.Data.Repositories
{
    public class TelefoneAvaliadorRepository : ITelefoneAvaliadorRepository
    {
        private ApplicationDbContext _telefoneAvaliadorContext;

        public TelefoneAvaliadorRepository(ApplicationDbContext context)
        {
            _telefoneAvaliadorContext = context;
        }
        public async Task<TelefoneAvaliador> AtualizarTelefoneDeAvaliadorAsync(TelefoneAvaliador telefoneAvaliador)
        {
            _telefoneAvaliadorContext.Update(telefoneAvaliador);
            await _telefoneAvaliadorContext.SaveChangesAsync();
            return telefoneAvaliador;
        }

        public async Task<TelefoneAvaliador> BuscarTelefoneDeAvaliadorPorIdAsync(int id)
        {
            return await _telefoneAvaliadorContext.TelefonesAvaliador.FindAsync(id);
        }

        public async Task<IEnumerable<TelefoneAvaliador>> BuscarTelefonesDeAvaliadoresAsync()
        {
            return await _telefoneAvaliadorContext.TelefonesAvaliador.ToListAsync();
        }

        public async Task<IEnumerable<TelefoneAvaliador>> BuscarTelefonesPorAvaliadorAsync(int idAvaliador)
        {
            return await _telefoneAvaliadorContext.TelefonesAvaliador
                .Include(e => e.Avaliador)
                .Where(e => e.IdAvaliador == idAvaliador)
                .ToListAsync();
        }

        public async Task<TelefoneAvaliador> CriarTelefoneDeAvaliadorAsync(TelefoneAvaliador telefoneAvaliador)
        {
            _telefoneAvaliadorContext.Add(telefoneAvaliador);
            await _telefoneAvaliadorContext.SaveChangesAsync();
            return telefoneAvaliador;
        }

        public async Task<TelefoneAvaliador> DeletarTelefoneDeAvaliadorAsync(TelefoneAvaliador telefoneAvaliador)
        {
            _telefoneAvaliadorContext.Remove(telefoneAvaliador);
            await _telefoneAvaliadorContext.SaveChangesAsync();
            return telefoneAvaliador;
        }
    }
}