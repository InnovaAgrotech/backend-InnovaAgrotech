using MediatR;
using InnatAPP.Domain.Entities;

namespace InnatAPP.Application.CQRS.EmailsAlternativos.Commands
{
    public abstract class EmailAlternativoCommand : IRequest<EmailAlternativo>
    {
        public string EnderecoEmail { get; set; } = string.Empty;
        public Guid IdUsuario { get; set; }
    }
}