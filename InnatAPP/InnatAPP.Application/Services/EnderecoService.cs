using MediatR;
using AutoMapper;
using InnatAPP.Application.DTOs;
using InnatAPP.Application.Interfaces;
using InnatAPP.Application.CQRS.Enderecos.Queries;
using InnatAPP.Application.CQRS.Enderecos.Commands;

namespace InnatAPP.Application.Services
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public EnderecoService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        #region Buscas
        public async Task<EnderecoDTO?> BuscarEnderecoPorIdAsync(Guid id)
        {
            var enderecoByIdQuery = new GetEnderecoByIdQuery(id) ?? throw new Exception($"Não foi possível carregar a entidade.");
            var resultado = await _mediator.Send(enderecoByIdQuery);
            return _mapper.Map<EnderecoDTO>(resultado);
        }

        public async Task<IEnumerable<EnderecoDTO>> BuscarEnderecosAsync()
        {
            var enderecosQuery = new GetEnderecosQuery() ?? throw new Exception($"Não foi possível carregar a entidade.");
            var resultado = await _mediator.Send(enderecosQuery);
            return _mapper.Map<IEnumerable<EnderecoDTO>>(resultado);
        }

        public async Task<IEnumerable<EnderecoDTO>> BuscarEnderecosPorUsuarioAsync(Guid idUsuario)
        {
            var enderecosPorUsuarioQuery = new GetEnderecosByUsuarioQuery(idUsuario) ?? throw new Exception($"Não foi possível carregar a entidade.");
            var resultado = await _mediator.Send(enderecosPorUsuarioQuery);
            return _mapper.Map<IEnumerable<EnderecoDTO>>(resultado);
        }

        #endregion

        #region Comandos

        public async Task CriarEnderecoAsync(EnderecoDTO enderecoDto)
        {
            var enderecoCreateCommand = _mapper.Map<EnderecoCreateCommand>(enderecoDto);
            await _mediator.Send(enderecoCreateCommand);
        }

        public async Task AtualizarEnderecoAsync(EnderecoDTO enderecoDto)
        {
            var enderecoUpdateCommand = _mapper.Map<EnderecoUpdateCommand>(enderecoDto);
            await _mediator.Send(enderecoUpdateCommand);
        }

        public async Task DeletarEnderecoAsync(Guid id)
        {
            var enderecoRemoveCommand = new EnderecoRemoveCommand(id) ?? throw new Exception($"Não foi possível carregar a entidade.");
            await _mediator.Send(enderecoRemoveCommand);
        }

        #endregion
    }
}
