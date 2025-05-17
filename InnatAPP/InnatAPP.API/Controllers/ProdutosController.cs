using InnatAPP.Application.DTOs;
using InnatAPP.Application.Interfaces;
using InnatAPP.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InnatAPP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutosController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoDTO>>> GetAll()
        {
            var produtos = await _produtoService.BuscarProdutosAsync();
            if (produtos == null)
            {
                return NotFound("Produtos não encontrados.");
            }
            return Ok(produtos);
        }

        [HttpGet("{id:int}", Name = "GetProduto")]
        public async Task<ActionResult<ProdutoDTO>> GetById(int id)
        {
            var produto = await _produtoService.BuscarProdutoPorIdAsync(id);
            if (produto == null)
            {
                return NotFound("Produto não encontrado.");
            }
            return Ok(produto);
        }

        [HttpGet("categoria/{idCategoria:int}")]
        public async Task<ActionResult<IEnumerable<ProdutoDTO>>> GetByCategoria(int idCategoria)
        {
            var produtos = await _produtoService.BuscarProdutosPorCategoriaAsync(idCategoria);
            if (produtos == null)
            {
                return NotFound("Nenhum produto encontrado para essa categoria.");
            }
            return Ok(produtos);
        }

        [HttpGet("empresa/{idEmpresa:int}")]
        public async Task<ActionResult<IEnumerable<ProdutoDTO>>> GetByEmpresa(int idEmpresa)
        {
            var produtos = await _produtoService.BuscarProdutosPorEmpresaAsync(idEmpresa);
            if (produtos == null)
            {
                return NotFound("Nenhum produto encontrado para essa empresa.");
            }
            return Ok(produtos);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProdutoDTO produtoDTO)
        {
            if (produtoDTO == null)
                return BadRequest("Dados inválidos.");

            await _produtoService.CriarProdutoAsync(produtoDTO);

            return new CreatedAtRouteResult("GetProduto", new { id = produtoDTO.Id }, produtoDTO);
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] ProdutoDTO produtoDTO)
        {
            if (id != produtoDTO.Id)
                return BadRequest("Dados inválidos.");

            if (produtoDTO == null)
                return BadRequest("Produto não encontrado.");

            await _produtoService.AtualizarProdutoAsync(produtoDTO);

            return Ok(produtoDTO);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ProdutoDTO>> Delete(int id)
        {
            var produto = await _produtoService.BuscarProdutoPorIdAsync(id);
            if (produto == null)
            {
                return NotFound("Produto não encontrado.");
            }

            await _produtoService.DeletarProdutoAsync(id);
            return Ok(produto);
        }
    }
}
