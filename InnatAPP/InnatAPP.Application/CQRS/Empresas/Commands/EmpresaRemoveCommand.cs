using MediatR;
using InnatAPP.Domain.Entities;

namespace InnatAPP.Application.CQRS.Empresas.Commands
{
    public class EmpresaRemoveCommand : IRequest<Empresa>
    {
        public Guid Id { get; set; }
        public EmpresaRemoveCommand(Guid id)
        {
            Id = id;
        }
    }
}