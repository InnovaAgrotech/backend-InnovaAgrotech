using MediatR;
using InnatAPP.Domain.Entities;

namespace InnatAPP.Application.CQRS.Avaliadores.Commands
{
    public class AvaliadorRemoveCommand : IRequest<Avaliador>
    {
        public Guid Id { get; set; }
        public AvaliadorRemoveCommand(Guid id)
        {
            Id = id;
        }
    }
}