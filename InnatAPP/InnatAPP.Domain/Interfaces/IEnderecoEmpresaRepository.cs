using System.Threading.Tasks;
using InnatAPP.Domain.Entities;
using System.Collections.Generic;

namespace InnatAPP.Domain.Interfaces
{
    public interface IEnderecoEmpresaRepository
    {
        Task<EnderecoEmpresa> BuscarEnderecoDeEmpresaPorIdAsync(int id);
        Task<IEnumerable<EnderecoEmpresa>> BuscarEnderecosDeEmpresasAsync();
        Task<IEnumerable<EnderecoEmpresa>> BuscarEnderecosPorEmpresaAsync(int idEmpresa);

        Task<EnderecoEmpresa> CriarEnderecoDeEmpresaAsync(EnderecoEmpresa enderecoEmpresa);
        Task<EnderecoEmpresa> AtualizarEnderecoDeEmpresaAsync(EnderecoEmpresa enderecoEmpresa);
        Task<EnderecoEmpresa> DeletarEnderecoDeEmpresaAsync(EnderecoEmpresa enderecoEmpresa);
    }
}
