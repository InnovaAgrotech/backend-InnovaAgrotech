using InnatAPP.Domain.Validation;

namespace InnatAPP.Domain.Entities
{
    public class Endereco
    {
        #region Propriedades

        public Guid Id { get; private set; }
        public string Numero { get; private set; } = "S/N";
        public string Rua { get; private set; } = string.Empty;
        public string Bairro { get; private set; } = string.Empty;
        public string Cidade { get; private set; } = string.Empty;
        public string Estado { get; private set; } = string.Empty;
        public string Complemento { get; private set; } = string.Empty;
        public string Cep { get; private set; } = string.Empty;

        #endregion

        #region Chaves Estrangeiras

        public Guid IdUsuario { get; private set; }

        #endregion

        #region Propriedades de Navegação

        public Usuario Usuario { get; private set; } = null!;

        #endregion

        #region Construtores

        public Endereco() { }

        public Endereco(string numero, string rua, string bairro, string cidade, string estado, string complemento, string cep, Guid idUsuario)
        {
            #region Validações de Entrada

            ValidateDomain(numero, rua, bairro, cidade, estado, complemento, cep);

            DomainExceptionValidation.When(idUsuario == Guid.Empty, "O id de usuário é obrigatório.");

            #endregion

            #region Inicialização das Propriedades


            Id = Guid.NewGuid();
            IdUsuario = idUsuario;

            #endregion
        }

        public Endereco(Guid id, string numero, string rua, string bairro, string cidade, string estado, string complemento, string cep, Guid idUsuario)
        {
            #region Validações de Entrada

            DomainExceptionValidation.When(id == Guid.Empty, "O id é obrigatório.");

            ValidateDomain(numero, rua, bairro, cidade, estado, complemento, cep);

            DomainExceptionValidation.When(idUsuario == Guid.Empty, "O id de usuário é obrigatório.");

            #endregion

            #region Inicialização das Propriedades

            Id = id;
            IdUsuario = idUsuario;

            #endregion
        }

        #endregion

        #region Métodos Públicos

        public void Alterar(string numero, string rua, string bairro, string cidade, string estado, string complemento, string cep)
        {
            ValidateDomain(numero, rua, bairro, cidade, estado, complemento, cep);
        }

        #endregion

        #region Validações de Domínio

        private void ValidateDomain(string? numero, string rua, string bairro, string cidade, string estado, string complemento, string cep)
        {
            #region Validações de Número

            DomainExceptionValidation.When(numero?.Length > 10,
            "O número pode ter no máximo 10 caracteres.");

            #endregion

            #region Validações de Rua

            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(rua),
            "A rua é obrigatória.");

            DomainExceptionValidation.When(rua.Length < 3,
            "A rua deve ter no mínimo 3 caracteres.");

            DomainExceptionValidation.When(rua.Length > 100,
            "A rua pode ter no máximo 100 caracteres.");

            #endregion

            #region Validações de Bairro

            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(bairro),
            "O bairro é obrigatório.");

            DomainExceptionValidation.When(bairro.Length < 3,
            "O bairro deve ter no mínimo 3 caracteres.");

            DomainExceptionValidation.When(bairro.Length > 60,
            "O bairro pode ter no máximo 60 caracteres.");

            #endregion

            #region Validações de Cidade

            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(cidade),
            "A cidade é obrigatória.");

            DomainExceptionValidation.When(cidade.Length < 2,
            "A cidade deve ter no mínimo 2 caracteres.");

            DomainExceptionValidation.When(cidade.Length > 80,
            "A cidade pode ter no máximo 80 caracteres.");

            #endregion

            #region Validações de Estado

            DomainExceptionValidation.When(string.IsNullOrEmpty(estado),
            "O estado é obrigatório.");

            DomainExceptionValidation.When(!estado.All(char.IsLetter),
            "O estado deve conter apenas letras.");

            DomainExceptionValidation.When(estado.Length != 2,
            "O estado deve ter 2 letras (UF).");

            #endregion

            #region Validações de Complemento 

            DomainExceptionValidation.When(!string.IsNullOrWhiteSpace(complemento) && complemento.Length > 100,
            "O complemento pode ter no máximo 100 caracteres.");

            #endregion

            #region Validações de CEP

            DomainExceptionValidation.When(string.IsNullOrEmpty(cep),
            "O CEP é obrigatório.");

            DomainExceptionValidation.When(!cep.All(char.IsDigit),
            "O CEP deve conter apenas dígitos.");

            DomainExceptionValidation.When(cep.Length != 8,
            "O CEP deve ter 8 dígitos (Sem traço).");

            #endregion

            #region Inicialização das Propriedades

            Numero = numero ??  "S/N";
            Rua = rua;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            Complemento = complemento;
            Cep = cep;

            #endregion
        }

        #endregion
    }
}