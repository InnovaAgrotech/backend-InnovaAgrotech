using MediatR;
using InnatAPP.Domain.Entities;

namespace InnatAPP.Application.CQRS.Reviews.Commands
{
    public abstract class ReviewCommand : IRequest<Review>
    {
        public decimal Nota { get; set; }
        public string Resenha { get; set; } = string.Empty;
        public DateTime CriadoEm { get; set; }
        public DateTime AtualizadoEm { get; set; }
        public int Curtidas { get; set; }
        public int Descurtidas { get; set; }
        public Guid IdAvaliador { get; set; }
        public Guid IdProduto { get; set; }
    }
}