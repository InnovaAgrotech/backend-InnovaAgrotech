#region Importações

using System.Linq;
using System.Collections.Generic;
using InnatAPP.Domain.Validation;
using InnatAPP.Domain.Shared;

#endregion

namespace InnatAPP.Domain.Entities
{
    public sealed class Avaliador : UsuarioBase
    {
        #region Atributos

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Foto { get; set; }
        public string Bio { get; set; }

        #endregion

        #region Coleções

        public ICollection<Review> Reviews { get; set; } = new List<Review>();

        #endregion

        #region Construtores

        public Avaliador(string nome, string email, string senha, string foto, string bio)
        {
            ValidateDomain(nome, email, senha, foto, bio);
        }

        public Avaliador(int id, string nome, string email, string senha, string foto, string bio)
        {
            DomainExceptionValidation.When(id < 0, "Valor de id inválido.");
            Id = id;
            ValidateDomain(nome, email, senha, foto, bio);
        }

        #endregion

        #region Métodos

        public void Atualizar(string nome, string email, string senha, string foto, string bio)
        {
            ValidateDomain(nome, email, senha, foto, bio);
        }

        #endregion

        #region Validações

        private void ValidateDomain(string nome, string email, string senha, string foto, string bio)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome),
            "Nome inválido, o nome é obrigatório.");

            DomainExceptionValidation.When(nome.Length < 2,
            "Nome inválido, o nome deve ter no mínimo 2 caracteres.");

            DomainExceptionValidation.When(nome.Length > 100,
            "Nome inválido, o nome pode ter no máximo 100 caracteres.");

            DomainExceptionValidation.When(string.IsNullOrEmpty(email),
            "E-mail inválido, o e-mail é obrigatório.");

            DomainExceptionValidation.When(email.Length < 5,
            "E-mail inválido, o e-mail deve ter no mínimo 5 caracteres.");

            DomainExceptionValidation.When(email.Length > 255,
            "E-mail inválido, o e-mail pode ter no máximo 255 caracteres.");

            DomainExceptionValidation.When(!email.Contains("@"),
            "E-mail inválido, o e-mail deve conter um '@'.");

            DomainExceptionValidation.When(email.Contains(" "),
            "E-mail inválido, o e-mail não pode conter espaços.");

            DomainExceptionValidation.When(email.Split('@').Length - 1 > 1,
            "E-mail inválido, o e-mail pode ter apenas um '@'.");

            var partesEmail = email.Split('@');
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

            DomainExceptionValidation.When(string.IsNullOrEmpty(senha),
            "Senha inválida, a senha é obrigatória.");

            DomainExceptionValidation.When(senha.Length < 8,
            "Senha inválida, a senha deve ter no mínimo 8 caracteres.");

            DomainExceptionValidation.When(senha.Length > 64,
            "Senha inválida, a senha pode ter no máximo 64 caracteres.");

            DomainExceptionValidation.When(senha.Contains(" "),
            "Senha inválida, a senha não pode conter espaços.");

            DomainExceptionValidation.When(!senha.Any(char.IsUpper),
            "Senha inválida, a senha deve conter pelo menos uma letra maiúscula.");

            DomainExceptionValidation.When(!senha.Any(char.IsLower),
            "Senha inválida, a senha deve conter pelo menos uma letra minúscula.");

            DomainExceptionValidation.When(!senha.Any(char.IsDigit),
            "Senha inválida, a senha deve conter pelo menos um número.");

            DomainExceptionValidation.When(!senha.Intersect(ConstantesValidacao.caracteresEspeciaisPermitidosSenha).Any(),
            $"Senha inválida, a senha deve conter pelo menos um caractere especial. Exemplo: {ConstantesValidacao.caracteresEspeciaisPermitidosSenha}.");

            DomainExceptionValidation.When(foto?.Length > 250,
            "URL da imagem inválida, a URL pode ter no máximo 250 caracteres.");

            DomainExceptionValidation.When(bio?.Length > 500,
            "Biografia inválida, a biografia pode ter no máximo 500 caracteres.");

            Nome = nome;
            Email = email;
            Senha = senha;
            Foto = foto;
            Bio = bio;
        }

        #endregion
    }
}