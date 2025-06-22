using MediatR;
using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Application.CQRS.EmailsAlternativos.Commands;

namespace InnatAPP.Application.CQRS.EmailsAlternativos.Handlers
{
    public class EmailAlternativoRemoveCommandHandler : IRequestHandler<EmailAlternativoRemoveCommand, EmailAlternativo>
    {
        private readonly IEmailAlternativoRepository _emailAlternativoRepository;
        public EmailAlternativoRemoveCommandHandler(IEmailAlternativoRepository emailAlternativoRepository)
        {
            _emailAlternativoRepository = emailAlternativoRepository;
        }
        public async Task<EmailAlternativo> Handle(EmailAlternativoRemoveCommand request, CancellationToken cancellationToken)
        {
            var emailAlternativo = await _emailAlternativoRepository.BuscarEmailAlternativoPorIdAsync(request.Id);

            if (emailAlternativo == null)
            {
                throw new ApplicationException($"Entidade não pode ser encontrada.");
            }
            else
            {
                var resultado = await _emailAlternativoRepository.DeletarEmailAlternativoAsync(emailAlternativo);
                return resultado;
            }
        }
    }
}