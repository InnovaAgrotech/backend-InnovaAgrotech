using InnatAPP.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnatAPP.Application.Produtos.Commands
{
    public class ProdutoRemoveCommand : IRequest<Produto>
    {
        public int Id { get; set; }
        public ProdutoRemoveCommand(int id)
        {
            Id = id;
        }
    }
}
