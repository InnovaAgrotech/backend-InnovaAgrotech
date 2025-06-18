using InnatAPP.Domain.Entities;

namespace InnatAPP.Domain.Interfaces
{
    public interface IReviewRepository
    {
        #region Buscas

        Task<Review?> BuscarReviewPorIdAsync(Guid id);
        Task<IEnumerable<Review>> BuscarReviewsAsync();
        Task<IEnumerable<Review>> BuscarReviewsPorAvaliadorAsync(Guid idAvaliador);
        Task<IEnumerable<Review>> BuscarReviewsPorProdutoAsync(Guid idProduto);

        #endregion

        #region Comandos

        Task<Review> CriarReviewAsync(Review review);
        Task<Review> AtualizarReviewAsync(Review review);
        Task<Review> DeletarReviewAsync(Review review);

        #endregion
    }
}