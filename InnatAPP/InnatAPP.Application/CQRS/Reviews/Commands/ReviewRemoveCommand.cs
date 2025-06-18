using MediatR;
using InnatAPP.Domain.Entities;

namespace InnatAPP.Application.CQRS.Reviews.Commands
{
    public class ReviewRemoveCommand : IRequest<Review>
    {
        public Guid Id { get; set; }
        public ReviewRemoveCommand(Guid id)
        {
            Id = id;
        }
    }
}