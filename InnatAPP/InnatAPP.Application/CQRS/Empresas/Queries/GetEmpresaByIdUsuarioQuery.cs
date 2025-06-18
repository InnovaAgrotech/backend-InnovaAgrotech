using MediatR;
using InnatAPP.Domain.Entities;

namespace InnatAPP.Application.CQRS.Empresas.Queries
{
    public class GetEmpresaByIdUsuarioQuery : IRequest<Empresa>
    {
        public Guid IdUsuario { get; set; }
        public GetEmpresaByIdUsuarioQuery(Guid idUsuario)
        {
            IdUsuario = idUsuario;
        }

    }
}