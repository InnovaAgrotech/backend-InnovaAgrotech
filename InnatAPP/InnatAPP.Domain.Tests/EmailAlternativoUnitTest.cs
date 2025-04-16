#region Importações

using Xunit;
using FluentAssertions;
using InnatAPP.Domain.Shared;
using InnatAPP.Domain.Entities;

#endregion

namespace InnatAPP.Domain.Tests
{
    public class EmailAlternativoUnitTest
    {
        #region Testes de parâmetros válidos

        [Fact(DisplayName = "Criar email alternativo com estado válido")]
        public void CriarEmailAlternativo_ComParametrosValidos_ResultandoEmObjetoComEstadoValido()
        {
            Action action = () => new EmailAlternativo(1, "EduardaRb@outlook.com");
            action.Should()
                .NotThrow<InnatAPP.Domain.Validation.DomainExceptionValidation>();
        }

        #endregion

        #region Testes de Id

        [Fact(DisplayName = "Criar email alternativo com id negativo")]
        public void CriarEmailAlternativo_ComIdNegativo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new EmailAlternativo(-1, "EduardaRb@outlook.com");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Valor de id inválido.");
        }

        #endregion

        #region Testes de e-mail

        [Fact(DisplayName = "Criar email alternativo com email nulo")]
        public void CriarEmailAlternativo_ComEmailNulo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new EmailAlternativo(1, null);
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o e-mail é obrigatório.");
        }

        [Fact(DisplayName = "Criar email alternativo com email vazio")]
        public void CriarEmailAlternativo_ComEmailVazio_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new EmailAlternativo(1, "");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o e-mail é obrigatório.");
        }

        [Fact(DisplayName = "Criar email alternativo com email muito curto")]
        public void CriarEmailAlternativo_ComEmailMuitoCurto_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new EmailAlternativo(1, "E@o");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o e-mail deve ter no mínimo 5 caracteres.");
        }

        [Fact(DisplayName = "Criar email alternativo com email muito longo")]
        public void CriarEmailAlternativo_ComEmailMuitoLongo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new EmailAlternativo(1, "MariaEduardaDominiquePereiraDosSantosOliveiraDeCastroRibeiroFernandesLimaCostaMartinsDuarte-03-05-1980-Agrônoma_Plantio15_03Colheita30_65scHaMilho120scHaIrrigacao10mmDiaFertNPK5_20_20Armazem5000scFazendaBelaVistaBR163Km78ZonaRuralSinopMT2025@agricultura.gov.br");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o e-mail pode ter no máximo 255 caracteres.");
        }

        [Fact(DisplayName = "Criar email alternativo sem @ no email")]
        public void CriarEmailAlternativo_SemArrobaNoEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new EmailAlternativo(1, "EduardaRboutlook.com");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o e-mail deve conter um '@'.");
        }

        [Fact(DisplayName = "Criar email alternativo com espaço no email")]
        public void CriarEmailAlternativo_ComEspacoNoEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new EmailAlternativo(1, "Eduarda Rb@outlook.com");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o e-mail não pode conter espaços.");
        }

        [Fact(DisplayName = "Criar email alternativo com mais de um arroba no email")]
        public void CriarEmailAlternativo_ComMaisDeUmArrobaNoEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new EmailAlternativo(1, "Eduarda@Rb@outlook.com");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o e-mail pode ter apenas um '@'.");
        }

        [Fact(DisplayName = "Criar email alternativo com usuário de email vazio")]
        public void CriarEmailAlternativo_ComUsuarioDeEmailVazio_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new EmailAlternativo(1, "@outlook.com");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o nome de usuário é obrigatório.");
        }

        [Fact(DisplayName = "Criar email alternativo com ponto no início do email")]
        public void CriarEmailAlternativo_ComPontoNoInicioDoEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new EmailAlternativo(1, ".EduardaRb@outlook.com");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o email não pode começar com ponto (.).");
        }

        [Fact(DisplayName = "Criar email alternativo com ponto no final do usuário de email")]
        public void CriarEmailAlternativo_ComPontoNoFinalDoUsuarioDeEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new EmailAlternativo(1, "EduardaRb.@outlook.com");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o nome de usuário não pode terminar com ponto (.).");
        }

        [Fact(DisplayName = "Criar email alternativo com caracteres inválidos no usuario de email")]
        public void CriarEmailAlternativo_ComCaracteresInvalidosNoUsuarioDeEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new EmailAlternativo(1, "<EduardaRb>@outlook.com");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage($"E-mail inválido, o nome de usuário não pode conter: {ConstantesValidacao.caracteresInvalidosEmailUsuario}.");
        }

        [Fact(DisplayName = "Criar email alternativo com domínio de email vazio")]
        public void CriarEmailAlternativo_ComDominioDeEmailVazio_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new EmailAlternativo(1, "EduardaRb@");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o domínio é obrigatório.");
        }

        [Fact(DisplayName = "Criar email alternativo sem ponto no domínio de email")]
        public void CriarEmailAlternativo_SemPontoNoDominioDeEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new EmailAlternativo(1, "EduardaRb@outlook");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o domínio deve conter pelo menos um '.' (Exemplo: gmail.com).");
        }

        [Fact(DisplayName = "Criar email alternativo com hifén no início do domínio de email")]
        public void CriarEmailAlternativo_ComHifenNoInicoDoDominioDeEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new EmailAlternativo(1, "EduardaRb@-outlook.com");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o domínio não pode começar com hífen (-).");
        }

        [Fact(DisplayName = "Criar email alternativo com hífen no final do email")]
        public void CriarEmailAlternativo_ComHifenNoFinalDoEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new EmailAlternativo(1, "EduardaRb@outlook.com-");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o e-mail não pode terminar com hífen (-).");
        }

        [Fact(DisplayName = "Criar email alternativo com caracteres inválidos no domínio de email")]
        public void CriarEmailAlternativo_ComCaracteresInvalidosNoDominioDeEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new EmailAlternativo(1, "EduardaRb@outlook#.com");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage($"E-mail inválido, o domínio não pode conter: {ConstantesValidacao.caracteresInvalidosEmailDominio}.");
        }

        #endregion
    }
}
