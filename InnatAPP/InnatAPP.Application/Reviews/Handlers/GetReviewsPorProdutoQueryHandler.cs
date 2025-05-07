using InnatAPP.Application.Reviews.Queries;
using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnatAPP.Application.Reviews.Handlers
{
    public class GetReviewsPorProdutoQueryHandler : IRequestHandler<GetReviewsPorProdutoQuery, IEnumerable<Review>>
    {
        private readonly IReviewRepository _reviewRepository;
        public GetReviewsPorProdutoQueryHandler(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }
        public async Task<IEnumerable<Review>> Handle(GetReviewsPorProdutoQuery request, CancellationToken cancellationToken)
        {
            return await _reviewRepository.BuscarReviewsPorProdutoAsync(request.IdProduto);
        }
    }
}
