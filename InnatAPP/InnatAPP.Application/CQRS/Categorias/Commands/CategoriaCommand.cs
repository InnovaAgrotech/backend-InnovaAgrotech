using MediatR;
using InnatAPP.Domain.Entities;

namespace InnatAPP.Application.CQRS.Categorias.Commands
{
    public abstract class CategoriaCommand : IRequest<Categoria>
    {
        public string Nome { get; set; } = string.Empty;
    }
}