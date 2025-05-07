using InnatAPP.Application.DTOs;
using InnatAPP.Application.Interfaces;
using InnatAPP.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaDTO>>> Get()
        {
            var categorias = await _categoriaService.BuscarCategoriasAsync();
            if (categorias == null) 
            { 
                return NotFound("Categorias não encontradas.");
            }
            return Ok(categorias);
        }

        [HttpGet("{id:int}", Name = "GetCategoria")]
        public async Task<ActionResult<CategoriaDTO>> Get(int id) 
        { 
            var categoria = await _categoriaService.BuscarCategoriaPorIdAsync(id);
            if (categoria == null)
            {
                return NotFound("Categoria não encontrada.");
            }
            return Ok(categoria);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CategoriaDTO categoriaDTO)
        {
            if (categoriaDTO == null)
                return BadRequest("Dados inválidos.");

            await _categoriaService.CriarCategoriaAsync(categoriaDTO);

            return new CreatedAtRouteResult("GetCategoria", new { id = categoriaDTO.Id }, categoriaDTO);
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] CategoriaDTO categoriaDTO) 
        {
            if (id != categoriaDTO.Id)
                return BadRequest("Dados inválidos.");

            if (categoriaDTO == null)
                return BadRequest("Categoria não encontrada.");

            await _categoriaService.AtualizarCategoriaAsync(categoriaDTO);

            return Ok(categoriaDTO);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CategoriaDTO>> Delete(int id) 
        { 
         var categoria = await _categoriaService.BuscarCategoriaPorIdAsync(id);
            if (categoria == null) 
            {  
                return NotFound("Categoria não encontrada."); 
            }

            await _categoriaService.DeletarCategoriaAsync(id);
            return Ok(categoria);
        }
    }
}