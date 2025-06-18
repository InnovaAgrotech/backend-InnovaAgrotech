using MediatR;
using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Application.CQRS.Reviews.Queries;

namespace InnatAPP.Application.CQRS.Reviews.Handlers
{
    public class GetReviewByIdQueryHandler : IRequestHandler<GetReviewsAvaliadordQuery, Review?>
    {
        private readonly IReviewRepository _reviewRepository;
        public GetReviewByIdQueryHandler(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }
        public async Task<Review?> Handle(GetReviewsAvaliadordQuery request, CancellationToken cancellationToken)
        {
            return await _reviewRepository.BuscarReviewPorIdAsync(request.Id);
        }
    }
}