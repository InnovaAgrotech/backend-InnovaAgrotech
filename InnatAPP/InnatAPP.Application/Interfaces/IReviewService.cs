using InnatAPP.Application.DTOs;

namespace InnatAPP.Application.Interfaces
{
    public interface IReviewService
    {
        #region Buscas

        Task<ReviewDTO?> BuscarReviewPorIdAsync(Guid id);
        Task<IEnumerable<ReviewDTO>> BuscarReviewsAsync();
        Task<IEnumerable<ReviewDTO>> BuscarReviewsPorAvaliadorAsync(Guid idAvaliador);
        Task<IEnumerable<ReviewDTO>> BuscarReviewsPorProdutoAsync(Guid idProduto);

        #endregion

        #region Comandos

        Task CriarReviewAsync(ReviewDTO reviewDto);
        Task AtualizarReviewAsync(ReviewDTO reviewDto);
        Task DeletarReviewAsync(Guid id);

        #endregion
    }
}