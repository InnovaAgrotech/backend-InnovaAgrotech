using InnatAPP.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnatAPP.Application.Reviews.Queries
{
    public class GetReviewsPorAvaliadorQuery : IRequest<IEnumerable<Review>>
    {
        public int IdAvaliador { get; set; }

        public GetReviewsPorAvaliadorQuery(int idAvaliador)
        {
            IdAvaliador = idAvaliador;
        }
    }
}
