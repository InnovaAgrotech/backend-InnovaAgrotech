using MediatR;
using InnatAPP.Domain.Entities;

namespace InnatAPP.Application.CQRS.Produtos.Queries
{
    public class GetProdutosByCategoriaQuery : IRequest<IEnumerable<Produto>>
    {
        public Guid IdCategoria { get; set; }
        public GetProdutosByCategoriaQuery(Guid idCategoria)
        {
            IdCategoria = idCategoria;
        }

    }
}