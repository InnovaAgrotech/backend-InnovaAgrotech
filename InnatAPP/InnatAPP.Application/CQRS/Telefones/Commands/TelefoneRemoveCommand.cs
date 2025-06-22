using MediatR;
using InnatAPP.Domain.Entities;

namespace InnatAPP.Application.CQRS.Telefones.Commands
{
    public class TelefoneRemoveCommand : IRequest<Telefone>
    {
        public Guid Id { get; set; }
        public TelefoneRemoveCommand(Guid id)
        {
            Id = id;
        }
    }
}