using MediatR;
using InnatAPP.Domain.Entities;

namespace InnatAPP.Application.CQRS.Empresas.Commands
{
    public abstract class EmpresaCommand : IRequest<Empresa>
    {
        public Guid IdUsuario { get; set; }
    }
}