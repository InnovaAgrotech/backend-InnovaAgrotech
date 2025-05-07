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
    public class GetReviewsPorAvaliadorQueryHandler : IRequestHandler<GetReviewsPorAvaliadorQuery, IEnumerable<Review>>
    {
        private readonly IReviewRepository _reviewRepository;
        public GetReviewsPorAvaliadorQueryHandler(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }
        public async Task<IEnumerable<Review>> Handle(GetReviewsPorAvaliadorQuery request, CancellationToken cancellationToken)
        {
            return await _reviewRepository.BuscarReviewsPorAvaliadorAsync(request.IdAvaliador);
        }
    }
}
