using MediatR;
using AutoMapper;
using InnatAPP.Application.Interfaces;
using InnatAPP.Application.CQRS.Produtos.Queries;
using InnatAPP.Application.CQRS.Produtos.Commands;
using InnatAPP.Application.DTOs.Produto;
using InnatAPP.Domain.Entities;

namespace InnatAPP.Application.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public ProdutoService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        #region Buscas
        public async Task<ProdutoDTO?> BuscarProdutoPorIdAsync(Guid id)
        {
            var produtoByIdQuery = new GetProdutoByIdQuery(id) ?? throw new Exception($"Não foi possível carregar a entidade.");
            var resultado = await _mediator.Send(produtoByIdQuery);
            return _mapper.Map<ProdutoDTO>(resultado);
        }

        public async Task<IEnumerable<ProdutoDTO>> BuscarProdutosAsync()
        {
            var produtosQuery = new GetProdutosQuery() ?? throw new Exception($"Não foi possível carregar a entidade.");
            var resultado = await _mediator.Send(produtosQuery);
            return _mapper.Map<IEnumerable<ProdutoDTO>>(resultado);
        }

        public async Task<IEnumerable<ProdutoDTO>> BuscarProdutosPorCategoriaAsync(Guid idCategoria)
        {
            var produtosPorCategoriaQuery = new GetProdutosByCategoriaQuery(idCategoria) ?? throw new Exception($"Não foi possível carregar a entidade.");
            var resultado = await _mediator.Send(produtosPorCategoriaQuery);
            return _mapper.Map<IEnumerable<ProdutoDTO>>(resultado);
        }

        public async Task<IEnumerable<ProdutoDTO>> BuscarProdutosPorEmpresaAsync(Guid idEmpresa)
        {
            var produtosPorEmpresaQuery = new GetProdutosByEmpresaQuery(idEmpresa)
                ?? throw new Exception($"Não foi possível carregar a entidade.");
            var resultado = await _mediator.Send(produtosPorEmpresaQuery);
            return _mapper.Map<IEnumerable<ProdutoDTO>>(resultado);
        }

        #endregion

        #region Comandos
        public async Task<Produto> CriarProdutoAsync(ProdutoCreateDTO produtoDto)
        {
            var produtoCreateCommand = _mapper.Map<ProdutoCreateCommand>(produtoDto);
            var produtoCriado = await _mediator.Send(produtoCreateCommand);
            return produtoCriado;
        }

        public async Task AtualizarProdutoAsync(ProdutoUpdateDTO produtoDto)
        {
            var produtoUpdateCommand = _mapper.Map<ProdutoUpdateCommand>(produtoDto);
            await _mediator.Send(produtoUpdateCommand);
        }

        public async Task DeletarProdutoAsync(Guid id)
        {
            var produtoRemoveCommand = new ProdutoRemoveCommand(id) ?? throw new Exception($"Não foi possível carregar a entidade.");
            await _mediator.Send(produtoRemoveCommand);
        }

        #endregion
    }
}