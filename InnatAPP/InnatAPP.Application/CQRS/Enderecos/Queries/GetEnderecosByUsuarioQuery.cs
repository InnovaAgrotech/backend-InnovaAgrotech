using MediatR;
using InnatAPP.Domain.Entities;

namespace InnatAPP.Application.CQRS.Enderecos.Queries
{
    public class GetEnderecosByUsuarioQuery : IRequest<IEnumerable<Endereco>>
    {
        public Guid IdUsuario { get; set; }
        public GetEnderecosByUsuarioQuery(Guid idUsuario)
        {
            IdUsuario = idUsuario;
        }
    }
}