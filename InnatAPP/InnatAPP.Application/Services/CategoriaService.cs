using MediatR;
using AutoMapper;
using InnatAPP.Application.DTOs;
using InnatAPP.Application.Interfaces;
using InnatAPP.Application.CQRS.Categorias.Queries;
using InnatAPP.Application.CQRS.Categorias.Commands;

namespace InnatAPP.Application.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CategoriaService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        #region Buscas
        public async Task<CategoriaDTO?> BuscarCategoriaPorIdAsync(Guid id)
        {
            var categoriaByIdQuery = new GetCategoriaByIdQuery(id) ?? throw new Exception($"Não foi possível carregar a entidade.");
            var resultado = await _mediator.Send(categoriaByIdQuery);
            return _mapper.Map<CategoriaDTO>(resultado);
        }

        public async Task<IEnumerable<CategoriaDTO>> BuscarCategoriasAsync()
        {
            var categoriasQuery = new GetCategoriasQuery() ?? throw new Exception($"Não foi possível carregar a entidade.");
            var resultado = await _mediator.Send(categoriasQuery);
            return _mapper.Map<IEnumerable<CategoriaDTO>>(resultado);
        }

        #endregion

        #region Comandos

        public async Task CriarCategoriaAsync(CategoriaDTO categoriaDto)
        {
            var categoriaCreateCommand = _mapper.Map<CategoriaCreateCommand>(categoriaDto);
            await _mediator.Send(categoriaCreateCommand);
        }

        public async Task AtualizarCategoriaAsync(CategoriaDTO categoriaDto)
        {
            var categoriaUpdateCommand = _mapper.Map<CategoriaUpdateCommand>(categoriaDto);
            await _mediator.Send(categoriaUpdateCommand);
        }

        public async Task DeletarCategoriaAsync(Guid id)
        {
            var categoriaRemoveCommand = new CategoriaRemoveCommand(id) ?? throw new Exception($"Não foi possível carregar a entidade.");
            await _mediator.Send(categoriaRemoveCommand);
        }

        #endregion
    }
}