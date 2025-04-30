using InnatAPP.Domain.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InnatAPP.Application.DTOs
{
    public class TelefoneAvaliadorDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Número inválido, o DDD é obrigatório.")]
        [MinLength(2, ErrorMessage = "Número inválido, o DDD deve ter 2 dígitos.")]
        [MaxLength(2, ErrorMessage = "Número inválido, o DDD deve ter 2 dígitos.")]
        [DisplayName("DDD")]
        public string Ddd { get; set; }

        [Required(ErrorMessage = "Número inválido, o número é obrigatório.")]
        [MinLength(8, ErrorMessage = "Número inválido, o número deve ter no mínimo 8 dígitos.")]
        [MaxLength(9, ErrorMessage = "Número inválido, o número deve ter no máximo 9 dígitos.")]
        [DisplayName("Numero")]
        public string Numero { get; set; }

        [DisplayName("Avaliador")]
        public int IdAvaliador { get; set; }
        public Avaliador Avaliador { get; set; }
    }
}
