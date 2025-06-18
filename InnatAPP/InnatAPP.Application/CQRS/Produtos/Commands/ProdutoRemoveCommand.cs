using MediatR;
using InnatAPP.Domain.Entities;

namespace InnatAPP.Application.CQRS.Produtos.Commands
{
    public class ProdutoRemoveCommand : IRequest<Produto>
    {
        public Guid Id { get; set; }
        public ProdutoRemoveCommand(Guid id)
        {
            Id = id;
        }
    }
}