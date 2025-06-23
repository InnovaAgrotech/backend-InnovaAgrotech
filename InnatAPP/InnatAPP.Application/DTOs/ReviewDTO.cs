using InnatAPP.Application.DTOs.Produto;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InnatAPP.Application.DTOs
{
    public class ReviewDTO
    {
        [Required(ErrorMessage = "O id é obrigatório.")]
        [DisplayName("Id")]
        public Guid Id { get; set; }

        [Range(0, 5, ErrorMessage = "A nota tem ser entre 0 e 5.")]
        [DisplayName("Nota")]
        public decimal Nota { get; set; }

        [MaxLength(500, ErrorMessage = "A resenha pode ter no máximo 500 caracteres.")]
        [DisplayName("Resenha")]
        public string Resenha { get; set; } = string.Empty;

        [DisplayName("Criado em")]
        public DateTime CriadoEm { get; set; }

        [DisplayName("Atualizado em")]
        public DateTime AtualizadoEm { get; set; }

        [DisplayName("Curtidas")]
        public int Curtidas { get; set; }

        [DisplayName("Descurtidas")]
        public int Descurtidas { get; set; }

        [Required(ErrorMessage = "O id de avaliador é obrigatório.")]
        [DisplayName("Id Avaliador")]
        public Guid IdAvaliador { get; set; }

        [Required(ErrorMessage = "O id de produto é obrigatório.")]
        [DisplayName("Id Produto")]
        public Guid IdProduto { get; set; }

        [Required(ErrorMessage = "Os dados do avaliador são obrigatórios.")]
        [DisplayName("Avaliador")]
        public AvaliadorDTO Avaliador { get; set; } = new AvaliadorDTO();

        [Required(ErrorMessage = "Os dados do produto são obrigatórios.")]
        [DisplayName("Produto")]
        public ProdutoDTO Produto { get; set; } = new ProdutoDTO();
    }
}