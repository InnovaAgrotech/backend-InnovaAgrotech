﻿using InnatAPP.Application.Produtos.Commands;
using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnatAPP.Application.Produtos.Handlers
{
    public class ProdutoCreateCommandHandler : IRequestHandler<ProdutoCreateCommand, Produto>
    {
        private readonly IProdutoRepository _produtoRepository;
        public ProdutoCreateCommandHandler(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }
        public async Task<Produto> Handle(ProdutoCreateCommand request, 
            CancellationToken cancellationToken)
        {
            var produto = new Produto(request.Nome, request.Descricao, 
                request.Imagem, request.IdCategoria, request.IdEmpresa);

            if (produto == null)
            {
                throw new ApplicationException($"Erro ao criar entidade.");
            }
            else
            {
                produto.IdCategoria = request.IdCategoria;
                return await _produtoRepository.CriarProdutoAsync(produto);
            }
        }
    }
}
