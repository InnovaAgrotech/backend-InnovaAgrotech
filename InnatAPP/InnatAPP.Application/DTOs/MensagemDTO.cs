using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnatAPP.Application.DTOs
{
    public class MensagemDTO
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

        [Required(ErrorMessage = "Mensagem inválida, a mensagem é obrigatória.")]
        [MinLength(2, ErrorMessage = "Mensagem inválida, a mensagem deve ter no mínimo 2 caracteres.")]
        [MaxLength(700, ErrorMessage = "Mensagem inválida, a mensagem pode ter no máximo 700 caracteres.")]
        [DisplayName("Mensagem")]
        public string Texto { get; set; }


    }
}
