#region Importações

using InnatAPP.Domain.Shared;
using InnatAPP.Domain.Validation;

#endregion

namespace InnatAPP.Domain.Entities
{
    public sealed class Mensagem
    {
        #region Atributos

        public int Id { get; set; }
        public string Nome { get; set; } 
        public string Email { get; set; } 
        public string Texto { get; set; }

        #endregion

        #region Construtores

        public Mensagem(string nome, string email, string texto)
        {
            ValidateDomain(nome, email, texto);
        }

        public Mensagem(int id, string nome, string email, string texto)
        {
            DomainExceptionValidation.When(id < 0, "Valor de id inválido.");
            Id = id;
            ValidateDomain(nome, email, texto);
        }

        #endregion

        #region Métodos

        public void Alterar(string nome, string email, string texto)
        {
            ValidateDomain(nome, email, texto);
        }

        #endregion

        #region Validações

        private void ValidateDomain(string nome, string email, string texto)
        {
            #region Validações de nome

            DomainExceptionValidation.When(string.IsNullOrEmpty(nome),
            "Nome inválido, o nome é obrigatório.");

            DomainExceptionValidation.When(nome.Length < 2,
            "Nome inválido, o nome deve ter no mínimo 2 caracteres.");

            DomainExceptionValidation.When(nome.Length > 100,
            "Nome inválido, o nome pode ter no máximo 100 caracteres.");

            #endregion

            #region Validações de e-mail

            #region Validações gerais de e-mail

            DomainExceptionValidation.When(string.IsNullOrEmpty(email),
            "E-mail inválido, o e-mail é obrigatório.");

            DomainExceptionValidation.When(email.Length < 5,
            "E-mail inválido, o e-mail deve ter no mínimo 5 caracteres.");

            DomainExceptionValidation.When(email.Length > 255,
            "E-mail inválido, o e-mail pode ter no máximo 255 caracteres.");

            DomainExceptionValidation.When(!email.Contains('@'),
            "E-mail inválido, o e-mail deve conter um '@'.");

            DomainExceptionValidation.When(email.Contains(' '),
            "E-mail inválido, o e-mail não pode conter espaços.");

            DomainExceptionValidation.When(email.Split('@').Length - 1 > 1,
            "E-mail inválido, o e-mail pode ter apenas um '@'.");

            #endregion

            #region Validações de nome de usuário do e-mail

            var partesEmail = email.Split('@');
            var nomeUsuario = partesEmail.Length > 0 ? partesEmail[0] : string.Empty;
            var dominio = partesEmail.Length > 1 ? partesEmail[1] : string.Empty;

            DomainExceptionValidation.When(partesEmail.Length == 2 && string.IsNullOrEmpty(nomeUsuario),
            "E-mail inválido, o nome de usuário é obrigatório.");

            DomainExceptionValidation.When(partesEmail.Length == 2 && nomeUsuario.StartsWith("."),
            "E-mail inválido, o email não pode começar com ponto (.).");

            DomainExceptionValidation.When(partesEmail.Length == 2 && nomeUsuario.EndsWith("."),
            "E-mail inválido, o nome de usuário não pode terminar com ponto (.).");

            DomainExceptionValidation.When(partesEmail.Length == 2 && nomeUsuario.Intersect(ConstantesValidacao.caracteresInvalidosEmailUsuario).Any(),
            $"E-mail inválido, o nome de usuário não pode conter: {new string(ConstantesValidacao.caracteresInvalidosEmailUsuario)}.");

            #endregion

            #region Validações de domínio do e-mail

            DomainExceptionValidation.When(partesEmail.Length == 2 && string.IsNullOrEmpty(dominio),
            "E-mail inválido, o domínio é obrigatório.");

            DomainExceptionValidation.When(partesEmail.Length == 2 && !dominio.Contains('.'),
             "E-mail inválido, o domínio deve conter pelo menos um '.' (Exemplo: gmail.com).");

            DomainExceptionValidation.When(partesEmail.Length == 2 && dominio.StartsWith("-"),
            "E-mail inválido, o domínio não pode começar com hífen (-).");

            DomainExceptionValidation.When(partesEmail.Length == 2 && dominio.EndsWith("-"),
            "E-mail inválido, o e-mail não pode terminar com hífen (-).");

            DomainExceptionValidation.When(partesEmail.Length == 2 && dominio.Intersect(ConstantesValidacao.caracteresInvalidosEmailDominio).Any(),
            $"E-mail inválido, o domínio não pode conter: {new string(ConstantesValidacao.caracteresInvalidosEmailDominio)}.");

            #endregion

            #region Validações de texto

            DomainExceptionValidation.When(string.IsNullOrEmpty(texto),
            "Mensagem inválida, a mensagem é obrigatória.");

            DomainExceptionValidation.When(texto.Length < 2,
            "Mensagem inválida, a mensagem deve ter no mínimo 2 caracteres.");

            DomainExceptionValidation.When(texto.Length > 700,
            "Mensagem inválida, a mensagem pode ter no máximo 700 caracteres.");

            #endregion

            #endregion

            Nome = nome;
            Email = email;
            Texto = texto;
        }

        #endregion
    }
}