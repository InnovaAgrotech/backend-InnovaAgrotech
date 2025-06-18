using InnatAPP.Domain.Shared;
using InnatAPP.Domain.Validation;
using System.Text.RegularExpressions;

namespace InnatAPP.Domain.Entities
{
    public class EmailAlternativo
    {
        #region Propriedades

        public Guid Id { get; private set; }
        public string EnderecoEmail { get; private set; } = string.Empty;

        #endregion

        #region Chaves Estrangeiras

        public Guid IdUsuario { get; private set; }

        #endregion

        #region Propriedades de Navegação

        public Usuario Usuario { get; private set; } = null!;

        #endregion

        #region Construtores

        public EmailAlternativo() { }

        public EmailAlternativo(string enderecoEmail, Guid idUsuario)
        {
            #region Validações de Entrada

            ValidateDomain(enderecoEmail);

            DomainExceptionValidation.When(idUsuario == Guid.Empty, "O id de usuário é obrigatório.");

            #endregion

            #region Inicialização das Propriedades

            Id = Guid.NewGuid();
            IdUsuario = idUsuario;

            #endregion
        }

        public EmailAlternativo(Guid id, string enderecoEmail, Guid idUsuario)
        {
            #region Validações de Entrada

            DomainExceptionValidation.When(id == Guid.Empty, "O id é obrigatório.");

            ValidateDomain(enderecoEmail);

            DomainExceptionValidation.When(idUsuario == Guid.Empty, "O id de usuário é obrigatório.");

            #endregion

            #region Inicialização das Propriedades

            Id = id;
            IdUsuario = idUsuario;

            #endregion
        }

        #endregion

        #region Métodos Públicos

        public void Alterar(string enderecoEmail)
        {
            ValidateDomain(enderecoEmail);
        }

        #endregion

        #region Validações de Domínio

        private void ValidateDomain(string enderecoEmail)
        {
            #region Validações de E-mail

            #region Validações Gerais de E-mail

            DomainExceptionValidation.When(string.IsNullOrEmpty(enderecoEmail),
            "O e-mail é obrigatório.");

            DomainExceptionValidation.When(enderecoEmail.Length < 6,
            "O e-mail deve ter no mínimo 6 caracteres.");

            DomainExceptionValidation.When(enderecoEmail.Length > 254,
            "O e-mail pode ter no máximo 254 caracteres.");

            DomainExceptionValidation.When(!enderecoEmail.Contains('@'),
            "O e-mail deve conter um arroba (@).");

            DomainExceptionValidation.When(enderecoEmail.Contains(' '),
            "O e-mail não pode conter espaços.");

            DomainExceptionValidation.When(enderecoEmail.Count(c => c == '@') > 1,
            "O e-mail pode ter apenas um arroba (@).");

            #endregion

            #region Separação das Partes de E-mail

            var partesEmail = enderecoEmail.Split('@', 2);
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

            #region Inicialização das Propriedades

            EnderecoEmail = enderecoEmail;

            #endregion
        }

        #endregion
    }
}