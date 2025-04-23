using System.Threading.Tasks;
using InnatAPP.Domain.Entities;
using System.Collections.Generic;

namespace InnatAPP.Domain.Interfaces
{
    public interface IEnderecoAvaliadorRepository
    {
        Task<EnderecoAvaliador> BuscarEnderecoDeAvaliadorPorIdAsync(int id);
        Task<IEnumerable<EnderecoAvaliador>> BuscarEnderecosDeAvaliadoresAsync();
        Task<IEnumerable<EnderecoAvaliador>> BuscarEnderecosPorAvaliadorAsync(int idAvaliador);

        Task<EnderecoAvaliador> CriarEnderecoDeAvaliadorAsync(EnderecoAvaliador enderecoAvaliador);
        Task<EnderecoAvaliador> AtualizarEnderecoDeAvaliadorAsync(EnderecoAvaliador enderecoAvaliador);
        Task<EnderecoAvaliador> DeletarEnderecoDeAvaliadorAsync(EnderecoAvaliador enderecoAvaliador);
    }
}
