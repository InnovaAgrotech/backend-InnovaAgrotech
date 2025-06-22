using MediatR;
using InnatAPP.Domain.Entities;

namespace InnatAPP.Application.CQRS.Reviews.Queries
{
    public class GetReviewByIdQuery : IRequest<Review>
    {
        public Guid Id { get; set; }
        public GetReviewByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}