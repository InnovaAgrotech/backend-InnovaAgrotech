using MediatR;
using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Application.CQRS.EmailsAlternativos.Commands;

namespace InnatAPP.Application.CQRS.EmailsAlternativos.Handlers
{
    public class EmailAlternativoUpdateCommandHandler : IRequestHandler<EmailAlternativoUpdateCommand, EmailAlternativo>
    {
        private readonly IEmailAlternativoRepository _emailAlternativoRepository;
        public EmailAlternativoUpdateCommandHandler(IEmailAlternativoRepository emailAlternativoRepository)
        {
            _emailAlternativoRepository = emailAlternativoRepository;
        }
        public async Task<EmailAlternativo> Handle(EmailAlternativoUpdateCommand request, CancellationToken cancellationToken)
        {
            var emailAlternativo = await _emailAlternativoRepository.BuscarEmailAlternativoPorIdAsync(request.Id);

            if (emailAlternativo == null)
            {
                throw new ApplicationException($"Entidade não pode ser encontrada.");
            }
            else
            {
                emailAlternativo.Alterar(request.EnderecoEmail);
                return await _emailAlternativoRepository.AtualizarEmailAlternativoAsync(emailAlternativo);
            }
        }
    }
}