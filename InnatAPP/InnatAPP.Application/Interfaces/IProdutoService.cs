using InnatAPP.Application.DTOs;
using InnatAPP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnatAPP.Application.Interfaces
{
    public interface IProdutoService
    {
        Task<ProdutoDTO> BuscarProdutoPorIdAsync(int id);
        Task<IEnumerable<ProdutoDTO>> BuscarProdutosAsync();
        Task<IEnumerable<ProdutoDTO>> BuscarProdutosPorCategoriaAsync(int idCategoria);
        Task<IEnumerable<ProdutoDTO>> BuscarProdutosPorEmpresaAsync(int idEmpresa);

        Task CriarProdutoAsync(ProdutoDTO produtoDto);
        Task AtualizarProdutoAsync(ProdutoDTO produtoDto);
        Task DeletarProdutoAsync(int id);
    }
}
