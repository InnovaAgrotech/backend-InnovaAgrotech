using InnatAPP.Application.DTOs;

namespace InnatAPP.Application.Interfaces
{
    public interface IEmpresaService
    {
        #region Buscas

        Task<EmpresaDTO?> BuscarEmpresaPorIdAsync(Guid id);
        Task<EmpresaDTO?> BuscarEmpresaPorIdDeUsuarioAsync(Guid idUsuario);
        Task<EmpresaDTO?> BuscarEmpresaPorEmailAsync(string email);
        Task<IEnumerable<EmpresaDTO>> BuscarEmpresasAsync();

        #endregion

        #region Comandos

        Task CriarEmpresaAsync(EmpresaDTO empresaDto);
        Task DeletarEmpresaAsync(Guid id);

        #endregion
    }
}