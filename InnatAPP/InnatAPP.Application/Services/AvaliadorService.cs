using MediatR;
using AutoMapper;
using InnatAPP.Application.DTOs;
using InnatAPP.Application.Interfaces;
using InnatAPP.Application.CQRS.Avaliadores.Queries;
using InnatAPP.Application.CQRS.Avaliadores.Commands;

namespace InnatAPP.Application.Services
{
    public class AvaliadorService : IAvaliadorService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public AvaliadorService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        #region Buscas

        public async Task<AvaliadorDTO?> BuscarAvaliadorPorIdAsync(Guid id)
        {
            var avaliadorByIdQuery = new GetAvaliadorByIdQuery(id) ?? throw new Exception($"Não foi possível carregar a entidade.");
            var resultado = await _mediator.Send(avaliadorByIdQuery);
            return _mapper.Map<AvaliadorDTO>(resultado);
        }

        public async Task<AvaliadorDTO?> BuscarAvaliadorPorIdDeUsuarioAsync(Guid idUsuario)
        {
            var avaliadorByIdUsuario = new GetAvaliadorByIdUsuarioQuery(idUsuario) ?? throw new Exception($"Não foi possível carregar a entidade.");
            var resultado = await _mediator.Send(avaliadorByIdUsuario);
            return _mapper.Map<AvaliadorDTO>(resultado);
        }

        public async Task<AvaliadorDTO?> BuscarAvaliadorPorEmailAsync(string email)
        {
            var avaliadorByEmail = new GetAvaliadorByEmailQuery(email) ?? throw new Exception($"Não foi possível carregar a entidade.");
            var resultado = await _mediator.Send(avaliadorByEmail);
            return _mapper.Map<AvaliadorDTO>(resultado);
        }

        public async Task<IEnumerable<AvaliadorDTO>> BuscarAvaliadoresAsync()
        {
            var avaliadoresQuery = new GetAvaliadoresQuery() ?? throw new Exception($"Não foi possível carregar a entidade.");
            var resultado = await _mediator.Send(avaliadoresQuery);
            return _mapper.Map<IEnumerable<AvaliadorDTO>>(resultado);
        }

        #endregion

        #region Comandos

        public async Task CriarAvaliadorAsync(AvaliadorDTO avaliadorDto)
        {
            var avaliadorCreateCommand = _mapper.Map<AvaliadorCreateCommand>(avaliadorDto);
            await _mediator.Send(avaliadorCreateCommand);
        }

        public async Task DeletarAvaliadorAsync(Guid id)
        {
            var avaliadorRemoveCommand = new AvaliadorRemoveCommand(id) ?? throw new Exception($"Não foi possível carregar a entidade.");
            await _mediator.Send(avaliadorRemoveCommand);
        }

        #endregion
    }
}