using MediatR;
using InnatAPP.Domain.Entities;

namespace InnatAPP.Application.CQRS.Produtos.Queries
{
    public class GetProdutosByEmpresaQuery : IRequest<IEnumerable<Produto>>
    {
        public Guid IdEmpresa { get; set; }
        public GetProdutosByEmpresaQuery(Guid idEmpresa)
        {
            IdEmpresa = idEmpresa;
        }

    }
}