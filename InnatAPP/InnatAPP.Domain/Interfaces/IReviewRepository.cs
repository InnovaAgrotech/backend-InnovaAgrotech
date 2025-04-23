using System.Threading.Tasks;
using InnatAPP.Domain.Entities;
using System.Collections.Generic;

namespace InnatAPP.Domain.Interfaces
{
    public interface IReviewRepository
    {
        Task<Review> BuscarReviewPorIdAsync(int id);
        Task<IEnumerable<Review>> BuscarReviewsAsync();
        Task<IEnumerable<Review>> BuscarReviewsPorAvaliadorAsync(int idAvaliador);
        Task<IEnumerable<Review>> BuscarReviewsPorProdutoAsync(int idProduto);

        Task<Review> CriarReviewAsync(Review review);
        Task<Review> AtualizarReviewAsync(Review review);
        Task<Review> DeletarReviewAsync(Review review);
    }
}
