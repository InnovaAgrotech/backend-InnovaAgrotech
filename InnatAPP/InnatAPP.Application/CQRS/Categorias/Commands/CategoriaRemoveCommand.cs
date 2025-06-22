using MediatR;
using InnatAPP.Domain.Entities;

namespace InnatAPP.Application.CQRS.Categorias.Commands
{
    public class CategoriaRemoveCommand : IRequest<Categoria>
    {
        public Guid Id { get; set; }
        public CategoriaRemoveCommand(Guid id)
        {
            Id = id;
        }
    }
}