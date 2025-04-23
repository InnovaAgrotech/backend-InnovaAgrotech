using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace InnatAPP.Infra.Data.Repositories
{
    public class EmailAlternativoEmpresaRepository : IEmailAlternativoEmpresaRepository
    {
        private ApplicationDbContext _emailAlternativoEmpresaContext;

        public EmailAlternativoEmpresaRepository(ApplicationDbContext context)
        {
            _emailAlternativoEmpresaContext = context;
        }
        public async Task<EmailAlternativoEmpresa> AtualizarEmailAlternativoEmpresaAsync(EmailAlternativoEmpresa emailAlternativoEmpresa)
        {
            _emailAlternativoEmpresaContext.Update(emailAlternativoEmpresa);
            await _emailAlternativoEmpresaContext.SaveChangesAsync();
            return emailAlternativoEmpresa;
        }

        public async Task<EmailAlternativoEmpresa> BuscarEmailAlternativoDeEmpresaPorIdAsync(int id)
        {
            return await _emailAlternativoEmpresaContext.EmailsAlternativosEmpresa.FindAsync(id);
        }

        public async Task<IEnumerable<EmailAlternativoEmpresa>> BuscarEmailsAlternativosDeEmpresasAsync()
        {
            return await _emailAlternativoEmpresaContext.EmailsAlternativosEmpresa.ToListAsync();
        }

        public async Task<IEnumerable<EmailAlternativoEmpresa>> BuscarEmailsAlternativosPorEmpresaAsync(int idEmpresa)
        {
            return await _emailAlternativoEmpresaContext.EmailsAlternativosEmpresa
                .Include(e => e.Empresa)
                .Where(e => e.IdEmpresa == idEmpresa)
                .ToListAsync();
        }

        public async Task<EmailAlternativoEmpresa> CriarEmailAlternativoEmpresaAsync(EmailAlternativoEmpresa emailAlternativoEmpresa)
        {
            _emailAlternativoEmpresaContext.Add(emailAlternativoEmpresa);
            await _emailAlternativoEmpresaContext.SaveChangesAsync();
            return emailAlternativoEmpresa;
        }

        public async Task<EmailAlternativoEmpresa> DeletarEmailAlternativoEmpresaAsync(EmailAlternativoEmpresa emailAlternativoEmpresa)
        {
            _emailAlternativoEmpresaContext.Remove(emailAlternativoEmpresa);
            await _emailAlternativoEmpresaContext.SaveChangesAsync();
            return emailAlternativoEmpresa;
        }
    }
}