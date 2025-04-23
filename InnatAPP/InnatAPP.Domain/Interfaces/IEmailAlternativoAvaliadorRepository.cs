using System.Threading.Tasks;
using InnatAPP.Domain.Entities;
using System.Collections.Generic;

namespace InnatAPP.Domain.Interfaces
{
    public interface IEmailAlternativoAvaliadorRepository
    {
        Task<EmailAlternativoAvaliador> BuscarEmailAlternativoDeAvaliadorPorIdAsync(int id);
        Task<IEnumerable<EmailAlternativoAvaliador>> BuscarEmailsAlternativosDeAvaliadoresAsync();
        Task<IEnumerable<EmailAlternativoAvaliador>> BuscarEmailsAlternativosPorAvaliadorAsync(int idAvaliador);

        Task<EmailAlternativoAvaliador> CriarEmailAlternativoDeAvaliadorAsync(EmailAlternativoAvaliador emailAlternativoAvaliador);
        Task<EmailAlternativoAvaliador> AtualizarEmailAlternativoDeAvaliadorAsync(EmailAlternativoAvaliador emailAlternativoAvaliador);
        Task<EmailAlternativoAvaliador> DeletarEmailAlternativoDeAvaliadorAsync(EmailAlternativoAvaliador emailAlternativoAvaliador);
    }
}
