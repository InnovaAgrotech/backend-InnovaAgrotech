using InnatAPP.Application.DTOs;
using InnatAPP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnatAPP.Application.Interfaces
{
    public interface IEmailAlternativoAvaliadorService
    {
        Task<EmailAlternativoAvaliadorDTO> BuscarEmailAlternativoDeAvaliadorPorIdAsync(int id);
        Task<IEnumerable<EmailAlternativoAvaliadorDTO>> BuscarEmailsAlternativosDeAvaliadoresAsync();
        Task<IEnumerable<EmailAlternativoAvaliadorDTO>> BuscarEmailsAlternativosPorAvaliadorAsync(int idAvaliador);

        Task CriarEmailAlternativoDeAvaliadorAsync(EmailAlternativoAvaliadorDTO emailAlternativoAvaliadorDto);
        Task AtualizarEmailAlternativoDeAvaliadorAsync(EmailAlternativoAvaliadorDTO emailAlternativoAvaliadorDto);
        Task DeletarEmailAlternativoDeAvaliadorAsync(int id);
    }
}
