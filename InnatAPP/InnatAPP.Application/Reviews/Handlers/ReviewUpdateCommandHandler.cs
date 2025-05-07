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
                review.Alterar(request.Avaliacao, request.Mensagem);
                return await _reviewRepository.AtualizarReviewAsync(review);
            }
        }
    }
}
