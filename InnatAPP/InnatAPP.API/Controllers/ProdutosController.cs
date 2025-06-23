using Microsoft.AspNetCore.Mvc;
using InnatAPP.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using InnatAPP.Application.DTOs.Produto;
using InnatAPP.Application.DTOs.Usuario;
using AutoMapper;

namespace InnatAPP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoService _produtoService;
        private readonly IMapper _mapper;

        public ProdutosController(IProdutoService produtoService, IMapper mapper)
        {
            _produtoService = produtoService;
            _mapper = mapper;
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
        public async Task<ActionResult> Post([FromBody] ProdutoCreateDTO produtoCreateDTO)
        {
            if (produtoCreateDTO == null)
                return BadRequest("Dados inválidos.");

            // Pega o ID da empresa logada pelo token JWT
            var empresaIdClaim = User.Claims.FirstOrDefault(c => c.Type == "id")?.Value;
            if (!Guid.TryParse(empresaIdClaim, out Guid empresaId))
                return Unauthorized("Empresa não identificada.");

            produtoCreateDTO.IdEmpresa = empresaId;

            var produtoCriado = await _produtoService.CriarProdutoAsync(produtoCreateDTO);
            var produtoDto = _mapper.Map<ProdutoDTO>(produtoCriado);

            return new CreatedAtRouteResult("GetProduto", new { id = produtoDto.Id }, produtoDto);
        }

        [Authorize(Roles = "Empresa")]
        [HttpPut("{id:Guid}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] ProdutoUpdateDTO produtoDTO)
        {
            if (produtoDTO == null)
                return BadRequest("Produto inválido.");

            if (id != produtoDTO.Id)
                return BadRequest("IDs divergentes.");

            var produtoExistente = await _produtoService.BuscarProdutoPorIdAsync(id);
            if (produtoExistente == null)
                return NotFound("Produto não encontrado.");

            var empresaIdClaim = User.Claims.FirstOrDefault(c => c.Type == "id")?.Value;
            if (!Guid.TryParse(empresaIdClaim, out Guid empresaId))
                return Unauthorized("Empresa não identificada.");

            if (produtoExistente.IdEmpresa != empresaId)
                return StatusCode(StatusCodes.Status403Forbidden, "Você não tem permissão para atualizar este produto.");

            produtoDTO.IdEmpresa = empresaId;

            await _produtoService.AtualizarProdutoAsync(produtoDTO);

            return Ok(produtoDTO);
        }

        [Authorize(Roles = "Empresa")]
        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult<ProdutoDTO>> Delete(Guid id)
        {
            var produto = await _produtoService.BuscarProdutoPorIdAsync(id);
            if (produto == null)
                return NotFound("Produto não encontrado.");

            var empresaIdClaim = User.Claims.FirstOrDefault(c => c.Type == "id")?.Value;
            if (!Guid.TryParse(empresaIdClaim, out Guid empresaId))
                return Unauthorized("Empresa não identificada.");

            if (produto.IdEmpresa != empresaId)
                return StatusCode(StatusCodes.Status403Forbidden, "Você não tem permissão para excluir este produto.");

            await _produtoService.DeletarProdutoAsync(id);
            return Ok(produto);
        }

        #endregion
    }
}