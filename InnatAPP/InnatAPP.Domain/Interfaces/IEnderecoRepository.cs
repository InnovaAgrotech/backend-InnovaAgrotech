using InnatAPP.Domain.Entities;

namespace InnatAPP.Domain.Interfaces
{
    public interface IEnderecoRepository
    {
        #region Buscas

        Task<Endereco?> BuscarEnderecoPorIdAsync(Guid id);
        Task<IEnumerable<Endereco>> BuscarEnderecosAsync();
        Task<IEnumerable<Endereco>> BuscarEnderecosPorUsuarioAsync(Guid idUsuario);

        #endregion

        #region Comandos

        Task<Endereco> CriarEnderecoAsync(Endereco endereco);
        Task<Endereco> AtualizarEnderecoAsync(Endereco endereco);
        Task<Endereco> DeletarEnderecoAsync(Endereco endereco);

        #endregion
    }
}