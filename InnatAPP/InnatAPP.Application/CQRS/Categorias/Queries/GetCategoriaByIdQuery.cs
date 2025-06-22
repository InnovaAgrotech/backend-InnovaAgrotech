using MediatR;
using InnatAPP.Domain.Entities;

namespace InnatAPP.Application.CQRS.Categorias.Queries
{
    public class GetCategoriaByIdQuery : IRequest<Categoria>
    {
        public Guid Id { get; set; }
        public GetCategoriaByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}