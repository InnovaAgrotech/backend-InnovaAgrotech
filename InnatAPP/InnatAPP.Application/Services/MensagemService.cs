using MediatR;
using AutoMapper;
using InnatAPP.Application.DTOs;
using InnatAPP.Application.Interfaces;
using InnatAPP.Application.CQRS.Mensagens.Queries;
using InnatAPP.Application.CQRS.Mensagens.Commands;

namespace InnatAPP.Application.Services
{
    public class MensagemService : IMensagemService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public MensagemService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        #region Buscas
        public async Task<MensagemDTO?> BuscarMensagemPorIdAsync(Guid id)
        {
            var mensagemByIdQuery = new GetMensagemByIdQuery(id) ?? throw new Exception($"Não foi possível carregar a entidade.");
            var resultado = await _mediator.Send(mensagemByIdQuery);
            return _mapper.Map<MensagemDTO>(resultado);
        }

        public async Task<IEnumerable<MensagemDTO>> BuscarMensagensAsync()
        {
            var mensagensQuery = new GetMensagensQuery() ?? throw new Exception($"Não foi possível carregar a entidade.");
            var resultado = await _mediator.Send(mensagensQuery);
            return _mapper.Map<IEnumerable<MensagemDTO>>(resultado);
        }

        #endregion

        #region Comandos

        public async Task CriarMensagemAsync(MensagemDTO mensagemDto)
        {
            var mensagemCreateCommand = _mapper.Map<MensagemCreateCommand>(mensagemDto);
            await _mediator.Send(mensagemCreateCommand);
        }

        #endregion
    }
}