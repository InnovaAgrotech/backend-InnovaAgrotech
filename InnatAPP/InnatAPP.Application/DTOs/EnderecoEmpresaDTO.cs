using InnatAPP.Domain.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InnatAPP.Application.DTOs
{
    public class EnderecoEmpresaDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Endereço inválido, o número é obrigatório.")]
        [MaxLength(10, ErrorMessage = "Endereço inválido, o número pode ter no máximo 10 dígitos.")]
        [DisplayName("Número")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "Endereço inválido, a rua é obrigatória.")]
        [MinLength(3, ErrorMessage = "Endereço inválido, a rua deve ter no mínimo 3 caracteres.")]
        [MaxLength(100, ErrorMessage = "Endereço inválido, a rua pode ter no máximo 100 caracteres.")]
        [DisplayName("Rua")]
        public string Rua { get; set; }

        [Required(ErrorMessage = "Endereço inválido, o bairro é obrigatório.")]
        [MinLength(3, ErrorMessage = "Endereço inválido, o bairro deve ter no mínimo 3 caracteres.")]
        [MaxLength(60, ErrorMessage = "Endereço inválido, o bairro pode ter no máximo 60 caracteres.")]
        [DisplayName("Bairro")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Endereço inválido, a cidade é obrigatória.")]
        [MinLength(2, ErrorMessage = "Endereço inválido, a cidade deve ter no mínimo 2 caracteres.")]
        [MaxLength(80, ErrorMessage = "Endereço inválido, a cidade pode ter no máximo 80 caracteres.")]
        [DisplayName("Cidade")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Endereço inválido, o estado é obrigatório.")]
        [MinLength(2, ErrorMessage = "Endereço inválido, o estado deve ter 2 letras (UF).")]
        [MaxLength(2, ErrorMessage = "Endereço inválido, o estado deve ter 2 letras (UF).")]
        [DisplayName("Estado")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "Nome inválido, o nome é obrigatório.")]
        [MinLength(8, ErrorMessage = "Endereço inválido, o CEP deve ter 8 dígitos (Sem traço).")]
        [MaxLength(8, ErrorMessage = "Endereço inválido, o CEP deve ter 8 dígitos (Sem traço).")]
        [DisplayName("CEP")]
        public string Cep { get; set; }

        [MaxLength(100, ErrorMessage = "Endereço inválido, o complemento pode ter no máximo 100 caracteres.")]
        [DisplayName("Complemento")]
        public string Complemento { get; set; }

        [DisplayName("Empresa")]
        public int IdEmpresa { get; set; }
        public Empresa Empresa { get; set; }
    }
}
