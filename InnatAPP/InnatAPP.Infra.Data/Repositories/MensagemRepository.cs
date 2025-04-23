using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace InnatAPP.Infra.Data.Repositories
{
    public class MensagemRepository : IMensagemRepository
    {
        private ApplicationDbContext _mensagemContext;

        public MensagemRepository(ApplicationDbContext context)
        {
            _mensagemContext = context;
        }
        public async Task<Mensagem> AtualizarMensagemAsync(Mensagem mensagem)
        {
            _mensagemContext.Update(mensagem);
            await _mensagemContext.SaveChangesAsync();
            return mensagem;
        }

        public async Task<Mensagem> BuscarMensagemPorIdAsync(int id)
        {
            return await _mensagemContext.Mensagens.FindAsync(id);
        }

        public async Task<IEnumerable<Mensagem>> BuscarMensagensAsync()
        {
            return await _mensagemContext.Mensagens.ToListAsync();
        }

        public async Task<Mensagem> CriarMensagemAsync(Mensagem mensagem)
        {
            _mensagemContext.Add(mensagem);
            await _mensagemContext.SaveChangesAsync();
            return mensagem;
        }

        public async Task<Mensagem> DeletarMensagemAsync(Mensagem mensagem)
        {
            _mensagemContext.Remove(mensagem);
            await _mensagemContext.SaveChangesAsync();
            return mensagem;
        }
    }
}