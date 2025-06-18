using Xunit;
using FluentAssertions;
using InnatAPP.Domain.Entities;

namespace InnatAPP.Domain.Tests
{
    public class TelefoneUnitTest
    {
        #region Testes de Parâmetros Válidos

        [Fact(DisplayName = "Criar telefone com estado válido")]
        public void CriarTelefone_ComParametrosValidos_ResultandoEmObjetoComEstadoValido()
        {
            Action action = () =>
            {
                var telefone = new Telefone(
                    Guid.NewGuid(),
                    "16",
                    "987654321",
                    Guid.NewGuid()
                );
            };

            action.Should()
                .NotThrow<InnatAPP.Domain.Validation.DomainExceptionValidation>();
        }

        #endregion

        #region Testes de Parâmetros Inválidos

        #region Testes de Id

        [Fact(DisplayName = "Criar telefone com id vazio")]
        public void CriarTelefone_ComIdVazio_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var telefone = new Telefone(
                    Guid.Empty,
                    "16",
                    "987654321",
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O id é obrigatório.");
        }

        #endregion

        #region Testes de Id de Usuario

        [Fact(DisplayName = "Criar telefone com id de usuário vazio")]
        public void CriarTelefone_ComIdDeUsuarioVazio_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var telefone = new Telefone(
                    Guid.NewGuid(),
                    "16",
                    "987654321",
                    Guid.Empty
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O id de usuário é obrigatório.");
        }

        #endregion

        #region Testes de DDD

        [Fact(DisplayName = "Criar telefone com DDD nulo")]
        public void CriarTelefone_ComDddNulo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var telefone = new Telefone(
                    Guid.NewGuid(),
                    null,
                    "987654321",
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O DDD é obrigatório.");
        }

        [Fact(DisplayName = "Criar telefone com DDD vazio")]
        public void CriarTelefone_ComDddVazio_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var telefone = new Telefone(
                    Guid.NewGuid(),
                    "",
                    "987654321",
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O DDD é obrigatório.");
        }

        [Fact(DisplayName = "Criar telefone com caracteres que não são dígitos no DDD")]
        public void CriarTelefone_ComCaracteresQueNaoSaoDigitosNoDdd_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var telefone = new Telefone(
                    Guid.NewGuid(),
                    "i6",
                    "987654321",
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O DDD deve conter apenas dígitos.");
        }

        [Fact(DisplayName = "Criar telefone com menos de dois dígitos no DDD")]
        public void CriarTelefone_ComMenosDeDoisDigitosNoDDD_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var telefone = new Telefone(
                    Guid.NewGuid(),
                    "1",
                    "987654321",
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O DDD deve ter 2 dígitos.");
        }

        [Fact(DisplayName = "Criar telefone com mais de dois dígitos no DDD")]
        public void CriarTelefone_ComMaisDeDoisDigitosNoDDD_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var telefone = new Telefone(
                    Guid.NewGuid(),
                    "167",
                    "987654321",
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O DDD deve ter 2 dígitos.");
        }

        [Fact(DisplayName = "Criar telefone com valor de DDD menor que 11")]
        public void CriarTelefone_ComValorDeDddMenorQueOnze_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var telefone = new Telefone(
                    Guid.NewGuid(),
                    "09",
                    "987654321",
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O DDD deve estar entre 11 e 99.");
        }

        #endregion

        #region Testes de Número

        [Fact(DisplayName = "Criar telefone com número nulo")]
        public void CriarTelefone_ComNumeroNulo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var telefone = new Telefone(
                    Guid.NewGuid(),
                    "16",
                    null,
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O número é obrigatório.");
        }

        [Fact(DisplayName = "Criar telefone com número vazio")]
        public void CriarTelefone_ComNumeroVazio_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var telefone = new Telefone(
                    Guid.NewGuid(),
                    "16",
                    "",
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O número é obrigatório.");
        }

        [Fact(DisplayName = "Criar telefone com caracteres que não são dígitos no número")]
        public void CriarTelefone_ComCaracteresQueNaoSaoDigitosNoNumero_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var telefone = new Telefone(
                    Guid.NewGuid(),
                    "16",
                    "Nove87643",
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O número deve conter apenas dígitos.");
        }

        [Fact(DisplayName = "Criar telefone com número muito curto")]
        public void CriarTelefone_ComNumeroMuitoCurto_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var telefone = new Telefone(
                    Guid.NewGuid(),
                    "16",
                    "9876543",
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O número deve ter no mínimo 8 dígitos.");
        }

        [Fact(DisplayName = "Criar telefone com número muito longo")]
        public void CriarTelefone_ComNumeroMuitoLongo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var telefone = new Telefone(
                    Guid.NewGuid(),
                    "16",
                    "9876543210",
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O número pode ter no máximo 9 dígitos.");
        }

        #endregion

        #endregion
    }
}