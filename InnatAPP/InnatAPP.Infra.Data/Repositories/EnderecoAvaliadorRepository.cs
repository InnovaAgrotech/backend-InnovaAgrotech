using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace InnatAPP.Infra.Data.Repositories
{
    public class EnderecoAvaliadorRepository : IEnderecoAvaliadorRepository
    {
        private ApplicationDbContext _enderecoAvaliadorContext;

        public EnderecoAvaliadorRepository(ApplicationDbContext context)
        {
            _enderecoAvaliadorContext = context;
        }
        public async Task<EnderecoAvaliador> AtualizarEnderecoDeAvaliadorAsync(EnderecoAvaliador enderecoAvaliador)
        {
            _enderecoAvaliadorContext.Update(enderecoAvaliador);
            await _enderecoAvaliadorContext.SaveChangesAsync();
            return enderecoAvaliador;
        }

        public async Task<EnderecoAvaliador> BuscarEnderecoDeAvaliadorPorIdAsync(int id)
        {
            return await _enderecoAvaliadorContext.EnderecosAvaliador.FindAsync(id);
        }

        public async Task<IEnumerable<EnderecoAvaliador>> BuscarEnderecosDeAvaliadoresAsync()
        {
            return await _enderecoAvaliadorContext.EnderecosAvaliador.ToListAsync();
        }

        public async Task<IEnumerable<EnderecoAvaliador>> BuscarEnderecosPorAvaliadorAsync(int idAvaliador)
        {
            return await _enderecoAvaliadorContext.EnderecosAvaliador
                .Include(e => e.Avaliador)
                .Where(e => e.IdAvaliador == idAvaliador)
                .ToListAsync();
        }

        public async Task<EnderecoAvaliador> CriarEnderecoDeAvaliadorAsync(EnderecoAvaliador enderecoAvaliador)
        {
            _enderecoAvaliadorContext.Add(enderecoAvaliador);
            await _enderecoAvaliadorContext.SaveChangesAsync();
            return enderecoAvaliador;
        }

        public async Task<EnderecoAvaliador> DeletarEnderecoDeAvaliadorAsync(EnderecoAvaliador enderecoAvaliador)
        {
            _enderecoAvaliadorContext.Remove(enderecoAvaliador);
            await _enderecoAvaliadorContext.SaveChangesAsync();
            return enderecoAvaliador;
        }
    }
}