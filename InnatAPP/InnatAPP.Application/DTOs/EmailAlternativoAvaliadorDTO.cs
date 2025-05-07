using InnatAPP.Domain.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InnatAPP.Application.DTOs
{
    public class EmailAlternativoAvaliadorDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "E-mail inválido, o e-mail é obrigatório.")]
        [MinLength(5, ErrorMessage = "E-mail inválido, o e-mail deve ter no mínimo 5 caracteres.")]
        [MaxLength(255, ErrorMessage = "E-mail inválido, o e-mail pode ter no máximo 255 caracteres.")]
        [DisplayName("E-mail")]
        public string EnderecoEmail { get; set; }

        [DisplayName("Avaliador")]
        public int IdAvaliador { get; set; }
        public AvaliadorDTO Avaliador { get; set; }
    }
}
