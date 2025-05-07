using InnatAPP.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnatAPP.Application.Produtos.Commands
{
    public abstract class ProdutoCommand : IRequest<Produto>
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Avaliacao { get; set; }
        public string Imagem { get; set; }
        public int TotalReviews { get; set; }
        public int IdCategoria { get; set; }
        public int IdEmpresa { get; set; }
    }
}
