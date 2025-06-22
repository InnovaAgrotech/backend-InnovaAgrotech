using MediatR;
using InnatAPP.Domain.Entities;

namespace InnatAPP.Application.CQRS.EmailsAlternativos.Queries
{
    public class GetEmailsAlternativosQuery : IRequest<IEnumerable<EmailAlternativo>>
    {

    }
}