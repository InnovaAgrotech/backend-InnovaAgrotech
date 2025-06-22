using MediatR;
using InnatAPP.Domain.Entities;

namespace InnatAPP.Application.CQRS.EmailsAlternativos.Commands
{
    public class EmailAlternativoRemoveCommand : IRequest<EmailAlternativo>
    {
        public Guid Id { get; set; }
        public EmailAlternativoRemoveCommand(Guid id)
        {
            Id = id;
        }
    }
}