using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace InnatAPP.Infra.Data.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private ApplicationDbContext _categoriaContext;

        public CategoriaRepository(ApplicationDbContext context)
        {
            _categoriaContext = context;
        }
        public async Task<Categoria> AtualizarCategoriaAsync(Categoria categoria)
        {
            _categoriaContext.Update(categoria);
            await _categoriaContext.SaveChangesAsync();
            return categoria;
        }

        public async Task<IEnumerable<Categoria>> BuscarCategoriasAsync()
        {
            return await _categoriaContext.Categorias.ToListAsync();
        }

        public async Task<Categoria> BuscarCategoriaPorIdAsync(int id)
        {
            return await _categoriaContext.Categorias.FindAsync(id);
        }

        public async Task<Categoria> CriarCategoriaAsync(Categoria categoria)
        {
            _categoriaContext.Add(categoria);
            await _categoriaContext.SaveChangesAsync();
            return categoria;
        }

        public async Task<Categoria> DeletarCategoriaAsync(Categoria categoria)
        {
            _categoriaContext.Remove(categoria);
            await _categoriaContext.SaveChangesAsync();
            return categoria;
        }
    }
}