using InnatAPP.Application.DTOs;
using InnatAPP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnatAPP.Application.Interfaces
{
    public interface IEmpresaService
    {
        Task<IEnumerable<EmpresaDTO>> BuscarEmpresasAsync();
        Task<EmpresaDTO> BuscarEmpresaPorIdAsync(int id);

        Task CriarEmpresaAsync(EmpresaDTO empresaDto);
        Task AtualizarEmpresaAsync(EmpresaDTO empresaDto);
        Task DeletarEmpresaAsync(int id);
    }
}
