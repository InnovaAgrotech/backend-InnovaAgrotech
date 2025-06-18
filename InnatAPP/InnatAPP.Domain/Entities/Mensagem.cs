using InnatAPP.Domain.Shared;
using InnatAPP.Domain.Validation;
using System.Text.RegularExpressions;

namespace InnatAPP.Domain.Entities
{
    public class Mensagem
    {
        #region Propriedades

        public Guid Id { get; private set; }
        public string Nome { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string Texto { get; private set; } = string.Empty;

        #endregion

        #region Construtores

        public Mensagem() { }

        public Mensagem(string nome, string email, string texto)
        {
            #region Validações de Entrada

            ValidateDomain(nome, email, texto);

            #endregion

            #region Inicialização das Propriedades

            Id = Guid.NewGuid();

            #endregion
        }

        public Mensagem(Guid id, string nome, string email, string texto)
        {
            #region Validações de Entrada

            DomainExceptionValidation.When(id == Guid.Empty, "O id é obrigatório.");

            ValidateDomain(nome, email, texto);

            #endregion

            #region Inicialização das Propriedades

            Id = id;

            #endregion
        }

        #endregion

        #region Validações de Domínio

        private void ValidateDomain(string nome, string email, string texto)
        {
            #region Validações de Nome

            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(nome),
            "O nome é obrigatório.");

            DomainExceptionValidation.When(nome.StartsWith(' '),
            "O nome não pode começar com espaço (\" \").");

            DomainExceptionValidation.When(nome.EndsWith(' '),
            "O nome não pode terminar com espaço (\" \").");

            DomainExceptionValidation.When(ConstantesValidacao.EspacosConsecutivos.IsMatch(nome),
            "O nome não pode ter espaços consecutivos (\"  \", \"   \", \"    \" e etc).");

            DomainExceptionValidation.When(nome.Length < 3,
            "O nome deve ter no mínimo 3 caracteres.");

            DomainExceptionValidation.When(nome.Length > 100,
            "O nome pode ter no máximo 100 caracteres.");

            #endregion

            #region Validações de E-mail

            #region Validações Gerais de E-mail

            DomainExceptionValidation.When(string.IsNullOrEmpty(email),
            "O e-mail é obrigatório.");

            DomainExceptionValidation.When(email.Length < 6,
            "O e-mail deve ter no mínimo 6 caracteres.");

            DomainExceptionValidation.When(email.Length > 254,
            "O e-mail pode ter no máximo 254 caracteres.");

            DomainExceptionValidation.When(!email.Contains('@'),
            "O e-mail deve conter um arroba (@).");

            DomainExceptionValidation.When(email.Contains(' '),
            "O e-mail não pode conter espaços.");

            DomainExceptionValidation.When(email.Count(c => c == '@') > 1,
            "O e-mail pode ter apenas um arroba (@).");

            #endregion

            #region Separação das Partes de E-mail

            var partesEmail = email.Split('@', 2);
            var nomeUsuario = partesEmail[0];
            var dominio = partesEmail[1];

            #endregion

            if (partesEmail.Length == 2)
            {
                #region Validações do Nome de Usuário do E-mail

                DomainExceptionValidation.When(string.IsNullOrEmpty(nomeUsuario),
                "O nome de usuário do e-mail é obrigatório.");

                DomainExceptionValidation.When(nomeUsuario.Length > 64,
                "O nome de usuário do e-mail pode ter no máximo 64 caracteres.");

                DomainExceptionValidation.When(nomeUsuario.StartsWith('.'),
                "O e-mail não pode começar com ponto (.).");

                DomainExceptionValidation.When(nomeUsuario.StartsWith('-'),
                "O e-mail não pode começar com hífen (-).");

                DomainExceptionValidation.When(nomeUsuario.StartsWith('_'),
                "O e-mail não pode começar com underscore (_).");

                DomainExceptionValidation.When(!string.IsNullOrEmpty(nomeUsuario) &&
                ConstantesValidacao.CaracteresInvalidosInicioFimEmailUsuario.Contains(nomeUsuario[0]),
                "O e-mail não pode começar com caractere especial.");

                DomainExceptionValidation.When(ConstantesValidacao.PontosConsecutivos.IsMatch(nomeUsuario),
                "O nome de usuário do e-mail não pode conter pontos consecutivos (.., ..., .... e etc).");

                DomainExceptionValidation.When(ConstantesValidacao.HifensConsecutivos.IsMatch(nomeUsuario),
                "O nome de usuário do e-mail não pode conter hífens consecutivos (--, ---, ---- e etc).");

                DomainExceptionValidation.When(ConstantesValidacao.UnderscoresConsecutivos.IsMatch(nomeUsuario),
                "O nome de usuário do e-mail não pode conter underscores consecutivos (__, ___, ____ e etc).");

                DomainExceptionValidation.When(nomeUsuario.EndsWith('.'),
                "O nome de usuário do e-mail não pode terminar com ponto (.).");

                DomainExceptionValidation.When(nomeUsuario.EndsWith('-'),
                "O nome de usuário do e-mail não pode terminar com hífen (-).");

                DomainExceptionValidation.When(nomeUsuario.EndsWith('_'),
                "O nome de usuário do e-mail não pode terminar com underscore (_).");

                DomainExceptionValidation.When(!string.IsNullOrEmpty(nomeUsuario) &&
                ConstantesValidacao.CaracteresInvalidosInicioFimEmailUsuario.Contains(nomeUsuario[^1]),
                "O nome de usuário do e-mail não pode terminar com caractere especial.");

                DomainExceptionValidation.When(!string.IsNullOrEmpty(nomeUsuario) &&
                nomeUsuario.Intersect(ConstantesValidacao.CaracteresInvalidosEmailUsuario).Any(),
                $"O nome de usuário do e-mail não pode conter: {new string(ConstantesValidacao.CaracteresInvalidosEmailUsuario)}.");

                #endregion

                #region Validações de Domínio do E-mail

                DomainExceptionValidation.When(string.IsNullOrEmpty(dominio),
                "O domínio de e-mail é obrigatório.");

                DomainExceptionValidation.When(dominio.Length < 4,
                "O domínio de e-mail deve ter no mínimo 4 caracteres.");

                DomainExceptionValidation.When(dominio.Length > 251,
                "O domínio de e-mail pode ter no máximo 251 caracteres.");

                DomainExceptionValidation.When(!dominio.Contains('.'),
                "O domínio de e-mail deve conter pelo menos um ponto (.), exemplo: \"dominio.com\".");

                DomainExceptionValidation.When(dominio.StartsWith('.'),
                "O domínio de e-mail não pode começar com ponto (.).");

                DomainExceptionValidation.When(dominio.StartsWith('-'),
                "O domínio de e-mail não pode começar com hífen (-).");

                DomainExceptionValidation.When(ConstantesValidacao.PontosConsecutivos.IsMatch(dominio),
                "O domínio de e-mail não pode conter pontos consecutivos (.., ..., .... e etc).");

                DomainExceptionValidation.When(ConstantesValidacao.HifensConsecutivos.IsMatch(dominio),
                "O domínio de e-mail não pode conter hífens consecutivos (--, ---, ---- e etc).");

                DomainExceptionValidation.When(dominio.EndsWith('.'),
                "O e-mail não pode terminar com ponto (.).");

                DomainExceptionValidation.When(dominio.EndsWith('-'),
                "O e-mail não pode terminar com hífen (-).");

                DomainExceptionValidation.When(!string.IsNullOrEmpty(dominio) &&
                dominio.Intersect(ConstantesValidacao.CaracteresInvalidosEmailDominio).Any(),
                $"O domínio de e-mail não pode conter: {new string(ConstantesValidacao.CaracteresInvalidosEmailDominio)}.");

                if (!string.IsNullOrEmpty(dominio) && !dominio.StartsWith('.') && !dominio.EndsWith('.') && dominio.Contains('.'))
                {
                    var rotulos = dominio.Split('.');

                    DomainExceptionValidation.When(rotulos.Any(r => r.Length > 63),
                    "Os rótulos do domínio de e-mail podem ter no máximo 63 caracteres.");

                    DomainExceptionValidation.When(rotulos[^1].Length < 2,
                    "As extensões de domínio (TLDs) devem ter no mínimo 2 caracteres.");

                    DomainExceptionValidation.When(!Regex.IsMatch(rotulos[^1], @"^[a-zA-Z]+$"),
                    "As extensões de domínio (TLDs) não podem conter números.");
                }
            }

            #endregion

            #endregion

            #region Validações de Texto

            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(texto),
            "A mensagem é obrigatória.");

            DomainExceptionValidation.When(texto.Length < 5,
            "A mensagem deve ter no mínimo 5 caracteres.");

            DomainExceptionValidation.When(texto.Length > 700,
            "A mensagem pode ter no máximo 700 caracteres.");

            #endregion

            #region Inicialização das Propriedades

            Nome = nome;
            Email = email;
            Texto = texto;

            #endregion
        }

        #endregion
    }
}