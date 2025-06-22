using MediatR;
using InnatAPP.Domain.Entities;

namespace InnatAPP.Application.CQRS.Telefones.Queries
{
    public class GetTelefonesByUsuarioQuery : IRequest<IEnumerable<Telefone>>
    {
        public Guid IdUsuario { get; set; }
        public GetTelefonesByUsuarioQuery(Guid idUsuario)
        {
            IdUsuario = idUsuario;
        }
    }
}