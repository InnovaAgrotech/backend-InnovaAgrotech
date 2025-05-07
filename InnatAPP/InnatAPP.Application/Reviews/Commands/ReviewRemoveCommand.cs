using InnatAPP.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnatAPP.Application.Reviews.Commands
{
    public class ReviewRemoveCommand : IRequest<Review>
    {
        public int Id { get; set; }
        public ReviewRemoveCommand(int id)
        {
            Id = id;
        }
    }
}
