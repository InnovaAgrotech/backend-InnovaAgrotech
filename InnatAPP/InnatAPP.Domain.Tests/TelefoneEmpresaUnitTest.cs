#region Importações

using Xunit;
using FluentAssertions;
using InnatAPP.Domain.Entities;

#endregion

namespace InnatAPP.Domain.Tests
{
    public class TelefoneEmpresaUnitTest
    {
        #region Testes de parâmetros válidos

        [Fact(DisplayName = "Criar telefone de empresa com estado válido")]
        public void CriarTelefoneDeEmpresa_ComParametrosValidos_ResultandoEmObjetoComEstadoValido()
        {
            Action action = () => new TelefoneEmpresa(1, "16", "987654321");
            action.Should()
                .NotThrow<InnatAPP.Domain.Validation.DomainExceptionValidation>();
        }

        #endregion

        #region Testes de Id

        [Fact(DisplayName = "Criar telefone de empresa com id negativo")]
        public void CriarTelefoneDeEmpresa_ComIdNegativo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new TelefoneEmpresa(-1, "16", "987654321");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Valor de id inválido.");
        }

        #endregion

        #region Testes de DDD

        [Fact(DisplayName = "Criar telefone de empresa com DDD nulo")]
        public void CriarTelefoneDeEmpresa_ComDDDNulo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new TelefoneEmpresa(1, null, "987654321");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Número inválido, o DDD é obrigatório.");
        }

        [Fact(DisplayName = "Criar telefone de empresa com DDD vazio")]
        public void CriarTelefoneDeEmpresa_ComDDDVazio_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new TelefoneEmpresa(1, "", "987654321");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Número inválido, o DDD é obrigatório.");
        }

        [Fact(DisplayName = "Criar telefone de empresa com caracteres que não são dígitos no DDD")]
        public void CriarTelefoneDeEmpresa_ComCaracteresQueNaoSaoDigitosNoDDD_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new TelefoneEmpresa(1, "IG", "987654321");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Número inválido, o DDD deve conter apenas dígitos.");
        }

        [Fact(DisplayName = "Criar telefone de empresa com menos de dois dígitos no DDD")]
        public void CriarTelefoneDeEmpresa_ComMenosDeDoisDigitosNoDDD_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new TelefoneEmpresa(1, "1", "987654321");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Número inválido, o DDD deve ter 2 dígitos.");
        }

        [Fact(DisplayName = "Criar telefone de empresa com mais de dois dígitos no DDD")]
        public void CriarTelefoneDeEmpresa_ComMaisDeDoisDigitosNoDDD_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new TelefoneEmpresa(1, "165", "987654321");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Número inválido, o DDD deve ter 2 dígitos.");
        }

        [Fact(DisplayName = "Criar telefone de empresa com DDD menor que onze")]
        public void CriarTelefoneDeEmpresa_ComDDDMenorQueOnze_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new TelefoneEmpresa(1, "10", "987654321");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Número inválido, o DDD deve estar entre 11 e 99.");
        }

        #endregion

        #region Testes de numero

        [Fact(DisplayName = "Criar telefone de empresa com número nulo")]
        public void CriarTelefoneDeEmpresa_ComNumeroNulo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new TelefoneEmpresa(1, "16", null);
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Número inválido, o número é obrigatório.");
        }

        [Fact(DisplayName = "Criar telefone de empresa com número vazio")]
        public void CriarTelefoneDeEmpresa_ComNumeroVazio_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new TelefoneEmpresa(1, "16", "");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Número inválido, o número é obrigatório.");
        }

        [Fact(DisplayName = "Criar telefone de empresa com caracteres que não são dígitos no número")]
        public void CriarTelefoneDeEmpresa_ComCaracteresQueNaoSaoDigitosNoNumero_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new TelefoneEmpresa(1, "16", "Nove876Cinco432Um");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Número inválido, o número deve conter apenas dígitos.");
        }

        [Fact(DisplayName = "Criar telefone de empresa com número muito curto")]
        public void CriarTelefoneDeEmpresa_ComNumeroMuitoCurto_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new TelefoneEmpresa(1, "16", "9876543");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Número inválido, o número deve ter no mínimo 8 dígitos.");
        }

        [Fact(DisplayName = "Criar telefone de empresa com número muito longo")]
        public void CriarTelefoneDeEmpresa_ComNumeroMuitoLongo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new TelefoneEmpresa(1, "16", "9876543210");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Número inválido, o número deve ter no máximo 9 dígitos.");
        }

        #endregion
    }
}
