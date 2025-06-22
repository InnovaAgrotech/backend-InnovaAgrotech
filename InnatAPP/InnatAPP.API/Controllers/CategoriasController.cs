using Microsoft.AspNetCore.Mvc;
using InnatAPP.Application.DTOs;
using InnatAPP.Application.Interfaces;

namespace InnatAPP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;
        public CategoriasController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        #region Buscas

        [HttpGet("{id:Guid}", Name = "GetCategoria")]
        public async Task<ActionResult<CategoriaDTO>> GetById(Guid id)
        {
            var categoria = await _categoriaService.BuscarCategoriaPorIdAsync(id);
            if (categoria == null)
            {
                return NotFound("Categoria não encontrada.");
            }
            return Ok(categoria);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CategoriaDTO>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<IEnumerable<CategoriaDTO>>> GetAll()
        {
            var categorias = await _categoriaService.BuscarCategoriasAsync();
            if (categorias == null || !categorias.Any())
            {
                return NotFound("Categorias não encontradas.");
            }
            return Ok(categorias);
        }

        #endregion

        #region Comandos

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CategoriaDTO categoriaDTO)
        {
            if (categoriaDTO == null)
                return BadRequest("Dados inválidos.");

            await _categoriaService.CriarCategoriaAsync(categoriaDTO);

            return new CreatedAtRouteResult("GetCategoria", new { id = categoriaDTO.Id }, categoriaDTO);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Guid id, [FromBody] CategoriaDTO categoriaDTO)
        {
            if (categoriaDTO == null)
                return BadRequest("Categoria não encontrada.");

            if (id != categoriaDTO.Id)
                return BadRequest("Dados inválidos.");

            await _categoriaService.AtualizarCategoriaAsync(categoriaDTO);

            return Ok(categoriaDTO);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult<CategoriaDTO>> Delete(Guid id)
        {
            var categoria = await _categoriaService.BuscarCategoriaPorIdAsync(id);
            if (categoria == null)
            {
                return NotFound("Categoria não encontrada.");
            }

            await _categoriaService.DeletarCategoriaAsync(id);
            return Ok(categoria);
        }

        #endregion
    }
}