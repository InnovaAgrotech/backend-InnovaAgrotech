using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InnatAPP.Application.DTOs.Usuario
{
    public class UsuarioUpdateDTO
    {
        [Required(ErrorMessage = "O id é obrigatório.")]
        [DisplayName("Id")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O nome de usuário é obrigatório.")]
        [MinLength(3, ErrorMessage = "O nome de usuário deve ter no mínimo 3 caracteres.")]
        [MaxLength(100, ErrorMessage = "O nome de usuário pode ter no máximo 100 caracteres.")]
        [DisplayName("Nome de Usuário")]
        public string Nome { get; set; } = string.Empty;

        [MaxLength(250, ErrorMessage = "A URL da foto pode ter no máximo 250 caracteres.")]
        [DisplayName("Foto")]
        public string Foto { get; set; } = string.Empty;

        [MaxLength(500, ErrorMessage = "A biografia pode ter no máximo 500 caracteres.")]
        [DisplayName("Biografia")]
        public string Biografia { get; set; } = string.Empty;
    }
}