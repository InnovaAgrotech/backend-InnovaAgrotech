using MediatR;
using InnatAPP.Domain.Entities;

namespace InnatAPP.Application.CQRS.Empresas.Commands
{
    public class EmpresaRemoveByUsuarioIdCommand : IRequest<Empresa?>
    {
        public Guid IdUsuario { get; set; }

        public EmpresaRemoveByUsuarioIdCommand(Guid idUsuario)
        {
            IdUsuario = idUsuario;
        }
    }
}