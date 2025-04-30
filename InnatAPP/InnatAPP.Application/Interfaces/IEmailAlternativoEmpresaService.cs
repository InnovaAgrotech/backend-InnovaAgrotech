using InnatAPP.Application.DTOs;
using InnatAPP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnatAPP.Application.Interfaces
{
    public interface IEmailAlternativoEmpresaService
    {
        Task<EmailAlternativoEmpresaDTO> BuscarEmailAlternativoDeEmpresaPorIdAsync(int id);
        Task<IEnumerable<EmailAlternativoEmpresaDTO>> BuscarEmailsAlternativosDeEmpresasAsync();
        Task<IEnumerable<EmailAlternativoEmpresaDTO>> BuscarEmailsAlternativosPorEmpresaAsync(int idEmpresa);

        Task CriarEmailAlternativoEmpresaAsync(EmailAlternativoEmpresaDTO emailAlternativoEmpresaDto);
        Task AtualizarEmailAlternativoEmpresaAsync(EmailAlternativoEmpresaDTO emailAlternativoEmpresaDto);
        Task DeletarEmailAlternativoEmpresaAsync(int id);
    }
}
