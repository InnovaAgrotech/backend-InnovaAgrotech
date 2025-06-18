using InnatAPP.Domain.Validation;

namespace InnatAPP.Domain.Entities
{
    public class Telefone
    {
        #region Propriedades

        public const string Ddi = "55";

        public Guid Id { get; private set; }
        public string Ddd { get; private set; } = string.Empty;
        public string Numero { get; private set; } = string.Empty;

        #endregion

        #region Chaves Estrangeiras

        public Guid IdUsuario { get; private set; }

        #endregion

        #region Propriedades de Navegação

        public Usuario Usuario { get; private set; } = null!;

        #endregion

        #region Construtores

        public Telefone() { }

        public Telefone(string ddd, string numero, Guid idUsuario)
        {
            #region Validações de Entrada

            ValidateDomain(ddd, numero);

            DomainExceptionValidation.When(idUsuario == Guid.Empty, "O id de usuário é obrigatório.");

            #endregion

            #region Inicialização das Propriedades

            Id = Guid.NewGuid();
            IdUsuario = idUsuario;

            #endregion
        }

        public Telefone(Guid id, string ddd, string numero, Guid idUsuario)
        {
            #region Validações de Entrada

            DomainExceptionValidation.When(id == Guid.Empty, "O id é obrigatório.");

            ValidateDomain(ddd, numero);

            DomainExceptionValidation.When(idUsuario == Guid.Empty, "O id de usuário é obrigatório.");

            #endregion

            #region Inicialização das Propriedades

            Id = id;
            IdUsuario = idUsuario;

            #endregion
        }

        #endregion

        #region Métodos Públicos

        public void Alterar(string ddd, string numero)
        {
            ValidateDomain(ddd, numero);
        }

        public string ObterNumeroCompleto()
        {
            return $"+{Ddi}({Ddd}){Numero}";
        }

        #endregion

        #region Validações de Domínio

        private void ValidateDomain(string ddd, string numero)
        {
            #region Validações de DDD

            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(ddd),
            "O DDD é obrigatório.");

            DomainExceptionValidation.When(!ddd.All(char.IsDigit),
            "O DDD deve conter apenas dígitos.");

            DomainExceptionValidation.When(ddd.Length != 2,
            "O DDD deve ter 2 dígitos.");

            DomainExceptionValidation.When(int.Parse(ddd) < 11 || int.Parse(ddd) > 99,
            "O DDD deve estar entre 11 e 99.");

            #endregion

            #region Validações de Número

            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(numero),
            "O número é obrigatório.");

            DomainExceptionValidation.When(!numero.All(char.IsDigit),
            "O número deve conter apenas dígitos.");

            DomainExceptionValidation.When(numero.Length < 8,
            "O número deve ter no mínimo 8 dígitos.");

            DomainExceptionValidation.When(numero.Length > 9,
            "O número pode ter no máximo 9 dígitos.");

            #endregion

            #region Inicialização das Propriedades

            Ddd = ddd;
            Numero = numero;

            #endregion
        }

        #endregion
    }
}