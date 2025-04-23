using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace InnatAPP.Infra.Data.Repositories
{
    public class EmailAlternativoAvaliadorRepository : IEmailAlternativoAvaliadorRepository
    {
        private ApplicationDbContext _emailAlternativoAvaliadorContext;

        public EmailAlternativoAvaliadorRepository(ApplicationDbContext context)
        {
            _emailAlternativoAvaliadorContext = context;
        }
        public async Task<EmailAlternativoAvaliador> AtualizarEmailAlternativoDeAvaliadorAsync(EmailAlternativoAvaliador emailAlternativoAvaliador)
        {
            _emailAlternativoAvaliadorContext.Update(emailAlternativoAvaliador);
            await _emailAlternativoAvaliadorContext.SaveChangesAsync();
            return emailAlternativoAvaliador;
        }

        public async Task<EmailAlternativoAvaliador> BuscarEmailAlternativoDeAvaliadorPorIdAsync(int id)
        {
            return await _emailAlternativoAvaliadorContext.EmailsAlternativosAvaliador.FindAsync(id);
        }

        public async Task<IEnumerable<EmailAlternativoAvaliador>> BuscarEmailsAlternativosDeAvaliadoresAsync()
        {
            return await _emailAlternativoAvaliadorContext.EmailsAlternativosAvaliador.ToListAsync();
        }

        public async Task<IEnumerable<EmailAlternativoAvaliador>> BuscarEmailsAlternativosPorAvaliadorAsync(int idAvaliador)
        {
            return await _emailAlternativoAvaliadorContext.EmailsAlternativosAvaliador
                .Include(e => e.Avaliador)
                .Where(e => e.IdAvaliador == idAvaliador)
                .ToListAsync();
        }

        public async Task<EmailAlternativoAvaliador> CriarEmailAlternativoDeAvaliadorAsync(EmailAlternativoAvaliador emailAlternativoAvaliador)
        {
            _emailAlternativoAvaliadorContext.Add(emailAlternativoAvaliador);
            await _emailAlternativoAvaliadorContext.SaveChangesAsync();
            return emailAlternativoAvaliador;
        }

        public async Task<EmailAlternativoAvaliador> DeletarEmailAlternativoDeAvaliadorAsync(EmailAlternativoAvaliador emailAlternativoAvaliador)
        {
            _emailAlternativoAvaliadorContext.Remove(emailAlternativoAvaliador);
            await _emailAlternativoAvaliadorContext.SaveChangesAsync();
            return emailAlternativoAvaliador;
        }
    }
}