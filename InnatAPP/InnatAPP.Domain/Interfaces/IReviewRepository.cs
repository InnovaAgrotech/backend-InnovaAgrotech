using InnatAPP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnatAPP.Domain.Interfaces
{
    internal interface IReviewRepository
    {
        Task<IEnumerable<Review>> BuscarReviewsAsync();
        Task<Review> BuscarPorIdAsync(int? id);

        Task<Review> BuscarReviewProdutoAsync(int? id);

        Task<Review> AdicionarAsync(Review review);

        Task<Review> AtualizarAsync(Review review);

        Task<Review> RemoverAsync(Review review);
    }
}
