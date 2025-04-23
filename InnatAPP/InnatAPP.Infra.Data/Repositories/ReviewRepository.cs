using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace InnatAPP.Infra.Data.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private ApplicationDbContext _reviewContext;

        public ReviewRepository(ApplicationDbContext context)
        {
            _reviewContext = context;
        }
        public async Task<Review> AtualizarReviewAsync(Review review)
        {
            _reviewContext.Update(review);
            await _reviewContext.SaveChangesAsync();
            return review;
        }

        public async Task<Review> BuscarReviewPorIdAsync(int id)
        {
            return await _reviewContext.Reviews.FindAsync(id);
        }

        public async Task<IEnumerable<Review>> BuscarReviewsAsync()
        {
            return await _reviewContext.Reviews.ToListAsync();
        }

        public async Task<IEnumerable<Review>> BuscarReviewsPorAvaliadorAsync(int idAvaliador)
        {
            return await _reviewContext.Reviews
                .Include(e => e.Avaliador)
                .Where(e => e.IdAvaliador == idAvaliador)
                .ToListAsync();
        }

        public async Task<IEnumerable<Review>> BuscarReviewsPorProdutoAsync(int idProduto)
        {
            return await _reviewContext.Reviews
                .Include(e => e.Produto)
                .Where(e => e.IdProduto == idProduto)
                .ToListAsync();
        }

        public async Task<Review> CriarReviewAsync(Review review)
        {
            _reviewContext.Add(review);
            await _reviewContext.SaveChangesAsync();
            return review;
        }

        public async Task<Review> DeletarReviewAsync(Review review)
        {
            _reviewContext.Remove(review);
            await _reviewContext.SaveChangesAsync();
            return review;
        }
    }
}