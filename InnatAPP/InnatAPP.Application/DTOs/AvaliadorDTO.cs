using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InnatAPP.Application.DTOs
{
    public class AvaliadorDTO
    {
        [Required(ErrorMessage = "O id é obrigatório.")]
        [DisplayName("Id")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O id de usuário é obrigatório.")]
        [DisplayName("Id Usuario")]
        public Guid IdUsuario { get; set; }

        [Required(ErrorMessage = "Os dados do usuário são obrigatórios.")]
        [DisplayName("Usuario")]
        public UsuarioDTO Usuario { get; set; } = new UsuarioDTO();
    }
}