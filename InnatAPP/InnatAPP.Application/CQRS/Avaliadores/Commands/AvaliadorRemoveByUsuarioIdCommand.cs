using MediatR;
using InnatAPP.Domain.Entities;

namespace InnatAPP.Application.CQRS.Avaliadores.Commands
{
    public class AvaliadorRemoveByUsuarioIdCommand : IRequest<Avaliador?>
    {
        public Guid IdUsuario { get; set; }

        public AvaliadorRemoveByUsuarioIdCommand(Guid idUsuario)
        {
            IdUsuario = idUsuario;
        }
    }
}
