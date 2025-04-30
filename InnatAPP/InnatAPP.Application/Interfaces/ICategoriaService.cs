using InnatAPP.Application.DTOs;
using InnatAPP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnatAPP.Application.Interfaces
{
    public interface ICategoriaService
    {
        Task<IEnumerable<CategoriaDTO>> BuscarCategoriasAsync();
        Task<CategoriaDTO> BuscarCategoriaPorIdAsync(int id);

        Task CriarCategoriaAsync(CategoriaDTO categoriaDto);
        Task AtualizarCategoriaAsync(CategoriaDTO categoriaDto);
        Task DeletarCategoriaAsync(int id);
    }
}
