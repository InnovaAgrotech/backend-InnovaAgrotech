using InnatAPP.Application.DTOs;

namespace InnatAPP.Application.Interfaces
{
    public interface IEnderecoService
    {
        #region Buscas

        Task<EnderecoDTO?> BuscarEnderecoPorIdAsync(Guid id);
        Task<IEnumerable<EnderecoDTO>> BuscarEnderecosAsync();
        Task<IEnumerable<EnderecoDTO>> BuscarEnderecosPorUsuarioAsync(Guid idUsuario);

        #endregion

        #region Comandos

        Task CriarEnderecoAsync(EnderecoDTO enderecoDto);
        Task AtualizarEnderecoAsync(EnderecoDTO enderecoDto);
        Task DeletarEnderecoAsync(Guid id);

        #endregion
    }
}