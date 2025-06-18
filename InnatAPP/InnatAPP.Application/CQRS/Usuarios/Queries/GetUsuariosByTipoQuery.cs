using MediatR;
using InnatAPP.Domain.Entities;

namespace InnatAPP.Application.CQRS.Usuarios.Queries
{
    public class GetUsuariosByTipoQuery : IRequest<IEnumerable<Usuario>>
    {
        public string TipoUsuarioTexto { get; set; }
        public GetUsuariosByTipoQuery(string tipoUsuarioTexto)
        {
            TipoUsuarioTexto = tipoUsuarioTexto;
        }
    }
}