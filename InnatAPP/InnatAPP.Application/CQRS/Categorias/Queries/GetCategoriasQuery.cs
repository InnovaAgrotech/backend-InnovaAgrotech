using MediatR;
using InnatAPP.Domain.Entities;

namespace InnatAPP.Application.CQRS.Categorias.Queries
{
    public class GetCategoriasQuery : IRequest<IEnumerable<Categoria>>
    {

    }
}