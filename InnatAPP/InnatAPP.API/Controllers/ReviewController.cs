using Microsoft.AspNetCore.Mvc;
using InnatAPP.Application.DTOs;
using InnatAPP.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace InnatAPP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        #region Buscas

        [HttpGet("{id:Guid}", Name = "GetReview")]
        public async Task<ActionResult<ReviewDTO>> GetById(Guid id)
        {
            var review = await _reviewService.BuscarReviewPorIdAsync(id);
            if (review == null)
            {
                return NotFound("Review não encontrada.");
            }
            return Ok(review);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ReviewDTO>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<IEnumerable<ReviewDTO>>> GetAll()
        {
            var reviews = await _reviewService.BuscarReviewsAsync();
            if (reviews == null || !reviews.Any())
            {
                return NotFound("Reviews não encontradas.");
            }
            return Ok(reviews);
        }

        [HttpGet("Avaliador/{idAvaliador:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ReviewDTO>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<IEnumerable<ReviewDTO>>> GetAllByAvaliador(Guid idAvaliador)
        {
            var reviews = await _reviewService.BuscarReviewsPorAvaliadorAsync(idAvaliador);
            if (reviews == null || !reviews.Any())
            {
                return NotFound("Reviews não encontradas.");
            }
            return Ok(reviews);
        }

        [HttpGet("Produto/{idProduto:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ReviewDTO>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<IEnumerable<ReviewDTO>>> GetAllByProduto(Guid idProduto)
        {
            var reviews = await _reviewService.BuscarReviewsPorProdutoAsync(idProduto);
            if (reviews == null || !reviews.Any())
            {
                return NotFound("Reviews não encontradas.");
            }
            return Ok(reviews);
        }

        #endregion

        #region Comandos

        [Authorize(Roles = "Avaliador")]
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ReviewDTO reviewDTO)
        {
            if (reviewDTO == null)
                return BadRequest("Dados inválidos.");

            await _reviewService.CriarReviewAsync(reviewDTO);

            return new CreatedAtRouteResult("GetReview", new { id = reviewDTO.Id }, reviewDTO);
        }

        [Authorize(Roles = "Avaliador")]
        [HttpPut]
        public async Task<ActionResult> Put(Guid id, [FromBody] ReviewDTO reviewDTO)
        {
            if (reviewDTO == null)
                return BadRequest("Review não encontrada.");

            if (id != reviewDTO.Id)
                return BadRequest("Dados inválidos.");

            await _reviewService.AtualizarReviewAsync(reviewDTO);

            return Ok(reviewDTO);
        }

        [Authorize(Roles = "Avaliador")]
        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult<ReviewDTO>> Delete(Guid id)
        {
            var review = await _reviewService.BuscarReviewPorIdAsync(id);
            if (review == null)
            {
                return NotFound("Review não encontrada.");
            }

            await _reviewService.DeletarReviewAsync(id);
            return Ok(review);
        }

        #endregion
    }
}