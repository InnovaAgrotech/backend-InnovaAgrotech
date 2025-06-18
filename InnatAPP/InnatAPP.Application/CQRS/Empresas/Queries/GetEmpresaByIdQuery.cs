using MediatR;
using InnatAPP.Domain.Entities;

namespace InnatAPP.Application.CQRS.Empresas.Queries
{
    public class GetEmpresaByIdQuery : IRequest<Empresa>
    {
        public Guid Id { get; set; }
        public GetEmpresaByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}