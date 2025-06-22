using MediatR;
using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Application.CQRS.EmailsAlternativos.Commands;

namespace InnatAPP.Application.CQRS.EmailsAlternativos.Handlers
{
    public class EmailAlternativoCreateCommandHandler : IRequestHandler<EmailAlternativoCreateCommand, EmailAlternativo>
    {
        private readonly IEmailAlternativoRepository _emailAlternativoRepository;

        public EmailAlternativoCreateCommandHandler(IEmailAlternativoRepository emailAlternativoRepository)
        {
            _emailAlternativoRepository = emailAlternativoRepository;
        }

        public async Task<EmailAlternativo> Handle(EmailAlternativoCreateCommand request, CancellationToken cancellationToken)
        {
            var emailAlternativo = new EmailAlternativo(
                request.EnderecoEmail,
                request.IdUsuario
            );

            if (emailAlternativo == null)
            {
                throw new ApplicationException($"Erro ao criar entidade.");
            }
            else
            {
                return await _emailAlternativoRepository.CriarEmailAlternativoAsync(emailAlternativo);
            }
        }
    }
}