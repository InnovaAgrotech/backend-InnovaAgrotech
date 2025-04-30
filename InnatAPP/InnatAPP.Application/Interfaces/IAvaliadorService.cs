using InnatAPP.Application.DTOs;
using InnatAPP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnatAPP.Application.Interfaces
{
    public interface IAvaliadorService
    {
        Task<IEnumerable<AvaliadorDTO>> BuscarAvaliadoresAsync();
        Task<AvaliadorDTO> BuscarAvaliadorPorIdAsync(int id);

        Task CriarAvaliadorAsync(AvaliadorDTO avaliadorDto);
        Task AtualizarAvaliadorAsync(AvaliadorDTO avaliadorDto);
        Task DeletarAvaliadorAsync(int id);
    }
}
