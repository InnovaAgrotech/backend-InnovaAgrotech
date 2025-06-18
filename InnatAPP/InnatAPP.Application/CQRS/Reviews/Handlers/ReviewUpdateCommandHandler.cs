using MediatR;
using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Application.CQRS.Reviews.Commands;

namespace InnatAPP.Application.CQRS.Reviews.Handlers
{
    public class ReviewUpdateCommandHandler : IRequestHandler<ReviewUpdateCommand, Review>
    {
        private readonly IReviewRepository _reviewRepository;
        public ReviewUpdateCommandHandler(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }
        public async Task<Review> Handle(ReviewUpdateCommand request, CancellationToken cancellationToken)
        {
            var review = await _reviewRepository.BuscarReviewPorIdAsync(request.Id);

            if (review == null)
            {
                throw new ApplicationException($"Entidade não pode ser encontrada.");
            }
            else
            {
                review.Alterar(request.Nota, request.Resenha);
                return await _reviewRepository.AtualizarReviewAsync(review);
            }
        }
    }
}