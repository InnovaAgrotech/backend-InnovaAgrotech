#region Importações

using Xunit;
using FluentAssertions;
using InnatAPP.Domain.Entities;

#endregion

namespace InnatAPP.Domain.Tests
{
    public class TelefoneUnitTest
    {
        #region Testes de parâmetros válidos

        [Fact(DisplayName = "Criar telefone com estado válido")]
        public void CriarTelefone_ComParametrosValidos_ResultandoEmObjetoComEstadoValido()
        {
            Action action = () => new Telefone(1, "16", "987654321");
            action.Should()
                .NotThrow<InnatAPP.Domain.Validation.DomainExceptionValidation>();
        }

        #endregion

        #region Testes de Id

        [Fact(DisplayName = "Criar telefone com id negativo")]
        public void CriarTelefone_ComIdNegativo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Telefone(-1, "16", "987654321");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Valor de id inválido.");
        }

        #endregion

        #region Testes de DDD

        [Fact(DisplayName = "Criar telefone com DDD nulo")]
        public void CriarTelefone_ComDDDNulo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Telefone(1, null, "987654321");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Número inválido, o DDD é obrigatório.");
        }

        [Fact(DisplayName = "Criar telefone com DDD vazio")]
        public void CriarTelefone_ComDDDVazio_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Telefone(1, "", "987654321");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Número inválido, o DDD é obrigatório.");
        }

        [Fact(DisplayName = "Criar telefone com caracteres que não são dígitos no DDD")]
        public void CriarTelefone_ComCaracteresQueNaoSaoDigitosNoDDD_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Telefone(1, "IG", "987654321");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Número inválido, o DDD deve conter apenas dígitos.");
        }

        [Fact(DisplayName = "Criar telefone com menos de dois dígitos no DDD")]
        public void CriarTelefone_ComMenosDeDoisDigitosNoDDD_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Telefone(1, "1", "987654321");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Número inválido, o DDD deve ter 2 dígitos.");
        }

        [Fact(DisplayName = "Criar telefone com mais de dois dígitos no DDD")]
        public void CriarTelefone_ComMaisDeDoisDigitosNoDDD_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Telefone(1, "165", "987654321");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Número inválido, o DDD deve ter 2 dígitos.");
        }

        [Fact(DisplayName = "Criar telefone com DDD menor que onze")]
        public void CriarTelefone_ComDDDMenorQueOnze_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Telefone(1, "10", "987654321");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Número inválido, o DDD deve estar entre 11 e 99.");
        }

        #endregion

        #region Testes de numero

        [Fact(DisplayName = "Criar telefone com número nulo")]
        public void CriarTelefone_ComNumeroNulo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Telefone(1, "16", null);
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Número inválido, o número é obrigatório.");
        }

        [Fact(DisplayName = "Criar telefone com número vazio")]
        public void CriarTelefone_ComNumeroVazio_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Telefone(1, "16", "");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Número inválido, o número é obrigatório.");
        }

        [Fact(DisplayName = "Criar telefone com caracteres que não são dígitos no número")]
        public void CriarTelefone_ComCaracteresQueNaoSaoDigitosNoNumero_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Telefone(1, "16", "Nove876Cinco432Um");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Número inválido, o número deve conter apenas dígitos.");
        }

        [Fact(DisplayName = "Criar telefone com número muito curto")]
        public void CriarTelefone_ComNumeroMuitoCurto_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Telefone(1, "16", "9876543");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Número inválido, o número deve ter no mínimo 8 dígitos.");
        }

        [Fact(DisplayName = "Criar telefone com número muito longo")]
        public void CriarTelefone_ComNumeroMuitoLongo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Telefone(1, "16", "9876543210");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Número inválido, o número deve ter no máximo 9 dígitos.");
        }

        #endregion
    }
}
