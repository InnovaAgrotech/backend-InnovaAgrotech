using InnatAPP.Application.CQRS.Reviews.Queries;
using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using MediatR;

namespace InnatAPP.Application.CQRS.Reviews.Handlers
{
    public class GetReviewsQueryHandler : IRequestHandler<GetReviewsQuery, IEnumerable<Review>>
    {
        private readonly IReviewRepository _reviewRepository;
        public GetReviewsQueryHandler(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }
        public async Task<IEnumerable<Review>> Handle(GetReviewsQuery request, CancellationToken cancellationToken)
        {
            return await _reviewRepository.BuscarReviewsAsync();
        }
    }
}
