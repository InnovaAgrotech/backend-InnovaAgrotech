using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InnatAPP.Application.DTOs.Produto
{
    public class ProdutoDTO
    {
        [Required(ErrorMessage = "O id é obrigatório.")]
        [DisplayName("Id")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [MinLength(2, ErrorMessage = "O nome deve ter no mínimo 2 caracteres.")]
        [MaxLength(100, ErrorMessage = "O nome pode ter no máximo 100 caracteres.")]
        [DisplayName("Nome")]
        public string Nome { get; set; } = string.Empty;


        [Required(ErrorMessage = "A descrição é obrigatória.")]
        [MinLength(10, ErrorMessage = "A descrição deve ter no mínimo 10 caracteres.")]
        [MaxLength(500, ErrorMessage = "A descrição pode ter no máximo 500 caracteres.")]
        [DisplayName("Descrição")]
        public string Descricao { get; set; } = string.Empty;

        [MaxLength(250, ErrorMessage = "A URL da foto pode ter no máximo 250 caracteres.")]
        [DisplayName("Foto")]
        public string Foto { get; set; } = string.Empty;

        [Range(0, 5, ErrorMessage = "A nota tem ser entre 0 e 5.")]
        [DisplayName("Nota")]
        public decimal Nota { get; set; }

        [DisplayName("Total de Reviews")]
        public int TotalReviews { get; set; }

        [Required(ErrorMessage = "O id de categoria é obrigatório.")]
        [DisplayName("Id Categoria")]
        public Guid IdCategoria { get; set; }

        [Required(ErrorMessage = "O id de empresa é obrigatório.")]
        [DisplayName("Id Empresa")]
        public Guid IdEmpresa { get; set; }

        [Required(ErrorMessage = "Os dados da categoria são obrigatórios.")]
        [DisplayName("Categoria")]
        public CategoriaDTO Categoria { get; set; } = new CategoriaDTO();

        [Required(ErrorMessage = "Os dados da empresa são obrigatórios.")]
        [DisplayName("Empresa")]
        public EmpresaDTO Empresa { get; set; } = new EmpresaDTO();
    }
}