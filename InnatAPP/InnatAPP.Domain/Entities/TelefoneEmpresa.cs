#region Importações

using System.Linq;
using InnatAPP.Domain.Validation;

#endregion

namespace InnatAPP.Domain.Entities
{
    public sealed class TelefoneEmpresa
    {
        #region Atributos

        public const string DDI = "55";

        public int Id { get; set; }
        public string Ddd { get; set; }
        public string Numero { get; set; }
        public int IdEmpresa { get; set; }
        public Empresa Empresa { get; set; }

        #endregion

        #region Construtores

        public TelefoneEmpresa(string ddd, string numero)
        {
            ValidateDomain(ddd, numero);
        }

        public TelefoneEmpresa(int id, string ddd, string numero)
        {
            DomainExceptionValidation.When(id < 0, "Valor de id inválido.");
            Id = id;
            ValidateDomain(ddd, numero);
        }

        #endregion

        #region Métodos

        public void Alterar(string ddd, string numero)
        {
            ValidateDomain(ddd, numero);
        }

        public string ObterNumeroCompleto()
        {
            return $"+{DDI}({Ddd}){Numero}";
        }

        #endregion

        #region Validações

        private void ValidateDomain(string ddd, string numero)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(ddd),
            "Número inválido, o DDD é obrigatório.");

            DomainExceptionValidation.When(!ddd.All(char.IsDigit),
            "Número inválido, o DDD deve conter apenas dígitos.");

            DomainExceptionValidation.When(ddd.Length != 2,
            "Número inválido, o DDD deve ter 2 dígitos.");

            DomainExceptionValidation.When(int.Parse(ddd) < 11 || int.Parse(ddd) > 99,
            "Número inválido, o DDD deve estar entre 11 e 99.");

            DomainExceptionValidation.When(string.IsNullOrEmpty(numero),
            "Número inválido, o número é obrigatório.");

            DomainExceptionValidation.When(!numero.All(char.IsDigit),
            "Número inválido, o número deve conter apenas dígitos.");

            DomainExceptionValidation.When(numero.Length < 8,
            "Número inválido, o número deve ter no mínimo 8 dígitos.");

            DomainExceptionValidation.When(numero.Length > 9,
            "Número inválido, o número deve ter no máximo 9 dígitos.");

            Ddd = ddd;
            Numero = numero;
        }

        #endregion

    }
}
