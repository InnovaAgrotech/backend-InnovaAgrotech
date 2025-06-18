using InnatAPP.Domain.Entities;

namespace InnatAPP.Domain.Interfaces
{
    public interface IEmailAlternativoRepository
    {
        #region Buscas

        Task<EmailAlternativo?> BuscarEmailAlternativoPorIdAsync(Guid id);
        Task<IEnumerable<EmailAlternativo>> BuscarEmailsAlternativosAsync();
        Task<IEnumerable<EmailAlternativo>> BuscarEmailsAlternativosPorUsuarioAsync(Guid idUsuario);

        #endregion

        #region Comandos

        Task<EmailAlternativo> CriarEmailAlternativoAsync(EmailAlternativo emailAlternativo);
        Task<EmailAlternativo> AtualizarEmailAlternativoAsync(EmailAlternativo emailAlternativo);
        Task<EmailAlternativo> DeletarEmailAlternativoAsync(EmailAlternativo emailAlternativo);

        #endregion
    }
}