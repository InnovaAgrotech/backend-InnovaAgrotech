using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InnatAPP.Application.DTOs.Usuario
{
    public class LoginUsuarioDTO
    {
        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [MinLength(6, ErrorMessage = "O e-mail deve ter no mínimo 6 caracteres.")]
        [MaxLength(254, ErrorMessage = "O e-mail pode ter no máximo 254 caracteres.")]
        [DisplayName("E-mail")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "A senha é obrigatória.")]
        [MinLength(8, ErrorMessage = "A senha deve ter no mínimo 8 caracteres.")]
        [MaxLength(64, ErrorMessage = "A senha pode ter no máximo 64 caracteres.")]
        [DisplayName("Senha")]
        public string Senha { get; set; } = string.Empty;
    }
}