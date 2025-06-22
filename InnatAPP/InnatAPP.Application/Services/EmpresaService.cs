using MediatR;
using AutoMapper;
using InnatAPP.Application.DTOs;
using InnatAPP.Application.Interfaces;
using InnatAPP.Application.CQRS.Empresas.Commands;
using InnatAPP.Application.CQRS.Empresas.Queries;

namespace InnatAPP.Application.Services
{
    public class EmpresaService : IEmpresaService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public EmpresaService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        #region Buscas
        public async Task<EmpresaDTO?> BuscarEmpresaPorIdAsync(Guid id)
        {
            var empresaByIdQuery = new GetEmpresaByIdQuery(id) ?? throw new Exception($"Não foi possível carregar a entidade.");
            var resultado = await _mediator.Send(empresaByIdQuery);
            return _mapper.Map<EmpresaDTO>(resultado);
        }

        public async Task<EmpresaDTO?> BuscarEmpresaPorIdDeUsuarioAsync(Guid idUsuario)
        {
            var empresaByIdUsuario = new GetEmpresaByIdUsuarioQuery(idUsuario) ?? throw new Exception($"Não foi possível carregar a entidade.");
            var resultado = await _mediator.Send(empresaByIdUsuario);
            return _mapper.Map<EmpresaDTO>(resultado);
        }

        public async Task<EmpresaDTO?> BuscarEmpresaPorEmailAsync(string email)
        {
            var empresaByEmail = new GetEmpresaByEmailQuery(email) ?? throw new Exception($"Não foi possível carregar a entidade.");
            var resultado = await _mediator.Send(empresaByEmail);
            return _mapper.Map<EmpresaDTO>(resultado);
        }

        public async Task<IEnumerable<EmpresaDTO>> BuscarEmpresasAsync()
        {
            var empresasQuery = new GetEmpresasQuery() ?? throw new Exception($"Não foi possível carregar a entidade.");
            var resultado = await _mediator.Send(empresasQuery);
            return _mapper.Map<IEnumerable<EmpresaDTO>>(resultado);
        }

        #endregion

        #region Comandos

        public async Task CriarEmpresaAsync(EmpresaDTO empresaDto)
        {
            var empresaCreateCommand = _mapper.Map<EmpresaCreateCommand>(empresaDto);
            await _mediator.Send(empresaCreateCommand);
        }

        public async Task DeletarEmpresaAsync(Guid id)
        {
            var empresaRemoveCommand = new EmpresaRemoveCommand(id) ?? throw new Exception($"Não foi possível carregar a entidade.");
            await _mediator.Send(empresaRemoveCommand);
        }

        #endregion
    }
}