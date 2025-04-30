using InnatAPP.Application.DTOs;
using InnatAPP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnatAPP.Application.Interfaces
{
    public interface IEnderecoAvaliadorService
    {
        Task<EnderecoAvaliadorDTO> BuscarEnderecoDeAvaliadorPorIdAsync(int id);
        Task<IEnumerable<EnderecoAvaliadorDTO>> BuscarEnderecosDeAvaliadoresAsync();
        Task<IEnumerable<EnderecoAvaliadorDTO>> BuscarEnderecosPorAvaliadorAsync(int idAvaliador);

        Task CriarEnderecoDeAvaliadorAsync(EnderecoAvaliadorDTO enderecoAvaliadorDto);
        Task AtualizarEnderecoDeAvaliadorAsync(EnderecoAvaliadorDTO enderecoAvaliadorDto);
        Task DeletarEnderecoDeAvaliadorAsync(int id);
    }
}
