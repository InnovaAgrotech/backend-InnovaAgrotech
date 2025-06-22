using MediatR;
using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Application.CQRS.EmailsAlternativos.Queries;

namespace InnatAPP.Application.CQRS.EmailsAlternativos.Handlers
{
    public class GetEmailsAlternativosByUsuarioQueryHandler : IRequestHandler<GetEmailsAlternativosByUsuarioQuery, IEnumerable<EmailAlternativo>>
    {
        private readonly IEmailAlternativoRepository _emailAlternativoRepository;
        public GetEmailsAlternativosByUsuarioQueryHandler(IEmailAlternativoRepository emailAlternativoRepository)
        {
            _emailAlternativoRepository = emailAlternativoRepository;
        }
        public async Task<IEnumerable<EmailAlternativo>> Handle(GetEmailsAlternativosByUsuarioQuery request, CancellationToken cancellationToken)
        {
            return await _emailAlternativoRepository.BuscarEmailsAlternativosPorUsuarioAsync(request.IdUsuario);
        }
    }
}