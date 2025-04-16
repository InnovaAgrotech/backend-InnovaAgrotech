#region Importações

using System.Linq;
using InnatAPP.Domain.Validation;

#endregion

namespace InnatAPP.Domain.Entities
{
    public sealed class Endereco
    {
        #region Atributos

        public int Id { get; set; }
        public string Numero { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
        public string Complemento { get; set; }
        public int UsuarioBaseId { get; set; }
        public UsuarioBase UsuarioBase { get; set; }

        #endregion

        #region Construtores

        public Endereco(string numero, string rua, string bairro, string cidade, string estado, string cep, string complemento)
        {
            ValidateDomain(numero, rua, bairro, cidade, estado, cep, complemento);
        }

        public Endereco(int id, string numero, string rua, string bairro, string cidade, string estado, string cep, string complemento)
        {
            DomainExceptionValidation.When(id < 0, "Valor de id inválido.");
            Id = id;
            ValidateDomain(numero, rua, bairro, cidade, estado, cep, complemento);
        }

        #endregion

        #region Métodos

        public void Atualizar(string numero, string rua, string bairro, string cidade, string estado, string cep, string complemento)
        {
            ValidateDomain(numero, rua, bairro, cidade, estado, cep, complemento);
        }

        #endregion

        #region Validações

        private void ValidateDomain(string numero, string rua, string bairro, string cidade, string estado, string cep, string complemento)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(numero),
            "Endereço inválido, o número é obrigatório.");

            DomainExceptionValidation.When(!numero.All(char.IsDigit),
            "Endereço inválido, o número deve conter apenas dígitos.");

            DomainExceptionValidation.When(numero.Length > 10,
            "Endereço inválido, o número pode ter no máximo 10 dígitos.");

            DomainExceptionValidation.When(string.IsNullOrEmpty(rua),
            "Endereço inválido, a rua é obrigatória.");

            DomainExceptionValidation.When(rua.Length < 3,
            "Endereço inválido, a rua deve ter no mínimo 3 caracteres.");

            DomainExceptionValidation.When(rua.Length > 100,
            "Endereço inválido, a rua pode ter no máximo 100 caracteres.");

            DomainExceptionValidation.When(string.IsNullOrEmpty(bairro),
            "Endereço inválido, o bairro é obrigatório.");

            DomainExceptionValidation.When(bairro.Length < 3,
            "Endereço inválido, o bairro deve ter no mínimo 3 caracteres.");

            DomainExceptionValidation.When(bairro.Length > 60,
            "Endereço inválido, o bairro pode ter no máximo 60 caracteres.");

            DomainExceptionValidation.When(string.IsNullOrEmpty(cidade),
            "Endereço inválido, a cidade é obrigatória.");

            DomainExceptionValidation.When(cidade.Length < 2,
            "Endereço inválido, a cidade deve ter no mínimo 2 caracteres.");

            DomainExceptionValidation.When(cidade.Length > 80,
            "Endereço inválido, a cidade pode ter no máximo 80 caracteres.");

            DomainExceptionValidation.When(string.IsNullOrEmpty(estado),
            "Endereço inválido, o estado é obrigatório.");

            DomainExceptionValidation.When(!estado.All(char.IsLetter),
            "Endereço inválido, o estado deve conter apenas letras.");

            DomainExceptionValidation.When(estado.Length != 2,
            "Endereço inválido, o estado deve ter 2 letras (UF).");

            DomainExceptionValidation.When(string.IsNullOrEmpty(cep),
            "Endereço inválido, o CEP é obrigatório.");

            DomainExceptionValidation.When(!cep.All(char.IsDigit),
            "Endereço inválido, o CEP deve conter apenas dígitos.");

            DomainExceptionValidation.When(cep.Length != 8,
            "Endereço inválido, o CEP deve ter 8 dígitos (Sem traço).");

            DomainExceptionValidation.When(!string.IsNullOrEmpty(complemento) && complemento.Length > 100,
            "Endereço inválido, o complemento pode ter no máximo 100 caracteres.");

            Numero = numero;
            Rua = rua;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            Cep = cep;
            Complemento = complemento;
        }

        #endregion
    }
}
