using MediatR;
using InnatAPP.Domain.Entities;

namespace InnatAPP.Application.CQRS.Produtos.Commands
{
    public abstract class ProdutoCommand : IRequest<Produto>
    {
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string Foto { get; set; } = string.Empty;
        public decimal Nota { get; set; }
        public int TotalReviews { get; set; }
        public Guid IdCategoria { get; set; }
        public Guid IdEmpresa { get; set; }
    }
}