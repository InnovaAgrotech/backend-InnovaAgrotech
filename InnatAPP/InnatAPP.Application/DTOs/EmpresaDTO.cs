using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnatAPP.Application.DTOs
{
    public class EmpresaDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome inválido, o nome é obrigatório.")]
        [MinLength(2, ErrorMessage = "Nome inválido, o nome deve ter no mínimo 2 caracteres.")]
        [MaxLength(100, ErrorMessage = "Nome inválido, o nome pode ter no máximo 100 caracteres.")]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "E-mail inválido, o e-mail é obrigatório.")]
        [MinLength(5, ErrorMessage = "E-mail inválido, o e-mail deve ter no mínimo 5 caracteres.")]
        [MaxLength(255, ErrorMessage = "E-mail inválido, o e-mail pode ter no máximo 255 caracteres.")]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha inválida, a senha é obrigatória.")]
        [MinLength(8, ErrorMessage = "Senha inválida, a senha deve ter no mínimo 8 caracteres.")]
        [MaxLength(64, ErrorMessage = "Senha inválida, a senha pode ter no máximo 64 caracteres.")]
        [DisplayName("Senha")]
        public string Senha { get; set; }

        [MaxLength(250, ErrorMessage = "URL da imagem inválida, a URL pode ter no máximo 250 caracteres.")]
        [DisplayName("Foto")]
        public string Foto { get; set; }

        [MaxLength(500, ErrorMessage = "Biografia inválida, a biografia pode ter no máximo 500 caracteres.")]
        [DisplayName("Biografia")]
        public string Bio { get; set; }
    }

    public class EmpresaProdutosDTO
    {
        public List<ProdutoDTO> Produtos { get; set; }
    }
}
