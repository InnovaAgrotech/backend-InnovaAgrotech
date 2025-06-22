using MediatR;
using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Application.CQRS.Reviews.Queries;

namespace InnatAPP.Application.CQRS.Reviews.Handlers
{
    public class GetReviewByIdQueryHandler : IRequestHandler<GetReviewByIdQuery, Review?>
    {
        private readonly IReviewRepository _reviewRepository;
        public GetReviewByIdQueryHandler(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }
        public async Task<Review?> Handle(GetReviewByIdQuery request, CancellationToken cancellationToken)
        {
            return await _reviewRepository.BuscarReviewPorIdAsync(request.Id);
        }
    }
}