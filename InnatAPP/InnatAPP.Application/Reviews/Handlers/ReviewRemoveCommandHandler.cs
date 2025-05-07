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
                var result = await _reviewRepository.DeletarReviewAsync(review);
                return result;
            }
        }
    }
}
