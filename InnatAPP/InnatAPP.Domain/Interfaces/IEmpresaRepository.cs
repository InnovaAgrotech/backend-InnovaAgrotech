using InnatAPP.Domain.Entities;

namespace InnatAPP.Domain.Interfaces
{
    public interface IEmpresaRepository
    {
        #region Buscas

        Task<Empresa?> BuscarEmpresaPorIdAsync(Guid id);
        Task<Empresa?> BuscarEmpresaPorIdDeUsuarioAsync(Guid idUsuario);
        Task<Empresa?> BuscarEmpresaPorEmailAsync(string email);
        Task<IEnumerable<Empresa>> BuscarEmpresasAsync();

        #endregion

        #region Comandos

        Task<Empresa> CriarEmpresaAsync(Empresa empresa);
        Task<Empresa> DeletarEmpresaAsync(Empresa empresa);

        #endregion

        #region Verificação de Id de Usuario

        Task<bool> ExistePorUsuarioId(Guid idUsuario);

        #endregion
    }
}