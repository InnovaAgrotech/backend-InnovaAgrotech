using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InnatAPP.Application.DTOs
{
    public class CategoriaDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome inválido, o nome é obrigatório.")]
        [MinLength(2)]
        [MaxLength(50)]
        [DisplayName("Nome")]
        public string Nome { get; set; }
    }

    public class CategoriaProdutosDTO : CategoriaDTO 
    {
        public List <ProdutoDTO> Produtos { get; set; }
    }
}