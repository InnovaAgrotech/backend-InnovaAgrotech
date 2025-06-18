using MediatR;
using InnatAPP.Domain.Entities;

namespace InnatAPP.Application.CQRS.Reviews.Queries
{
    public class GetReviewsQuery : IRequest<IEnumerable<Review>>
    {
    }
}
