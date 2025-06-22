using InnatAPP.Application.DTOs.Usuario;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InnatAPP.Application.DTOs
{
    public class EnderecoDTO
    {
        [Required(ErrorMessage = "O id é obrigatório.")]
        [DisplayName("Id")]
        public Guid Id { get; set; }

        [MaxLength(10, ErrorMessage = "O número pode ter no máximo 10 caracteres.")]
        [DisplayName("Número")]
        public string Numero { get; set; } = "S/N";

        [Required(ErrorMessage = "A rua é obrigatória.")]
        [MinLength(3, ErrorMessage = "A rua deve ter no mínimo 3 caracteres.")]
        [MaxLength(100, ErrorMessage = "A rua pode ter no máximo 100 caracteres.")]
        [DisplayName("Rua")]
        public string Rua { get; set; } = string.Empty;

        [Required(ErrorMessage = "O bairro é obrigatório.")]
        [MinLength(3, ErrorMessage = "O bairro deve ter no mínimo 3 caracteres.")]
        [MaxLength(60, ErrorMessage = "O bairro pode ter no máximo 60 caracteres.")]
        [DisplayName("Bairro")]
        public string Bairro { get; set; } = string.Empty;

        [Required(ErrorMessage = "A cidade é obrigatória.")]
        [MinLength(2, ErrorMessage = "A cidade deve ter no mínimo 2 caracteres.")]
        [MaxLength(80, ErrorMessage = "A cidade pode ter no máximo 80 caracteres.")]
        [DisplayName("Cidade")]
        public string Cidade { get; set; } = string.Empty;

        [Required(ErrorMessage = "O estado é obrigatório.")]
        [MinLength(2, ErrorMessage = "O estado deve ter 2 letras (UF).")]
        [MaxLength(2, ErrorMessage = "O estado deve ter 2 letras (UF).")]
        [DisplayName("Estado")]
        public string Estado { get; set; } = string.Empty;

        [MaxLength(100, ErrorMessage = "O complemento pode ter no máximo 100 caracteres.")]
        [DisplayName("Complemento")]
        public string Complemento { get; set; } = string.Empty;

        [Required(ErrorMessage = "O CEP é obrigatório.")]
        [MinLength(8, ErrorMessage = "O CEP deve ter 8 dígitos (Sem traço).")]
        [MaxLength(8, ErrorMessage = "O CEP deve ter 8 dígitos (Sem traço).")]
        [DisplayName("CEP")]
        public string Cep { get; set; } = string.Empty;

        [Required(ErrorMessage = "O id de usuário é obrigatório.")]
        [DisplayName("Id Usuario")]
        public Guid IdUsuario { get; set; }

        [Required(ErrorMessage = "Os dados do usuário são obrigatórios.")]
        [DisplayName("Usuario")]
        public UsuarioRespostaDTO Usuario { get; set; } = new UsuarioRespostaDTO();
    }
}