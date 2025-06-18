using InnatAPP.Domain.Shared;
using InnatAPP.Domain.Validation;
using InnatAPP.Domain.ValueObjects;
using System.Text.RegularExpressions;

namespace InnatAPP.Domain.Entities
{
    public class Usuario
    {
        #region Propriedades

        public Guid Id { get; private set; }
        public string Nome { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string SenhaHash { get; private set; } = string.Empty;
        public string Foto { get; private set; } = string.Empty;
        public string Biografia { get; private set; } = string.Empty;

        #endregion

        #region Propriedades de Navegação

        public TipoUsuario TipoUsuario { get; private set; } = default!;

        #endregion

        #region Coleções

        public ICollection<EmailAlternativo> EmailsAlternativos { get; private set; } = new List<EmailAlternativo>();
        public ICollection<Telefone> Telefones { get; private set; } = new List<Telefone>();
        public ICollection<Endereco> Enderecos { get; private set; } = new List<Endereco>();

        #endregion

        #region Construtores

        public Usuario() { }

        public Usuario(string nome, string email, string senhaHash, string foto, string biografia, TipoUsuario tipoUsuario)
        {
            #region Validações de Entrada

            ValidateDomain(nome, email, senhaHash, foto, biografia);

            if (tipoUsuario is null)
                throw new DomainExceptionValidation("O tipo de usuário é obrigatório.");

            #endregion

            #region Inicialização das Propriedades

            Id = Guid.NewGuid();

            try
            {
                TipoUsuario = tipoUsuario;
            }
            catch (ArgumentException ex)
            {
                throw new DomainExceptionValidation($"Erro ao criar usuário: {ex.Message}.");
            }

            #endregion
        }

        public Usuario(Guid id, string nome, string email, string senhaHash, string foto, string biografia, TipoUsuario tipoUsuario)
        {
            #region Validações de Entrada

            DomainExceptionValidation.When(id == Guid.Empty, "O id é obrigatório.");

            ValidateDomain(nome, email, senhaHash, foto, biografia);

            if (tipoUsuario is null)
                throw new DomainExceptionValidation("O tipo de usuário é obrigatório.");

            #endregion

            #region Inicialização das Propriedades

            Id = id;

            try
            {
                TipoUsuario = tipoUsuario;
            }
            catch (ArgumentException ex)
            {
                throw new DomainExceptionValidation($"Erro ao criar usuário: {ex.Message}.");
            }

            #endregion
        }

        #endregion

        #region Métodos Públicos

        public void Alterar(string nome, string email, string senhaHash, string foto, string biografia)
        {
            ValidateDomain(nome, email, senhaHash, foto, biografia);
        }

        #endregion

        #region Validações de Domínio

        private void ValidateDomain(string nome, string email, string senhaHash, string? foto, string? biografia)
        {
            #region Validações de Nome

            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(nome),
            "O nome de usuário é obrigatório.");

            DomainExceptionValidation.When(nome.StartsWith(' '),
            "O nome de usuário não pode começar com espaço (\" \").");

            DomainExceptionValidation.When(nome.EndsWith(' '),
            "O nome de usuário não pode terminar com espaço (\" \").");

            DomainExceptionValidation.When(ConstantesValidacao.EspacosConsecutivos.IsMatch(nome),
            "O nome de usuário não pode ter espaços consecutivos (\"  \", \"   \", \"    \" e etc).");

            DomainExceptionValidation.When(nome.Length < 3,
            "O nome de usuário deve ter no mínimo 3 caracteres.");

            DomainExceptionValidation.When(nome.Length > 100,
            "O nome de usuário pode ter no máximo 100 caracteres.");

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

            #region Validações de Senha 

            DomainExceptionValidation.When(string.IsNullOrEmpty(senhaHash),
            "A senha é obrigatória.");

            DomainExceptionValidation.When(senhaHash.Length < 8,
            "A senha deve ter no mínimo 8 caracteres.");

            DomainExceptionValidation.When(senhaHash.Length > 64,
            "A senha pode ter no máximo 64 caracteres.");

            DomainExceptionValidation.When(senhaHash.Contains(' '),
            "A senha não pode conter espaços.");

            DomainExceptionValidation.When(!senhaHash.Any(char.IsUpper),
            "A senha deve conter pelo menos uma letra maiúscula.");

            DomainExceptionValidation.When(!senhaHash.Any(char.IsLower),
            "A senha deve conter pelo menos uma letra minúscula.");

            DomainExceptionValidation.When(!senhaHash.Any(char.IsDigit),
            "A senha deve conter pelo menos um número.");

            DomainExceptionValidation.When(!senhaHash.Intersect(ConstantesValidacao.CaracteresEspeciaisPermitidosSenha).Any(),
            $"A senha deve conter pelo menos um caractere especial. Exemplo: {new string(ConstantesValidacao.CaracteresEspeciaisPermitidosSenha)}.");

            #endregion

            #region Validações de Foto

            DomainExceptionValidation.When(foto?.Length > 250,
            "A URL da foto pode ter no máximo 250 caracteres.");

            #endregion

            #region Validações de Biografia

            DomainExceptionValidation.When(biografia?.Length > 500,
            "A biografia pode ter no máximo 500 caracteres.");

            #endregion

            #region Inicialização das Propriedades

            Nome = nome;
            Email = email;
            SenhaHash = senhaHash;
            Foto = foto ?? string.Empty;
            Biografia = biografia ?? string.Empty;

            #endregion
        }

        #endregion
    }
}