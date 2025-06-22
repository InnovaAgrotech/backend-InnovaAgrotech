using MediatR;
using InnatAPP.Domain.Entities;

namespace InnatAPP.Application.CQRS.Telefones.Commands
{
    public abstract class TelefoneCommand : IRequest<Telefone>
    {
        public string Ddd { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;
        public Guid IdUsuario { get; set; }
    }
}