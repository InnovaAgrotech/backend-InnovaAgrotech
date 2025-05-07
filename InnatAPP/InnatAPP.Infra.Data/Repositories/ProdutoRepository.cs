using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace InnatAPP.Infra.Data.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private ApplicationDbContext _produtoContext;

        public ProdutoRepository(ApplicationDbContext context)
        {
            _produtoContext = context;
        }
        public async Task<Produto> AtualizarProdutoAsync(Produto produto)
        {
            _produtoContext.Update(produto);
            await _produtoContext.SaveChangesAsync();
            return produto;
        }

        public async Task<Produto> BuscarProdutoPorIdAsync(int id)
        {
            return await _produtoContext.Produtos
                .Include(p => p.Categoria)
                .Include(p => p.Empresa)
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Produto>> BuscarProdutosAsync()
        {
            return await _produtoContext.Produtos.ToListAsync();
        }

        public async Task<IEnumerable<Produto>> BuscarProdutosPorCategoriaAsync(int idCategoria)
        {
            return await _produtoContext.Produtos
                .Include(p => p.Categoria)
                .Include(p => p.Empresa)
                .Where(p => p.IdCategoria == idCategoria)
                .ToListAsync();
        }

        public async Task<IEnumerable<Produto>> BuscarProdutosPorEmpresaAsync(int idEmpresa)
        {
            return await _produtoContext.Produtos
                .Include(p => p.Empresa)
                .Include(p => p.Categoria)
                .Where(p => p.IdEmpresa == idEmpresa)
                .ToListAsync();
        }

        public async Task<Produto> CriarProdutoAsync(Produto produto)
        {
            _produtoContext.Add(produto);
            await _produtoContext.SaveChangesAsync();
            return produto;
        }

        public async Task<Produto> DeletarProdutoAsync(Produto produto)
        {
            _produtoContext.Remove(produto);
            await _produtoContext.SaveChangesAsync();
            return produto;
        }
    }
}