using MediatR;
using InnatAPP.Domain.Entities;

namespace InnatAPP.Application.CQRS.Produtos.Queries
{
    public class GetProdutoByIdQuery : IRequest<Produto>
    {
        public Guid Id { get; set; }
        public GetProdutoByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}