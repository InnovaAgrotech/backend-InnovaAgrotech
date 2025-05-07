#region Importações

using Xunit;
using FluentAssertions;
using InnatAPP.Domain.Entities;

#endregion

namespace InnatAPP.Domain.Tests
{
    public class TelefoneAvaliadorUnitTest
    {
        #region Testes de parâmetros válidos

        [Fact(DisplayName = "Criar telefone de avaliador com estado válido")]
        public void CriarTelefoneDeAvaliador_ComParametrosValidos_ResultandoEmObjetoComEstadoValido()
        {
            Action action = () => new TelefoneAvaliador(1, "16", "987654321", 1);
            action.Should()
                .NotThrow<InnatAPP.Domain.Validation.DomainExceptionValidation>();
        }

        #endregion

        #region Testes de Id

        [Fact(DisplayName = "Criar telefone de avaliador com id negativo")]
        public void CriarTelefoneDeAvaliador_ComIdNegativo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new TelefoneAvaliador(-1, "16", "987654321", 1);
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Valor de id inválido.");
        }

        #endregion

        #region Testes de DDD

        [Fact(DisplayName = "Criar telefone de avaliador com DDD nulo")]
        public void CriarTelefoneDeAvaliador_ComDDDNulo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new TelefoneAvaliador(1, null, "987654321", 1);
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Número inválido, o DDD é obrigatório.");
        }

        [Fact(DisplayName = "Criar telefone de avaliador com DDD vazio")]
        public void CriarTelefoneDeAvaliador_ComDDDVazio_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new TelefoneAvaliador(1, "", "987654321", 1);
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Número inválido, o DDD é obrigatório.");
        }

        [Fact(DisplayName = "Criar telefone de avaliador com caracteres que não são dígitos no DDD")]
        public void CriarTelefoneDeAvaliador_ComCaracteresQueNaoSaoDigitosNoDDD_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new TelefoneAvaliador(1, "IG", "987654321", 1);
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Número inválido, o DDD deve conter apenas dígitos.");
        }

        [Fact(DisplayName = "Criar telefone de avaliador com menos de dois dígitos no DDD")]
        public void CriarTelefoneDeAvaliador_ComMenosDeDoisDigitosNoDDD_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new TelefoneAvaliador(1, "1", "987654321", 1);
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Número inválido, o DDD deve ter 2 dígitos.");
        }

        [Fact(DisplayName = "Criar telefone de avaliador com mais de dois dígitos no DDD")]
        public void CriarTelefoneDeAvaliador_ComMaisDeDoisDigitosNoDDD_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new TelefoneAvaliador(1, "165", "987654321", 1);
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Número inválido, o DDD deve ter 2 dígitos.");
        }

        [Fact(DisplayName = "Criar telefone de avaliador com DDD menor que onze")]
        public void CriarTelefoneDeAvaliador_ComDDDMenorQueOnze_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new TelefoneAvaliador(1, "10", "987654321", 1);
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Número inválido, o DDD deve estar entre 11 e 99.");
        }

        #endregion

        #region Testes de numero

        [Fact(DisplayName = "Criar telefone de avaliador com número nulo")]
        public void CriarTelefoneDeAvaliador_ComNumeroNulo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new TelefoneAvaliador(1, "16", null, 1);
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Número inválido, o número é obrigatório.");
        }

        [Fact(DisplayName = "Criar telefone de avaliador com número vazio")]
        public void CriarTelefoneDeAvaliador_ComNumeroVazio_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new TelefoneAvaliador(1, "16", "", 1);
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Número inválido, o número é obrigatório.");
        }

        [Fact(DisplayName = "Criar telefone de avaliador com caracteres que não são dígitos no número")]
        public void CriarTelefoneDeAvaliador_ComCaracteresQueNaoSaoDigitosNoNumero_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new TelefoneAvaliador(1, "16", "Nove876Cinco432Um", 1);
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Número inválido, o número deve conter apenas dígitos.");
        }

        [Fact(DisplayName = "Criar telefone de avaliador com número muito curto")]
        public void CriarTelefoneDeAvaliador_ComNumeroMuitoCurto_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new TelefoneAvaliador(1, "16", "9876543", 1);
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Número inválido, o número deve ter no mínimo 8 dígitos.");
        }

        [Fact(DisplayName = "Criar telefone de avaliador com número muito longo")]
        public void CriarTelefoneDeAvaliador_ComNumeroMuitoLongo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new TelefoneAvaliador(1, "16", "9876543210", 1);
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Número inválido, o número deve ter no máximo 9 dígitos.");
        }

        #endregion
    }
}
