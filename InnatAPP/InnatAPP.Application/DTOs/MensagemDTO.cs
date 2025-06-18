using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InnatAPP.Application.DTOs
{
    public class MensagemDTO
    {
        [Required(ErrorMessage = "O id é obrigatório.")]
        [DisplayName("Id")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O nome de usuário é obrigatório.")]
        [MinLength(3, ErrorMessage = "O nome de usuário deve ter no mínimo 3 caracteres.")]
        [MaxLength(100, ErrorMessage = "O nome de usuário pode ter no máximo 100 caracteres.")]
        [DisplayName("Nome de Usuário")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [MinLength(6, ErrorMessage = "O e-mail deve ter no mínimo 6 caracteres.")]
        [MaxLength(254, ErrorMessage = "O e-mail pode ter no máximo 254 caracteres.")]
        [DisplayName("E-mail")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "A mensagem é obrigatória.")]
        [MinLength(5, ErrorMessage = "A mensagem deve ter no mínimo 5 caracteres.")]
        [MaxLength(700, ErrorMessage = "A mensagem pode ter no máximo 700 caracteres.")]
        [DisplayName("Mensagem")]
        public string Texto { get; set; } = string.Empty;
    }
}