using MediatR;
using InnatAPP.Domain.Entities;

namespace InnatAPP.Application.CQRS.Empresas.Queries
{
    public class GetEmpresasQuery : IRequest<IEnumerable<Empresa>>
    {

    }
}
