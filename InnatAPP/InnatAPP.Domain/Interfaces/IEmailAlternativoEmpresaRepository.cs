using System.Threading.Tasks;
using InnatAPP.Domain.Entities;
using System.Collections.Generic;

namespace InnatAPP.Domain.Interfaces
{
    public interface IEmailAlternativoEmpresaRepository
    {
        Task<EmailAlternativoEmpresa> BuscarEmailAlternativoDeEmpresaPorIdAsync(int id);
        Task<IEnumerable<EmailAlternativoEmpresa>> BuscarEmailsAlternativosDeEmpresasAsync();
        Task<IEnumerable<EmailAlternativoEmpresa>> BuscarEmailsAlternativosPorEmpresaAsync(int idEmpresa);

        Task<EmailAlternativoEmpresa> CriarEmailAlternativoEmpresaAsync(EmailAlternativoEmpresa emailAlternativoEmpresa);
        Task<EmailAlternativoEmpresa> AtualizarEmailAlternativoEmpresaAsync(EmailAlternativoEmpresa emailAlternativoEmpresa);
        Task<EmailAlternativoEmpresa> DeletarEmailAlternativoEmpresaAsync(EmailAlternativoEmpresa emailAlternativoEmpresa);
    }
}
