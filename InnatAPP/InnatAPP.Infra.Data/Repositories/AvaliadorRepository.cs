using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace InnatAPP.Infra.Data.Repositories
{
    public class AvaliadorRepository : IAvaliadorRepository
    {
        private ApplicationDbContext _avaliadorContext;

        public AvaliadorRepository (ApplicationDbContext context) 
        {
            _avaliadorContext = context;
        }
        public async Task<Avaliador> AtualizarAvaliadorAsync(Avaliador avaliador)
        {
            _avaliadorContext.Update(avaliador);
            await _avaliadorContext.SaveChangesAsync();
            return avaliador;
        }

        public async Task<IEnumerable<Avaliador>> BuscarAvaliadoresAsync()
        {
            return await _avaliadorContext.Avaliadores.ToListAsync();        
        }

        public async Task<Avaliador> BuscarAvaliadorPorIdAsync(int id)
        {
            return await _avaliadorContext.Avaliadores.FindAsync(id);
        }

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
    }
}