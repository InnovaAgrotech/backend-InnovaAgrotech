using MediatR;
using InnatAPP.Domain.Entities;

namespace InnatAPP.Application.CQRS.Produtos.Queries
{
    public class GetProdutosQuery : IRequest<IEnumerable<Produto>>
    {
    }
}