using MediatR;
using InnatAPP.Domain.Entities;

namespace InnatAPP.Application.CQRS.Usuarios.Commands
{
    public class UsuarioRemoveCommand : IRequest<Usuario>
    {
        public Guid Id { get; set; }
        public UsuarioRemoveCommand(Guid id) 
        { 
            Id = id;
        }
    }
}