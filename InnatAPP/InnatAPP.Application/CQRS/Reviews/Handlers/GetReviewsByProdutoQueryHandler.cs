using InnatAPP.Application.CQRS.Reviews.Queries;
using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using MediatR;

namespace InnatAPP.Application.CQRS.Reviews.Handlers
{
    public class GetReviewsByProdutoQueryHandler : IRequestHandler<GetReviewsByProdutoQuery, IEnumerable<Review>>
    {
        private readonly IReviewRepository _reviewRepository;
        public GetReviewsByProdutoQueryHandler(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }
        public async Task<IEnumerable<Review>> Handle(GetReviewsByProdutoQuery request, CancellationToken cancellationToken)
        {
            return await _reviewRepository.BuscarReviewsPorProdutoAsync(request.IdProduto);
        }
    }
}