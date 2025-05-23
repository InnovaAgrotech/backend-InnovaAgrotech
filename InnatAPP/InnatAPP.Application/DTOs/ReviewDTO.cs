﻿using InnatAPP.Domain.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InnatAPP.Application.DTOs
{
    public class ReviewDTO
    {
        public int Id { get; set; }

        [MaxLength(500, ErrorMessage = "Mensagem inválida, a mensagem pode ter no máximo 500 caracteres.")]
        [DisplayName("Mensagem")]
        public string Mensagem { get; set; }

        [DisplayName("Criado em")]
        public DateTime CriadoEm { get; set; }

        [DisplayName("Atualizado em")]
        public DateTime AtualizadoEm { get; set; }

        [DisplayName("Likes")]
        public int Likes { get; set; }

        [DisplayName("Dislikes")]
        public int Dislikes { get; set; }

        [Range(0, 5, ErrorMessage = "Avaliação inválida, a avaliação deve estar entre 0 e 5.")]
        [DisplayName("Nota")]
        public decimal Avaliacao { get; set; }

        [DisplayName("Avaliador")]
        public int IdAvaliador { get; set; }

        [DisplayName("Produto")]
        public int IdProduto { get; set; }

        public AvaliadorDTO Avaliador { get; set; }

        public ProdutoDTO Produto { get; set; }
    }
}
