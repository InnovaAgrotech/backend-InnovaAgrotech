using MediatR;
using AutoMapper;
using InnatAPP.Application.DTOs;
using InnatAPP.Application.Interfaces;
using InnatAPP.Application.CQRS.Telefones.Queries;
using InnatAPP.Application.CQRS.Telefones.Commands;

namespace InnatAPP.Application.Services
{
    public class TelefoneService : ITelefoneService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public TelefoneService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        #region Buscas

        public async Task<TelefoneDTO?> BuscarTelefonePorIdAsync(Guid id)
        {
            var telefoneByIdQuery = new GetTelefoneByIdQuery(id) ?? throw new Exception($"Não foi possível carregar a entidade.");
            var resultado = await _mediator.Send(telefoneByIdQuery);
            return _mapper.Map<TelefoneDTO>(resultado);
        }

        public async Task<IEnumerable<TelefoneDTO>> BuscarTelefonesAsync()
        {
            var telefonesQuery = new GetTelefonesQuery() ?? throw new Exception($"Não foi possível carregar a entidade.");
            var resultado = await _mediator.Send(telefonesQuery);
            return _mapper.Map<IEnumerable<TelefoneDTO>>(resultado);
        }

        public async Task<IEnumerable<TelefoneDTO>> BuscarTelefonesPorUsuarioAsync(Guid idUsuario)
        {
            var telefonesPorUsuarioQuery = new GetTelefonesByUsuarioQuery(idUsuario) ?? throw new Exception($"Não foi possível carregar a entidade.");
            var resultado = await _mediator.Send(telefonesPorUsuarioQuery);
            return _mapper.Map<IEnumerable<TelefoneDTO>>(resultado);
        }

        #endregion

        #region Buscas
        public async Task CriarTelefoneAsync(TelefoneDTO telefoneDto)
        {
            var telefoneCreateCommand = _mapper.Map<TelefoneCreateCommand>(telefoneDto);
            await _mediator.Send(telefoneCreateCommand);
        }

        public async Task AtualizarTelefoneAsync(TelefoneDTO telefoneDto)
        {
            var telefoneUpdateCommand = _mapper.Map<TelefoneUpdateCommand>(telefoneDto);
            await _mediator.Send(telefoneUpdateCommand);
        }
        public async Task DeletarTelefoneAsync(Guid id)
        {
            var telefoneRemoveCommand = new TelefoneRemoveCommand(id) ?? throw new Exception($"Não foi possível carregar a entidade.");
            await _mediator.Send(telefoneRemoveCommand);
        }

        #endregion
    }
}