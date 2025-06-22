using InnatAPP.Application.DTOs;

namespace InnatAPP.Application.Interfaces
{
    public interface IEmailAlternativoService
    {
        #region Buscas
        Task<EmailAlternativoDTO?> BuscarEmailAlternativoPorIdAsync(Guid id);
        Task<IEnumerable<EmailAlternativoDTO>> BuscarEmailsAlternativosAsync();
        Task<IEnumerable<EmailAlternativoDTO>> BuscarEmailsAlternativosPorUsuarioAsync(Guid idUsuario);

        #endregion

        #region Comandos

        Task CriarEmailAlternativoAsync(EmailAlternativoDTO emailAlternativoDto);
        Task AtualizarEmailAlternativoAsync(EmailAlternativoDTO emailAlternativoDto);
        Task DeletarEmailAlternativoAsync(Guid id);

        #endregion
    }
}