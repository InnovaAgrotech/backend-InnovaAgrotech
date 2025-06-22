using MediatR;
using InnatAPP.Domain.Entities;

namespace InnatAPP.Application.CQRS.EmailsAlternativos.Queries
{
    public class GetEmailsAlternativosByUsuarioQuery : IRequest<IEnumerable<EmailAlternativo>>
    {
        public Guid IdUsuario { get; set; }
        public GetEmailsAlternativosByUsuarioQuery(Guid idUsuario)
        {
            IdUsuario = idUsuario;
        }
    }
}