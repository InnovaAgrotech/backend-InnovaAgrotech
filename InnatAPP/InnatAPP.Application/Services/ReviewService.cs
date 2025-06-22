using MediatR;
using AutoMapper;
using InnatAPP.Application.DTOs;
using InnatAPP.Application.Interfaces;
using InnatAPP.Application.CQRS.Reviews.Queries;
using InnatAPP.Application.CQRS.Reviews.Commands;

namespace InnatAPP.Application.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public ReviewService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        #region Buscas

        public async Task<ReviewDTO?> BuscarReviewPorIdAsync(Guid id)
        {
            var reviewByIdQuery = new GetReviewByIdQuery(id) ?? throw new Exception($"Não foi possível carregar a entidade.");
            var resultado = await _mediator.Send(reviewByIdQuery);
            return _mapper.Map<ReviewDTO>(resultado);
        }

        public async Task<IEnumerable<ReviewDTO>> BuscarReviewsAsync()
        {
            var reviewsQuery = new GetReviewsQuery() ?? throw new Exception($"Não foi possível carregar a entidade.");
            var resultado = await _mediator.Send(reviewsQuery);
            return _mapper.Map<IEnumerable<ReviewDTO>>(resultado);
        }

        public async Task<IEnumerable<ReviewDTO>> BuscarReviewsPorAvaliadorAsync(Guid idAvaliador)
        {
            var reviewsPorAvaliadorQuery = new GetReviewsByAvaliadorQuery(idAvaliador) ?? throw new Exception($"Não foi possível carregar a entidade.");
            var resultado = await _mediator.Send(reviewsPorAvaliadorQuery);
            return _mapper.Map<IEnumerable<ReviewDTO>>(resultado);
        }

        public async Task<IEnumerable<ReviewDTO>> BuscarReviewsPorProdutoAsync(Guid idProduto)
        {
            var reviewsPorProdutoQuery = new GetReviewsByProdutoQuery(idProduto) ?? throw new Exception($"Não foi possível carregar a entidade.");
            var resultado = await _mediator.Send(reviewsPorProdutoQuery);
            return _mapper.Map<IEnumerable<ReviewDTO>>(resultado);
        }

        #endregion

        #region Comandos

        public async Task CriarReviewAsync(ReviewDTO reviewDto)
        {
            var reviewCreateCommand = _mapper.Map<ReviewCreateCommand>(reviewDto);
            await _mediator.Send(reviewCreateCommand);
        }

        public async Task AtualizarReviewAsync(ReviewDTO reviewDto)
        {
            var reviewUpdateCommand = _mapper.Map<ReviewUpdateCommand>(reviewDto);
            await _mediator.Send(reviewUpdateCommand);
        }

        public async Task DeletarReviewAsync(Guid id)
        {
            var reviewRemoveCommand = new ReviewRemoveCommand(id) ?? throw new Exception($"Não foi possível carregar a entidade.");
            await _mediator.Send(reviewRemoveCommand);
        }

        #endregion
    }
}