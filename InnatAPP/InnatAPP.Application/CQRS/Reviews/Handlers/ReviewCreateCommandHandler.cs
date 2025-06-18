using MediatR;
using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Application.CQRS.Reviews.Commands;

namespace InnatAPP.Application.CQRS.Reviews.Handlers
{
    public class ReviewCreateCommandHandler : IRequestHandler<ReviewCreateCommand, Review>
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewCreateCommandHandler(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<Review> Handle(ReviewCreateCommand request, CancellationToken cancellationToken)
        {
            var review = new Review(
                request.Nota,
                request.Resenha,
                request.IdAvaliador,
                request.IdProduto
            );

            if (review == null)
            {
                throw new ApplicationException($"Erro ao criar entidade.");
            }
            else
            {
                return await _reviewRepository.CriarReviewAsync(review);
            }
        }
    }
}