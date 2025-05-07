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
