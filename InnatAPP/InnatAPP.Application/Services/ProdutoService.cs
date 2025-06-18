using MediatR;
using AutoMapper;
using InnatAPP.Application.DTOs;
using InnatAPP.Application.Interfaces;
using InnatAPP.Application.CQRS.Produtos.Queries;
using InnatAPP.Application.CQRS.Produtos.Commands;

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
        public async Task AtualizarProdutoAsync(ProdutoDTO produtoDto)
        {
            var produtoUpdateCommand = _mapper.Map<ProdutoUpdateCommand>(produtoDto);
            await _mediator.Send(produtoUpdateCommand);
        }

        public async Task<ProdutoDTO> BuscarProdutoPorIdAsync(int id)
        {
            var produtoByIdQuery = new GetProdutoByIdQuery(id);
            if (produtoByIdQuery == null)
                throw new Exception($"Não foi possível carregar a entidade.");

            var result = await _mediator.Send(produtoByIdQuery);
            return _mapper.Map<ProdutoDTO>(result);
        }

        public async Task<IEnumerable<ProdutoDTO>> BuscarProdutosAsync()
        {
            var produtosQuery = new GetProdutosQuery();
            if (produtosQuery == null)
                throw new Exception($"Não foi possível carregar a entidade.");

            var result = await _mediator.Send(produtosQuery);
            return _mapper.Map<IEnumerable<ProdutoDTO>>(result);
        }

        public async Task<IEnumerable<ProdutoDTO>> BuscarProdutosPorCategoriaAsync(int idCategoria)
        {
            var produtosPorCategoriaQuery = new GetProdutosPorCategoriaQuery(idCategoria);
            if (produtosPorCategoriaQuery == null)
                throw new Exception($"Não foi possível carregar a entidade.");

            var result = await _mediator.Send(produtosPorCategoriaQuery);
            return _mapper.Map<IEnumerable<ProdutoDTO>>(result);
        }

        public async Task<IEnumerable<ProdutoDTO>> BuscarProdutosPorEmpresaAsync(int idEmpresa)
        {
            var produtosPorEmpresaQuery = new GetProdutosPorEmpresaQuery(idEmpresa);
            if (produtosPorEmpresaQuery == null)
                throw new Exception($"Não foi possível carregar a entidade.");

            var result = await _mediator.Send(produtosPorEmpresaQuery);
            return _mapper.Map<IEnumerable<ProdutoDTO>>(result);
        }

        public async Task CriarProdutoAsync(ProdutoDTO produtoDto)
        {
            var produtoCreateCommand = _mapper.Map<ProdutoCreateCommand>(produtoDto);
            await _mediator.Send(produtoCreateCommand);
        }

        public async Task DeletarProdutoAsync(int id)
        {
            var produtoRemoveCommand = new ProdutoRemoveCommand(id);
            if (produtoRemoveCommand == null)
                throw new Exception($"Não foi possível carregar a entidade.");

            await _mediator.Send(produtoRemoveCommand);
        }
    }
}