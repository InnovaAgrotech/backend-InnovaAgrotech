using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InnatAPP.Application.DTOs
{
    public class EmailAlternativoDTO
    {
        [Required(ErrorMessage = "O id é obrigatório.")]
        [DisplayName("Id")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [MinLength(6, ErrorMessage = "O e-mail deve ter no mínimo 6 caracteres.")]
        [MaxLength(254, ErrorMessage = "O e-mail pode ter no máximo 254 caracteres.")]
        [DisplayName("Endereco de e-mail")]
        public string EnderecoEmail { get; set; } = string.Empty;

        [Required(ErrorMessage = "O id de usuário é obrigatório.")]
        [DisplayName("Id Usuario")]
        public Guid IdUsuario { get; set; }

        [Required(ErrorMessage = "Os dados do usuário são obrigatórios.")]
        [DisplayName("Usuario")]
        public UsuarioDTO Usuario { get; set; } = new UsuarioDTO();
    }
}