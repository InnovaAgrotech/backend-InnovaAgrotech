using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace InnatAPP.Infra.Data.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly ApplicationDbContext _reviewContext;

        public ReviewRepository(ApplicationDbContext context)
        {
            _reviewContext = context;
        }

        #region Buscas

        public async Task<Review?> BuscarReviewPorIdAsync(Guid id)
        {
            return await _reviewContext.Reviews.FindAsync(id);
        }
        public async Task<IEnumerable<Review>> BuscarReviewsAsync()
        {
            return await _reviewContext.Reviews.ToListAsync();
        }

        public async Task<IEnumerable<Review>> BuscarReviewsPorAvaliadorAsync(Guid idAvaliador)
        {
            return await _reviewContext.Reviews
                .Include(r => r.Avaliador)
                .Where(r => r.IdAvaliador == idAvaliador)
                .ToListAsync();
        }

        public async Task<IEnumerable<Review>> BuscarReviewsPorProdutoAsync(Guid idProduto)
        {
            return await _reviewContext.Reviews
                .Include(r => r.Produto)
                .Where(r => r.IdProduto == idProduto)
                .ToListAsync();
        }

        #endregion

        #region Comandos

        public async Task<Review> CriarReviewAsync(Review review)
        {
            _reviewContext.Add(review);
            await _reviewContext.SaveChangesAsync();
            return review;
        }

        public async Task<Review> AtualizarReviewAsync(Review review)
        {
            _reviewContext.Update(review);
            await _reviewContext.SaveChangesAsync();
            return review;
        }

        public async Task<Review> DeletarReviewAsync(Review review)
        {
            _reviewContext.Remove(review);
            await _reviewContext.SaveChangesAsync();
            return review;
        }

        #endregion
    }
}