using MediatR;
using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Application.CQRS.EmailsAlternativos.Queries;

namespace InnatAPP.Application.CQRS.EmailsAlternativos.Handlers
{
    public class GetEmailsAlternativosQueryHandler : IRequestHandler<GetEmailsAlternativosQuery, IEnumerable<EmailAlternativo>>
    {
        private readonly IEmailAlternativoRepository _emailAlternativoRepository;
        public GetEmailsAlternativosQueryHandler(IEmailAlternativoRepository emailAlternativoRepository)
        {
            _emailAlternativoRepository = emailAlternativoRepository;
        }
        public async Task<IEnumerable<EmailAlternativo>> Handle(GetEmailsAlternativosQuery request, CancellationToken cancellationToken)
        {
            return await _emailAlternativoRepository.BuscarEmailsAlternativosAsync();
        }
    }
}