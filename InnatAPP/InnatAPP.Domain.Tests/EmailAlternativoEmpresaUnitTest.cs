#region Importações

using Xunit;
using FluentAssertions;
using InnatAPP.Domain.Shared;
using InnatAPP.Domain.Entities;

#endregion

namespace InnatAPP.Domain.Tests
{
    public class EmailAlternativoEmpresaUnitTest
    {
        #region Testes de parâmetros válidos

        [Fact(DisplayName = "Criar email alternativo de empresa com estado válido")]
        public void CriarEmailAlternativoDeEmpresa_ComParametrosValidos_ResultandoEmObjetoComEstadoValido()
        {
            Action action = () => new EmailAlternativoEmpresa(1, "EduardaRb@outlook.com");
            action.Should()
                .NotThrow<InnatAPP.Domain.Validation.DomainExceptionValidation>();
        }

        #endregion

        #region Testes de Id

        [Fact(DisplayName = "Criar email alternativo de empresa com id negativo")]
        public void CriarEmailAlternativoDeEmpresa_ComIdNegativo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new EmailAlternativoEmpresa(-1, "EduardaRb@outlook.com");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Valor de id inválido.");
        }

        #endregion

        #region Testes de e-mail

        [Fact(DisplayName = "Criar email alternativo de empresa com email nulo")]
        public void CriarEmailAlternativoDeEmpresa_ComEmailNulo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new EmailAlternativoEmpresa(1, null);
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o e-mail é obrigatório.");
        }

        [Fact(DisplayName = "Criar email alternativo de empresa com email vazio")]
        public void CriarEmailAlternativoDeEmpresa_ComEmailVazio_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new EmailAlternativoEmpresa(1, "");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o e-mail é obrigatório.");
        }

        [Fact(DisplayName = "Criar email alternativo de empresa com email muito curto")]
        public void CriarEmailAlternativoDeEmpresa_ComEmailMuitoCurto_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new EmailAlternativoEmpresa(1, "E@o");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o e-mail deve ter no mínimo 5 caracteres.");
        }

        [Fact(DisplayName = "Criar email alternativo de empresa com email muito longo")]
        public void CriarEmailAlternativoDeEmpresa_ComEmailMuitoLongo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new EmailAlternativoEmpresa(1, "MariaEduardaDominiquePereiraDosSantosOliveiraDeCastroRibeiroFernandesLimaCostaMartinsDuarte-03-05-1980-Agrônoma_Plantio15_03Colheita30_65scHaMilho120scHaIrrigacao10mmDiaFertNPK5_20_20Armazem5000scFazendaBelaVistaBR163Km78ZonaRuralSinopMT2025@agricultura.gov.br");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o e-mail pode ter no máximo 255 caracteres.");
        }

        [Fact(DisplayName = "Criar email alternativo de empresa sem @ no email")]
        public void CriarEmailAlternativoDeEmpresa_SemArrobaNoEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new EmailAlternativoEmpresa(1, "EduardaRboutlook.com");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o e-mail deve conter um '@'.");
        }

        [Fact(DisplayName = "Criar email alternativo de empresa com espaço no email")]
        public void CriarEmailAlternativoDeEmpresa_ComEspacoNoEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new EmailAlternativoEmpresa(1, "Eduarda Rb@outlook.com");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o e-mail não pode conter espaços.");
        }

        [Fact(DisplayName = "Criar email alternativo de empresa com mais de um arroba no email")]
        public void CriarEmailAlternativoDeEmpresa_ComMaisDeUmArrobaNoEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new EmailAlternativoEmpresa(1, "Eduarda@Rb@outlook.com");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o e-mail pode ter apenas um '@'.");
        }

        [Fact(DisplayName = "Criar email alternativo de empresa com usuário de email vazio")]
        public void CriarEmailAlternativoDeEmpresa_ComUsuarioDeEmailVazio_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new EmailAlternativoEmpresa(1, "@outlook.com");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o nome de usuário é obrigatório.");
        }

        [Fact(DisplayName = "Criar email alternativo de empresa com ponto no início do email")]
        public void CriarEmailAlternativoDeEmpresa_ComPontoNoInicioDoEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new EmailAlternativoEmpresa(1, ".EduardaRb@outlook.com");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o email não pode começar com ponto (.).");
        }

        [Fact(DisplayName = "Criar email alternativo de empresa com ponto no final do usuário de email")]
        public void CriarEmailAlternativoDeEmpresa_ComPontoNoFinalDoUsuarioDeEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new EmailAlternativoEmpresa(1, "EduardaRb.@outlook.com");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o nome de usuário não pode terminar com ponto (.).");
        }

        [Fact(DisplayName = "Criar email alternativo de empresa com caracteres inválidos no usuario de email")]
        public void CriarEmailAlternativoDeEmpresa_ComCaracteresInvalidosNoUsuarioDeEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new EmailAlternativoEmpresa(1, "<EduardaRb>@outlook.com");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage($"E-mail inválido, o nome de usuário não pode conter: {new string(ConstantesValidacao.caracteresInvalidosEmailUsuario)}.");
        }

        [Fact(DisplayName = "Criar email alternativo de empresa com domínio de email vazio")]
        public void CriarEmailAlternativoDeEmpresa_ComDominioDeEmailVazio_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new EmailAlternativoEmpresa(1, "EduardaRb@");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o domínio é obrigatório.");
        }

        [Fact(DisplayName = "Criar email alternativo de empresa sem ponto no domínio de email")]
        public void CriarEmailAlternativoDeEmpresa_SemPontoNoDominioDeEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new EmailAlternativoEmpresa(1, "EduardaRb@outlook");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o domínio deve conter pelo menos um '.' (Exemplo: gmail.com).");
        }

        [Fact(DisplayName = "Criar email alternativo de empresa com hifén no início do domínio de email")]
        public void CriarEmailAlternativoDeEmpresa_ComHifenNoInicoDoDominioDeEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new EmailAlternativoEmpresa(1, "EduardaRb@-outlook.com");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o domínio não pode começar com hífen (-).");
        }

        [Fact(DisplayName = "Criar email alternativo de empresa com hífen no final do email")]
        public void CriarEmailAlternativoDeEmpresa_ComHifenNoFinalDoEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new EmailAlternativoEmpresa(1, "EduardaRb@outlook.com-");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o e-mail não pode terminar com hífen (-).");
        }

        [Fact(DisplayName = "Criar email alternativo de empresa com caracteres inválidos no domínio de email")]
        public void CriarEmailAlternativoDeEmpresa_ComCaracteresInvalidosNoDominioDeEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new EmailAlternativoEmpresa(1, "EduardaRb@outlook#.com");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage($"E-mail inválido, o domínio não pode conter: {new string(ConstantesValidacao.caracteresInvalidosEmailDominio)}.");
        }

        #endregion
    }
}
