using Microsoft.AspNetCore.Mvc;
using InnatAPP.Application.DTOs;
using InnatAPP.Application.Interfaces;

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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReviewDTO>>> GetAll()
        {
            var reviews = await _reviewService.BuscarReviewsAsync();
            if (reviews == null)
            {
                return NotFound("Reviews não encontradas.");
            }
            return Ok(reviews);
        }

        [HttpGet("{id:int}", Name = "GetReview")]
        public async Task<ActionResult<ReviewDTO>> GetById(int id)
        {
            var review = await _reviewService.BuscarReviewPorIdAsync(id);
            if (review == null)
            {
                return NotFound("Review não encontrada.");
            }
            return Ok(review);
        }

        [HttpGet("avaliador/{idAvaliador:int}")]
        public async Task<ActionResult<IEnumerable<ReviewDTO>>> GetByAvaliador(int idAvaliador)
        {
            var reviews = await _reviewService.BuscarReviewsPorAvaliadorAsync(idAvaliador);
            if (reviews == null)
            {
                return NotFound("Nenhuma review encontrada para esse avaliador.");
            }
            return Ok(reviews);
        }

        [HttpGet("produto/{idProduto:int}")]
        public async Task<ActionResult<IEnumerable<ReviewDTO>>> GetByProduto(int idProduto)
        {
            var reviews = await _reviewService.BuscarReviewsPorProdutoAsync(idProduto);
            if (reviews == null)
            {
                return NotFound("Nenhuma review encontrada para esse produto.");
            }
            return Ok(reviews);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ReviewDTO reviewDTO)
        {
            if (reviewDTO == null)
                return BadRequest("Dados inválidos.");

            await _reviewService.CriarReviewAsync(reviewDTO);

            return new CreatedAtRouteResult("GetReview", new { id = reviewDTO.Id }, reviewDTO);
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] ReviewDTO reviewDTO)
        {
            if (id != reviewDTO.Id)
                return BadRequest("Dados inválidos.");

            if (reviewDTO == null)
                return BadRequest("Review não encontrada.");

            await _reviewService.AtualizarReviewAsync(reviewDTO);

            return Ok(reviewDTO);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ReviewDTO>> Delete(int id)
        {
            var review = await _reviewService.BuscarReviewPorIdAsync(id);
            if (review == null)
            {
                return NotFound("Review não encontrada.");
            }

            await _reviewService.DeletarReviewAsync(id);
            return Ok(review);
        }
    }
}