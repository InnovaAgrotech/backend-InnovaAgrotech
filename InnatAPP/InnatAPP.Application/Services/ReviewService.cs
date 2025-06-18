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
        public async Task AtualizarReviewAsync(ReviewDTO reviewDto)
        {
            var reviewUpdateCommand = _mapper.Map<ReviewUpdateCommand>(reviewDto);
            await _mediator.Send(reviewUpdateCommand);
        }

        public async Task<ReviewDTO> BuscarReviewPorIdAsync(int id)
        {
            var reviewByIdQuery = new GetReviewByIdQuery(id);
            if (reviewByIdQuery == null)
                throw new Exception($"Não foi possível carregar a entidade.");

            var result = await _mediator.Send(reviewByIdQuery);
            return _mapper.Map<ReviewDTO>(result);
        }

        public async Task<IEnumerable<ReviewDTO>> BuscarReviewsAsync()
        {
            var reviewsQuery = new GetReviewsQuery();
            if (reviewsQuery == null)
                throw new Exception($"Não foi possível carregar a entidade.");

            var result = await _mediator.Send(reviewsQuery);
            return _mapper.Map<IEnumerable<ReviewDTO>>(result);
        }

        public async Task<IEnumerable<ReviewDTO>> BuscarReviewsPorAvaliadorAsync(int idAvaliador)
        {
            var reviewsPorAvaliadorQuery = new GetReviewsPorAvaliadorQuery(idAvaliador);
            if (reviewsPorAvaliadorQuery == null)
                throw new Exception($"Não foi possível carregar a entidade.");

            var result = await _mediator.Send(reviewsPorAvaliadorQuery);
            return _mapper.Map<IEnumerable<ReviewDTO>>(result);
        }

        public async Task<IEnumerable<ReviewDTO>> BuscarReviewsPorProdutoAsync(int idProduto)
        {
            var reviewsPorProdutoQuery = new GetReviewsPorProdutoQuery(idProduto);
            if (reviewsPorProdutoQuery == null)
                throw new Exception($"Não foi possível carregar a entidade.");

            var result = await _mediator.Send(reviewsPorProdutoQuery);
            return _mapper.Map<IEnumerable<ReviewDTO>>(result);
        }

        public async Task CriarReviewAsync(ReviewDTO reviewDto)
        {
            var reviewCreateCommand = _mapper.Map<ReviewCreateCommand>(reviewDto);
            await _mediator.Send(reviewCreateCommand);
        }

        public async Task DeletarReviewAsync(int id)
        {
            var reviewRemoveCommand = new ReviewRemoveCommand(id);
            if (reviewRemoveCommand == null)
                throw new Exception($"Não foi possível carregar a entidade.");

            await _mediator.Send(reviewRemoveCommand);
        }
    }
}