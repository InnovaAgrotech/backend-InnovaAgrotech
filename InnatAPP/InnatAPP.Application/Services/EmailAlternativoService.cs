using MediatR;
using AutoMapper;
using InnatAPP.Application.DTOs;
using InnatAPP.Application.Interfaces;
using InnatAPP.Application.CQRS.EmailsAlternativos.Queries;
using InnatAPP.Application.CQRS.EmailsAlternativos.Commands;

namespace InnatAPP.Application.Services
{
    public class EmailAlternativoService : IEmailAlternativoService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public EmailAlternativoService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        #region Buscas
        public async Task<EmailAlternativoDTO?> BuscarEmailAlternativoPorIdAsync(Guid id)
        {
            var emailAlternativoByIdQuery = new GetEmailAlternativoByIdQuery(id) ?? throw new Exception($"Não foi possível carregar a entidade.");
            var resultado = await _mediator.Send(emailAlternativoByIdQuery);
            return _mapper.Map<EmailAlternativoDTO>(resultado);
        }

        public async Task<IEnumerable<EmailAlternativoDTO>> BuscarEmailsAlternativosAsync()
        {
            var emailsAlternativosQuery = new GetEmailsAlternativosQuery() ?? throw new Exception($"Não foi possível carregar a entidade.");
            var resultado = await _mediator.Send(emailsAlternativosQuery);
            return _mapper.Map<IEnumerable<EmailAlternativoDTO>>(resultado);
        }

        public async Task<IEnumerable<EmailAlternativoDTO>> BuscarEmailsAlternativosPorUsuarioAsync(Guid idUsuario)
        {
            var emailsAlternativosPorUsuarioQuery = new GetEmailsAlternativosByUsuarioQuery(idUsuario) ?? throw new Exception($"Não foi possível carregar a entidade.");
            var resultado = await _mediator.Send(emailsAlternativosPorUsuarioQuery);
            return _mapper.Map<IEnumerable<EmailAlternativoDTO>>(resultado);
        }

        #endregion

        #region Comandos

        public async Task CriarEmailAlternativoAsync(EmailAlternativoDTO emailAlternativoDto)
        {
            var emailAlternativoCreateCommand = _mapper.Map<EmailAlternativoCreateCommand>(emailAlternativoDto);
            await _mediator.Send(emailAlternativoCreateCommand);
        }

        public async Task AtualizarEmailAlternativoAsync(EmailAlternativoDTO emailAlternativoDto)
        {
            var emailAlternativoUpdateCommand = _mapper.Map<EmailAlternativoUpdateCommand>(emailAlternativoDto);
            await _mediator.Send(emailAlternativoUpdateCommand);
        }

        public async Task DeletarEmailAlternativoAsync(Guid id)
        {
            var emailAlternativoRemoveCommand = new EmailAlternativoRemoveCommand(id) ?? throw new Exception($"Não foi possível carregar a entidade.");
            await _mediator.Send(emailAlternativoRemoveCommand);
        }

        #endregion
    }
}