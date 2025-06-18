using MediatR;
using InnatAPP.Domain.Entities;

namespace InnatAPP.Application.CQRS.Reviews.Queries
{
    public class GetReviewsByAvaliadorQuery : IRequest<IEnumerable<Review>>
    {
        public Guid IdAvaliador { get; set; }
        public GetReviewsByAvaliadorQuery(Guid idAvaliador)
        {
            IdAvaliador = idAvaliador;
        }
    }
}