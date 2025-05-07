using InnatAPP.Application.DTOs;
using InnatAPP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnatAPP.Application.Interfaces
{
    public interface ITelefoneEmpresaService
    {
        Task<TelefoneEmpresaDTO> BuscarTelefoneDeEmpresaPorIdAsync(int id);
        Task<IEnumerable<TelefoneEmpresaDTO>> BuscarTelefonesDeEmpresasAsync();
        Task<IEnumerable<TelefoneEmpresaDTO>> BuscarTelefonesPorEmpresaAsync(int idEmpresa);

        Task CriarTelefoneDeEmpresaAsync(TelefoneEmpresaDTO telefoneEmpresaDto);
        Task AtualizarTelefoneDeEmpresaAsync(TelefoneEmpresaDTO telefoneEmpresaDto);
        Task DeletarTelefoneDeEmpresaAsync(int id);
    }
}
