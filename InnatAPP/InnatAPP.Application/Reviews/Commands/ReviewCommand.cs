using InnatAPP.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnatAPP.Application.Reviews.Commands
{
    public abstract class ReviewCommand : IRequest<Review>
    {
        public string Mensagem { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime AtualizadoEm { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public decimal Avaliacao { get; set; }
        public int IdAvaliador { get; set; }
        public int IdProduto { get; set; }
    }
}
