using InnatAPP.Application.DTOs;
using InnatAPP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnatAPP.Application.Interfaces
{
    public interface ITelefoneAvaliadorService
    {
        Task<TelefoneAvaliadorDTO> BuscarTelefoneDeAvaliadorPorIdAsync(int id);
        Task<IEnumerable<TelefoneAvaliadorDTO>> BuscarTelefonesDeAvaliadoresAsync();
        Task<IEnumerable<TelefoneAvaliadorDTO>> BuscarTelefonesPorAvaliadorAsync(int idAvaliador);

        Task CriarTelefoneDeAvaliadorAsync(TelefoneAvaliadorDTO telefoneAvaliadorDto);
        Task AtualizarTelefoneDeAvaliadorAsync(TelefoneAvaliadorDTO telefoneAvaliadorDto);
        Task DeletarTelefoneDeAvaliadorAsync(int id);
    }
}
