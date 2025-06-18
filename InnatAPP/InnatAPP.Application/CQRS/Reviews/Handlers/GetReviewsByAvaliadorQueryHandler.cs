using InnatAPP.Application.CQRS.Reviews.Queries;
using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using MediatR;

namespace InnatAPP.Application.CQRS.Reviews.Handlers
{
    public class GetReviewsByAvaliadorQueryHandler : IRequestHandler<GetReviewsByAvaliadorQuery, IEnumerable<Review>>
    {
        private readonly IReviewRepository _reviewRepository;
        public GetReviewsByAvaliadorQueryHandler(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }
        public async Task<IEnumerable<Review>> Handle(GetReviewsByAvaliadorQuery request, CancellationToken cancellationToken)
        {
            return await _reviewRepository.BuscarReviewsPorAvaliadorAsync(request.IdAvaliador);
        }
    }
}
