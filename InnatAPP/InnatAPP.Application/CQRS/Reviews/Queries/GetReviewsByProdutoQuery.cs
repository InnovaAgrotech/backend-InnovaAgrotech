using MediatR;
using InnatAPP.Domain.Entities;

namespace InnatAPP.Application.CQRS.Reviews.Queries
{
    public class GetReviewsByProdutoQuery : IRequest<IEnumerable<Review>>
    {
        public Guid IdProduto { get; set; }
        public GetReviewsByProdutoQuery(Guid idProduto)
        {
            IdProduto = idProduto;
        }
    }
}