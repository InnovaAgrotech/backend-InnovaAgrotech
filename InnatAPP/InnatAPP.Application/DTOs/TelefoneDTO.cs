using InnatAPP.Application.DTOs.Usuario;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InnatAPP.Application.DTOs
{
    public class TelefoneDTO
    {
        [Required(ErrorMessage = "O id é obrigatório.")]
        [DisplayName("Id")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O DDD é obrigatório.")]
        [MinLength(2, ErrorMessage = "O DDD deve ter 2 dígitos.")]
        [MaxLength(2, ErrorMessage = "O DDD deve ter 2 dígitos.")]
        [DisplayName("DDD")]
        public string Ddd { get; set; } = string.Empty;

        [Required(ErrorMessage = "O número é obrigatório.")]
        [MinLength(8, ErrorMessage = "O número deve ter no mínimo 8 dígitos.")]
        [MaxLength(9, ErrorMessage = "O número pode ter no máximo 9 dígitos.")]
        [DisplayName("Numero")]
        public string Numero { get; set; } = string.Empty;

        [Required(ErrorMessage = "O id de usuário é obrigatório.")]
        [DisplayName("Id Usuario")]
        public Guid IdUsuario { get; set; }

        [Required(ErrorMessage = "Os dados do usuário são obrigatórios.")]
        [DisplayName("Usuario")]
        public UsuarioRespostaDTO Usuario { get; set; } = new UsuarioRespostaDTO();
    }
}