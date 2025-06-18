using MediatR;
using InnatAPP.Domain.Entities;

namespace InnatAPP.Application.CQRS.Reviews.Queries
{
    public class GetReviewsAvaliadordQuery : IRequest<Review>
    {
        public Guid Id { get; set; }
        public GetReviewsAvaliadordQuery(Guid id)
        {
            Id = id;
        }
    }
}