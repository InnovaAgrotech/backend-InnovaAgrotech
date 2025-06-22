using MediatR;
using InnatAPP.Domain.Entities;

namespace InnatAPP.Application.CQRS.EmailsAlternativos.Queries
{
    public class GetEmailAlternativoByIdQuery : IRequest<EmailAlternativo>
    {
        public Guid Id { get; set; }
        public GetEmailAlternativoByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}