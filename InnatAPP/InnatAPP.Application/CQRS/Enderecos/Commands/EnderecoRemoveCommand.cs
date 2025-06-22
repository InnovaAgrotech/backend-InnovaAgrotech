using MediatR;
using InnatAPP.Domain.Entities;

namespace InnatAPP.Application.CQRS.Enderecos.Commands
{
    public class EnderecoRemoveCommand : IRequest<Endereco>
    {
        public Guid Id { get; set; }
        public EnderecoRemoveCommand(Guid id)
        {
            Id = id;
        }
    }
}