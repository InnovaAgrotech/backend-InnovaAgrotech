using MediatR;
using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Application.CQRS.Reviews.Commands;

namespace InnatAPP.Application.CQRS.Reviews.Handlers
{
    public class ReviewRemoveCommandHandler : IRequestHandler<ReviewRemoveCommand, Review>
    {
        private readonly IReviewRepository _reviewRepository;
        public ReviewRemoveCommandHandler(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }
        public async Task<Review> Handle(ReviewRemoveCommand request, CancellationToken cancellationToken)
        {
            var review = await _reviewRepository.BuscarReviewPorIdAsync(request.Id);

            if (review == null)
            {
                throw new ApplicationException($"Entidade não pode ser encontrada.");
            }
            else
            {
                var resultado = await _reviewRepository.DeletarReviewAsync(review);
                return resultado;
            }
        }
    }
}