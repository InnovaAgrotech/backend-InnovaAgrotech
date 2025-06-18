using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace InnatAPP.Infra.Data.Repositories
{
    public class EmailAlternativoRepository : IEmailAlternativoRepository
    {
        private readonly ApplicationDbContext _emailAlternativoContext;

        public EmailAlternativoRepository(ApplicationDbContext context)
        {
            _emailAlternativoContext = context;
        }

        #region Buscas

        public async Task<EmailAlternativo?> BuscarEmailAlternativoPorIdAsync(Guid id)
        {
            return await _emailAlternativoContext.EmailsAlternativos.FindAsync(id);
        }

        public async Task<IEnumerable<EmailAlternativo>> BuscarEmailsAlternativosAsync()
        {
            return await _emailAlternativoContext.EmailsAlternativos.ToListAsync();
        }

        public async Task<IEnumerable<EmailAlternativo>> BuscarEmailsAlternativosPorUsuarioAsync(Guid idUsuario)
        {
            return await _emailAlternativoContext.EmailsAlternativos
                .Include(e => e.Usuario)
                .Where(e => e.IdUsuario == idUsuario)
                .ToListAsync();
        }

        #endregion

        #region Comandos

        public async Task<EmailAlternativo> CriarEmailAlternativoAsync(EmailAlternativo emailAlternativo)
        {
            _emailAlternativoContext.Add(emailAlternativo);
            await _emailAlternativoContext.SaveChangesAsync();
            return emailAlternativo;
        }

        public async Task<EmailAlternativo> AtualizarEmailAlternativoAsync(EmailAlternativo emailAlternativo)
        {
            _emailAlternativoContext.Update(emailAlternativo);
            await _emailAlternativoContext.SaveChangesAsync();
            return emailAlternativo;
        }

        public async Task<EmailAlternativo> DeletarEmailAlternativoAsync(EmailAlternativo emailAlternativo)
        {
            _emailAlternativoContext.Remove(emailAlternativo);
            await _emailAlternativoContext.SaveChangesAsync();
            return emailAlternativo;
        }

        #endregion
    }
}