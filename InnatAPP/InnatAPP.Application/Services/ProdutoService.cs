using AutoMapper;
using InnatAPP.Application.DTOs;
using InnatAPP.Application.Interfaces;
using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnatAPP.Application.Services
{
    public class ProdutoService : IProdutoService
    {
        private IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;
        public ProdutoService(IProdutoRepository produtoRepository, IMapper mapper)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }
        public async Task AtualizarProdutoAsync(ProdutoDTO produtoDto)
        {
            var produtoEntity = _mapper.Map<Produto>(produtoDto);
            await _produtoRepository.AtualizarProdutoAsync(produtoEntity);
        }

        public async Task<ProdutoDTO> BuscarProdutoPorIdAsync(int id)
        {
            var produtoEntity = await _produtoRepository.BuscarProdutoPorIdAsync(id);
            return _mapper.Map<ProdutoDTO>(produtoEntity);
        }

        public async Task<IEnumerable<ProdutoDTO>> BuscarProdutosAsync()
        {
            var produtoEntity = await _produtoRepository.BuscarProdutosAsync();
            return _mapper.Map<IEnumerable<ProdutoDTO>>(produtoEntity);
        }

        public async Task<IEnumerable<ProdutoDTO>> BuscarProdutosPorCategoriaAsync(int idCategoria)
        {
            var produtoEntity = await _produtoRepository.BuscarProdutosPorCategoriaAsync(idCategoria);
            return _mapper.Map <IEnumerable<ProdutoDTO>>(produtoEntity);
        }

        public async Task<IEnumerable<ProdutoDTO>> BuscarProdutosPorEmpresaAsync(int idEmpresa)
        {
            var produtoEntity = await _produtoRepository.BuscarProdutosPorCategoriaAsync(idEmpresa);
            return _mapper.Map<IEnumerable<ProdutoDTO>>(produtoEntity);
        }

        public async Task CriarProdutoAsync(ProdutoDTO produtoDto)
        {
            var produtoEntity = _mapper.Map<Produto>(produtoDto);
            await _produtoRepository.CriarProdutoAsync(produtoEntity);
        }

        public async Task DeletarProdutoAsync(int id)
        {
            var produtoEntity = _produtoRepository.BuscarProdutoPorIdAsync(id).Result;
            await _produtoRepository.DeletarProdutoAsync(produtoEntity);
        }
    }
}
