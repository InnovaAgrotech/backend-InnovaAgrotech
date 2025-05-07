using InnatAPP.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnatAPP.Application.Reviews.Queries
{
    public class GetReviewByIdQuery : IRequest<Review>
    {
        public int Id { get; set; }
        public GetReviewByIdQuery(int id)
        {
            Id = id;
        }
    }
}
