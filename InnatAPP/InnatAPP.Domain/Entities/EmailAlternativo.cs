#region Importações

using System.Linq;
using InnatAPP.Domain.Validation;
using InnatAPP.Domain.Shared;

#endregion

namespace InnatAPP.Domain.Entities
{
    public sealed class EmailAlternativo
    {
        #region Atributos

        public int Id { get; set; }
        public string EnderecoEmail { get; set; }
        public int UsuarioBaseId { get; set; }
        public UsuarioBase UsuarioBase { get; set; }

        #endregion

        #region Construtores

        public EmailAlternativo(string enderecodeemail)
        {
            ValidateDomain(enderecodeemail);
        }

        public EmailAlternativo(int id, string enderecodeemail)
        {
            DomainExceptionValidation.When(id < 0, "Valor de id inválido.");
            Id = id;
            ValidateDomain(enderecodeemail);
        }

        #endregion

        #region Métodos

        public void Atualizar(string enderecodeemail)
        {
            ValidateDomain(enderecodeemail);
        }

        #endregion

        #region Validações

        private void ValidateDomain(string enderecodeemail)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(enderecodeemail),
            "E-mail inválido, o e-mail é obrigatório.");

            DomainExceptionValidation.When(enderecodeemail.Length < 5,
            "E-mail inválido, o e-mail deve ter no mínimo 5 caracteres.");

            DomainExceptionValidation.When(enderecodeemail.Length > 255,
            "E-mail inválido, o e-mail pode ter no máximo 255 caracteres.");

            DomainExceptionValidation.When(!enderecodeemail.Contains("@"),
            "E-mail inválido, o e-mail deve conter um '@'.");

            DomainExceptionValidation.When(enderecodeemail.Contains(" "),
            "E-mail inválido, o e-mail não pode conter espaços.");

            DomainExceptionValidation.When(enderecodeemail.Split('@').Length - 1 > 1,
            "E-mail inválido, o e-mail pode ter apenas um '@'.");

            var partesEmail = enderecodeemail.Split('@');
            var nomeUsuario = partesEmail.Length > 0 ? partesEmail[0] : null;
            var dominio = partesEmail.Length > 1 ? partesEmail[1] : null;

            DomainExceptionValidation.When(partesEmail.Length == 2 && string.IsNullOrEmpty(nomeUsuario),
            "E-mail inválido, o nome de usuário é obrigatório.");

            DomainExceptionValidation.When(partesEmail.Length == 2 && nomeUsuario.StartsWith("."),
            "E-mail inválido, o email não pode começar com ponto (.).");

            DomainExceptionValidation.When(partesEmail.Length == 2 && nomeUsuario.EndsWith("."),
            "E-mail inválido, o nome de usuário não pode terminar com ponto (.).");

            DomainExceptionValidation.When(partesEmail.Length == 2 && nomeUsuario.Intersect(ConstantesValidacao.caracteresInvalidosEmailUsuario).Any(),
            $"E-mail inválido, o nome de usuário não pode conter: {ConstantesValidacao.caracteresInvalidosEmailUsuario}.");

            DomainExceptionValidation.When(partesEmail.Length == 2 && string.IsNullOrEmpty(dominio),
            "E-mail inválido, o domínio é obrigatório.");

            DomainExceptionValidation.When(partesEmail.Length == 2 && !dominio.Contains("."),
             "E-mail inválido, o domínio deve conter pelo menos um '.' (Exemplo: gmail.com).");

            DomainExceptionValidation.When(partesEmail.Length == 2 && dominio.StartsWith("-"),
            "E-mail inválido, o domínio não pode começar com hífen (-).");

            DomainExceptionValidation.When(partesEmail.Length == 2 && dominio.EndsWith("-"),
            "E-mail inválido, o e-mail não pode terminar com hífen (-).");

            DomainExceptionValidation.When(partesEmail.Length == 2 && dominio.Intersect(ConstantesValidacao.caracteresInvalidosEmailDominio).Any(),
            $"E-mail inválido, o domínio não pode conter: {ConstantesValidacao.caracteresInvalidosEmailDominio}.");

            EnderecoEmail = enderecodeemail;
        }

        #endregion
    }
}