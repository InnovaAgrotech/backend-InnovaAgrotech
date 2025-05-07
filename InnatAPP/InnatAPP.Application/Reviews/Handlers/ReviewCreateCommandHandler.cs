using InnatAPP.Application.Reviews.Commands;
using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnatAPP.Application.Reviews.Handlers
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
            var review = new Review(request.Avaliacao, request.Mensagem, request.IdAvaliador, request.IdProduto);

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
