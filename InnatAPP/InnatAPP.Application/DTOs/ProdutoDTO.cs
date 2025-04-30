using InnatAPP.Domain.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InnatAPP.Application.DTOs
{
    public class ProdutoDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome inválido, o nome é obrigatório.")]
        [MinLength(2, ErrorMessage = "Nome inválido, o nome deve ter no mínimo 2 caracteres.")]
        [MaxLength(100, ErrorMessage = "Nome inválido, o nome pode ter no máximo 100 caracteres.")]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Descrição inválida, a descrição é obrigatória.")]
        [MinLength(10, ErrorMessage = "Descrição inválida, a descrição deve ter no mínimo 10 caracteres.")]
        [MaxLength(500, ErrorMessage = "Descrição inválida, a descrição pode ter no máximo 500 caracteres.")]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [Range(0, 5, ErrorMessage = "Avaliação inválida, o valor de avaliação tem ser entre 0 e 5.")]
        [DisplayName("Avaliação")]
        public decimal Avaliacao { get; set; }

        [MaxLength(250, ErrorMessage = "URL da imagem inválida, a URL pode ter no máximo 250 caracteres.")]
        [DisplayName("Imagem do produto")]
        public string Imagem { get; set; }

        [DisplayName("Total de reviews")]
        public int TotalReviews { get; set; }

        public Categoria Categoria { get; set; }

        [DisplayName("Categoria")]
        public int IdCategoria { get; set; }

        [DisplayName("Empresa")]
        public int IdEmpresa { get; set; }

    }
}
