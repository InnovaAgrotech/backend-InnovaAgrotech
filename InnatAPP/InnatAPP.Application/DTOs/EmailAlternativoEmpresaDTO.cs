using InnatAPP.Domain.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InnatAPP.Application.DTOs
{
    public class EmailAlternativoEmpresaDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "E-mail inválido, o e-mail é obrigatório.")]
        [MinLength(5, ErrorMessage = "E-mail inválido, o e-mail deve ter no mínimo 5 caracteres.")]
        [MaxLength(255, ErrorMessage = "E-mail inválido, o e-mail pode ter no máximo 255 caracteres.")]
        [DisplayName("E-mail")]
        public string EnderecoEmail { get; set; }

        [DisplayName("Empresa")]
        public int IdEmpresa { get; set; }
        public EmpresaDTO Empresa { get; set; }
    }
}
