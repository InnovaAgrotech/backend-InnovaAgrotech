using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace InnatAPP.Infra.Data.Repositories
{
    public class MensagemRepository : IMensagemRepository
    {
        private readonly ApplicationDbContext _mensagemContext;

        public MensagemRepository(ApplicationDbContext context)
        {
            _mensagemContext = context;
        }

        #region Buscas

        public async Task<Mensagem?> BuscarMensagemPorIdAsync(Guid id)
        {
            return await _mensagemContext.Mensagens.FindAsync(id);
        }

        public async Task<IEnumerable<Mensagem>> BuscarMensagensAsync()
        {
            return await _mensagemContext.Mensagens.ToListAsync();
        }

        #endregion

        #region Comandos

        public async Task<Mensagem> CriarMensagemAsync(Mensagem mensagem)
        {
            _mensagemContext.Add(mensagem);
            await _mensagemContext.SaveChangesAsync();
            return mensagem;
        }

        #endregion
    }
}