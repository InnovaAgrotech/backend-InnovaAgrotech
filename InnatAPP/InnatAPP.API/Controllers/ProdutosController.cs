using Microsoft.AspNetCore.Mvc;
using InnatAPP.Application.DTOs;
using InnatAPP.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;

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

        #region Buscas

        [HttpGet("{id:Guid}", Name = "GetProduto")]
        public async Task<ActionResult<ProdutoDTO>> GetById(Guid id)
        {
            var produto = await _produtoService.BuscarProdutoPorIdAsync(id);
            if (produto == null)
            {
                return NotFound("Produto não encontrado.");
            }
            return Ok(produto);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ProdutoDTO>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<IEnumerable<ProdutoDTO>>> GetAll()
        {
            var produtos = await _produtoService.BuscarProdutosAsync();
            if (produtos == null || !produtos.Any())
            {
                return NotFound("Produtos não encontrados.");
            }
            return Ok(produtos);
        }

        [HttpGet("Categoria/{idCategoria:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ProdutoDTO>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<IEnumerable<ProdutoDTO>>> GetAllByCategoria(Guid idCategoria)
        {
            var produtos = await _produtoService.BuscarProdutosPorCategoriaAsync(idCategoria);
            if (produtos == null || !produtos.Any())
            {
                return NotFound("Produtos não encontrados.");
            }
            return Ok(produtos);
        }

        [HttpGet("Empresa/{idEmpresa:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ProdutoDTO>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<IEnumerable<ProdutoDTO>>> GetAllByEmpresa(Guid idEmpresa)
        {
            var produtos = await _produtoService.BuscarProdutosPorEmpresaAsync(idEmpresa);
            if (produtos == null || !produtos.Any())
            {
                return NotFound("Produtos não encontrados.");
            }
            return Ok(produtos);
        }

        #endregion

        #region Comandos

        [Authorize(Roles = "Empresa")]
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProdutoDTO produtoDTO)
        {
            if (produtoDTO == null)
                return BadRequest("Dados inválidos.");

            await _produtoService.CriarProdutoAsync(produtoDTO);

            return new CreatedAtRouteResult("GetProduto", new { id = produtoDTO.Id }, produtoDTO);
        }

        [Authorize(Roles = "Empresa")]
        [HttpPut]
        public async Task<ActionResult> Put(Guid id, [FromBody] ProdutoDTO produtoDTO)
        {
            if (produtoDTO == null)
                return BadRequest("Produto não encontrado.");

            if (id != produtoDTO.Id)
                return BadRequest("Dados inválidos.");

            await _produtoService.AtualizarProdutoAsync(produtoDTO);

            return Ok(produtoDTO);
        }

        [Authorize(Roles = "Empresa")]
        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult<ProdutoDTO>> Delete(Guid id)
        {
            var produto = await _produtoService.BuscarProdutoPorIdAsync(id);
            if (produto == null)
            {
                return NotFound("Produto não encontrado.");
            }

            await _produtoService.DeletarProdutoAsync(id);
            return Ok(produto);
        }

        #endregion
    }
}