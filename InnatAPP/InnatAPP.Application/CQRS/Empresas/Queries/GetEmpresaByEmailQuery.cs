using MediatR;
using InnatAPP.Domain.Entities;

namespace InnatAPP.Application.CQRS.Empresas.Queries
{
    public class GetEmpresaByEmailQuery : IRequest<Empresa>
    {
        public string Email { get; set; }
        public GetEmpresaByEmailQuery(string email)
        {
            Email = email;
        }
    }
}