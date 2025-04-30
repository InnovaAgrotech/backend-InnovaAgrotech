using InnatAPP.Application.DTOs;
using InnatAPP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnatAPP.Application.Interfaces
{
    public interface IReviewService
    {
        Task<ReviewDTO> BuscarReviewPorIdAsync(int id);
        Task<IEnumerable<ReviewDTO>> BuscarReviewsAsync();
        Task<IEnumerable<ReviewDTO>> BuscarReviewsPorAvaliadorAsync(int idAvaliador);
        Task<IEnumerable<ReviewDTO>> BuscarReviewsPorProdutoAsync(int idProduto);

        Task CriarReviewAsync(ReviewDTO reviewDto);
        Task AtualizarReviewAsync(ReviewDTO reviewDto);
        Task DeletarReviewAsync(int id);
    }
}
