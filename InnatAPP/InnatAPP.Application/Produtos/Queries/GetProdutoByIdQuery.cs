using InnatAPP.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnatAPP.Application.Produtos.Queries
{
    public class GetProdutoByIdQuery : IRequest<Produto>
    {
        public int Id { get; set; }
        public GetProdutoByIdQuery(int id)
        {
            Id = id;
        }
    }
}
