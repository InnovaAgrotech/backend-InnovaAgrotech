using InnatAPP.Application.DTOs;
using InnatAPP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnatAPP.Application.Interfaces
{
    public interface IEnderecoEmpresaService
    {
        Task<EnderecoEmpresaDTO> BuscarEnderecoDeEmpresaPorIdAsync(int id);
        Task<IEnumerable<EnderecoEmpresaDTO>> BuscarEnderecosDeEmpresasAsync();
        Task<IEnumerable<EnderecoEmpresaDTO>> BuscarEnderecosPorEmpresaAsync(int idEmpresa);

        Task CriarEnderecoDeEmpresaAsync(EnderecoEmpresaDTO enderecoEmpresaDto);
        Task AtualizarEnderecoDeEmpresaAsync(EnderecoEmpresaDTO enderecoEmpresaDto);
        Task DeletarEnderecoDeEmpresaAsync(int id);
    }
}
