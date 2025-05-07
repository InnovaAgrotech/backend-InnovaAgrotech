#region Importações

using Xunit;
using FluentAssertions;
using InnatAPP.Domain.Shared;
using InnatAPP.Domain.Entities;

#endregion

namespace InnatAPP.Domain.Tests
{
    public class EmailAlternativoAvaliadorUnitTest
    {
        #region Testes de parâmetros válidos

        [Fact(DisplayName = "Criar email alternativo de avaliador com estado válido")]
        public void CriarEmailAlternativoDeAvaliador_ComParametrosValidos_ResultandoEmObjetoComEstadoValido()
        {
            Action action = () => new EmailAlternativoAvaliador(1, "EduardaRb@outlook.com", 1);
            action.Should()
                .NotThrow<InnatAPP.Domain.Validation.DomainExceptionValidation>();
        }

        #endregion

        #region Testes de Id

        [Fact(DisplayName = "Criar email alternativo de avaliador com id negativo")]
        public void CriarEmailAlternativoDeAvaliador_ComIdNegativo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new EmailAlternativoAvaliador(-1, "EduardaRb@outlook.com", 1);
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Valor de id inválido.");
        }

        #endregion

        #region Testes de e-mail

        [Fact(DisplayName = "Criar email alternativo de avaliador com email nulo")]
        public void CriarEmailAlternativoDeAvaliador_ComEmailNulo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new EmailAlternativoAvaliador(1, null, 1);
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o e-mail é obrigatório.");
        }

        [Fact(DisplayName = "Criar email alternativo de avaliador com email vazio")]
        public void CriarEmailAlternativoDeAvaliador_ComEmailVazio_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new EmailAlternativoAvaliador(1, "", 1);
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o e-mail é obrigatório.");
        }

        [Fact(DisplayName = "Criar email alternativo de avaliador com email muito curto")]
        public void CriarEmailAlternativoDeAvaliador_ComEmailMuitoCurto_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new EmailAlternativoAvaliador(1, "E@o", 1);
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o e-mail deve ter no mínimo 5 caracteres.");
        }

        [Fact(DisplayName = "Criar email alternativo de avaliador com email muito longo")]
        public void CriarEmailAlternativoDeAvaliador_ComEmailMuitoLongo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new EmailAlternativoAvaliador(1, "MariaEduardaDominiquePereiraDosSantosOliveiraDeCastroRibeiroFernandesLimaCostaMartinsDuarte-03-05-1980-Agrônoma_Plantio15_03Colheita30_65scHaMilho120scHaIrrigacao10mmDiaFertNPK5_20_20Armazem5000scFazendaBelaVistaBR163Km78ZonaRuralSinopMT2025@agricultura.gov.br", 1);
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o e-mail pode ter no máximo 255 caracteres.");
        }

        [Fact(DisplayName = "Criar email alternativo de avaliador sem @ no email")]
        public void CriarEmailAlternativoDeAvaliador_SemArrobaNoEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new EmailAlternativoAvaliador(1, "EduardaRboutlook.com", 1);
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o e-mail deve conter um '@'.");
        }

        [Fact(DisplayName = "Criar email alternativo de avaliador com espaço no email")]
        public void CriarEmailAlternativoDeAvaliador_ComEspacoNoEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new EmailAlternativoAvaliador(1, "Eduarda Rb@outlook.com", 1);
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o e-mail não pode conter espaços.");
        }

        [Fact(DisplayName = "Criar email alternativo de avaliador com mais de um arroba no email")]
        public void CriarEmailAlternativoDeAvaliador_ComMaisDeUmArrobaNoEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new EmailAlternativoAvaliador(1, "Eduarda@Rb@outlook.com", 1);
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o e-mail pode ter apenas um '@'.");
        }

        [Fact(DisplayName = "Criar email alternativo de avaliador com usuário de email vazio")]
        public void CriarEmailAlternativoDeAvaliador_ComUsuarioDeEmailVazio_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new EmailAlternativoAvaliador(1, "@outlook.com", 1);
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o nome de usuário é obrigatório.");
        }

        [Fact(DisplayName = "Criar email alternativo de avaliador com ponto no início do email")]
        public void CriarEmailAlternativoDeAvaliador_ComPontoNoInicioDoEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new EmailAlternativoAvaliador(1, ".EduardaRb@outlook.com", 1);
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o email não pode começar com ponto (.).");
        }

        [Fact(DisplayName = "Criar email alternativo de avaliador com ponto no final do usuário de email")]
        public void CriarEmailAlternativoDeAvaliador_ComPontoNoFinalDoUsuarioDeEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new EmailAlternativoAvaliador(1, "EduardaRb.@outlook.com", 1);
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o nome de usuário não pode terminar com ponto (.).");
        }

        [Fact(DisplayName = "Criar email alternativo de avaliador com caracteres inválidos no usuario de email")]
        public void CriarEmailAlternativoDeAvaliador_ComCaracteresInvalidosNoUsuarioDeEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new EmailAlternativoAvaliador(1, "<EduardaRb>@outlook.com", 1);
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage($"E-mail inválido, o nome de usuário não pode conter: {new string(ConstantesValidacao.caracteresInvalidosEmailUsuario)}.");
        }

        [Fact(DisplayName = "Criar email alternativo de avaliador com domínio de email vazio")]
        public void CriarEmailAlternativoDeAvaliador_ComDominioDeEmailVazio_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new EmailAlternativoAvaliador(1, "EduardaRb@", 1);
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o domínio é obrigatório.");
        }

        [Fact(DisplayName = "Criar email alternativo de avaliador sem ponto no domínio de email")]
        public void CriarEmailAlternativoDeAvaliador_SemPontoNoDominioDeEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new EmailAlternativoAvaliador(1, "EduardaRb@outlook", 1);
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o domínio deve conter pelo menos um '.' (Exemplo: gmail.com).");
        }

        [Fact(DisplayName = "Criar email alternativo de avaliador com hifén no início do domínio de email")]
        public void CriarEmailAlternativoDeAvaliador_ComHifenNoInicoDoDominioDeEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new EmailAlternativoAvaliador(1, "EduardaRb@-outlook.com", 1);
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o domínio não pode começar com hífen (-).");
        }

        [Fact(DisplayName = "Criar email alternativo de avaliador com hífen no final do email")]
        public void CriarEmailAlternativoDeAvaliador_ComHifenNoFinalDoEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new EmailAlternativoAvaliador(1, "EduardaRb@outlook.com-", 1);
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o e-mail não pode terminar com hífen (-).");
        }

        [Fact(DisplayName = "Criar email alternativo de avaliador com caracteres inválidos no domínio de email")]
        public void CriarEmailAlternativoDeAvaliador_ComCaracteresInvalidosNoDominioDeEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new EmailAlternativoAvaliador(1, "EduardaRb@outlook#.com", 1);
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage($"E-mail inválido, o domínio não pode conter: {new string(ConstantesValidacao.caracteresInvalidosEmailDominio)}.");
        }

        #endregion
    }
}
