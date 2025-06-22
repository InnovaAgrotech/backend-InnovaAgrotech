using System.ComponentModel;
using InnatAPP.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace InnatAPP.Application.DTOs.Usuario
{
    public class UsuarioCreateDTO
    {
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

        [Required(ErrorMessage = "A senha é obrigatória.")]
        [MinLength(8, ErrorMessage = "A senha deve ter no mínimo 8 caracteres.")]
        [MaxLength(64, ErrorMessage = "A senha pode ter no máximo 64 caracteres.")]
        [DisplayName("Senha")]
        public string Senha { get; set; } = string.Empty;

        [Required(ErrorMessage = "O tipo de usuário é obrigatório.")]
        [DisplayName("Tipo de Usuário")]
        public string TipoUsuarioTexto { get; set; } = string.Empty;

        public TipoUsuario ToTipoUsuario()
        {
            return TipoUsuario.FromString(TipoUsuarioTexto);
        }
    }
}