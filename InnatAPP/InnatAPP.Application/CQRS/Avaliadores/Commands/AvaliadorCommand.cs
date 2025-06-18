using MediatR;
using InnatAPP.Domain.Entities;

namespace InnatAPP.Application.CQRS.Avaliadores.Commands
{
    public abstract class AvaliadorCommand : IRequest<Avaliador>
    {
        public Guid IdUsuario { get; set; }
    }
}