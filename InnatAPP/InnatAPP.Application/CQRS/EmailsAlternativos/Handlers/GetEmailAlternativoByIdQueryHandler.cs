using MediatR;
using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Application.CQRS.EmailsAlternativos.Queries;

namespace InnatAPP.Application.CQRS.EmailsAlternativos.Handlers
{
    public class GetEmailAlternativoByIdQueryHandler : IRequestHandler<GetEmailAlternativoByIdQuery, EmailAlternativo?>
    {
        private readonly IEmailAlternativoRepository _emailAlternativoRepository;
        public GetEmailAlternativoByIdQueryHandler(IEmailAlternativoRepository emailAlternativoRepository)
        {
            _emailAlternativoRepository = emailAlternativoRepository;
        }
        public async Task<EmailAlternativo?> Handle(GetEmailAlternativoByIdQuery request, CancellationToken cancellationToken)
        {
            return await _emailAlternativoRepository.BuscarEmailAlternativoPorIdAsync(request.Id);
        }
    }
}