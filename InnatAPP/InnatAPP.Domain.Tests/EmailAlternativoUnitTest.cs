using Xunit;
using FluentAssertions;
using InnatAPP.Domain.Shared;
using InnatAPP.Domain.Entities;

namespace InnatAPP.Domain.Tests
{
    public class EmailAlternativoUnitTest
    {
        #region Testes de Parâmetros Válidos

        [Fact(DisplayName = "Criar e-mail alternativo com estado válido")]
        public void CriarEmailAlternativo_ComParametrosValidos_ResultandoEmObjetoComEstadoValido()
        {
            Action action = () =>
            {
                var emailAlternativo = new EmailAlternativo(
                    Guid.NewGuid(),
                    "EduardaRb@outlook.com",
                    Guid.NewGuid()
                );
            };

            action.Should()
                .NotThrow<InnatAPP.Domain.Validation.DomainExceptionValidation>();
        }

        #endregion

        #region Testes de Parâmetros Inválidos

        #region Testes de Id

        [Fact(DisplayName = "Criar e-mail alternativo com id vazio")]
        public void CriarEmailAlternativo_ComIdVazio_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var emailAlternativo = new EmailAlternativo(
                    Guid.Empty,
                    "EduardaRb@outlook.com",
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O id é obrigatório.");
        }

        #endregion

        #region Testes de Id de Usuario

        [Fact(DisplayName = "Criar e-mail alternativo com id de usuário vazio")]
        public void CriarEmailAlternativo_ComIdDeUsuarioVazio_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var emailAlternativo = new EmailAlternativo(
                    Guid.NewGuid(),
                    "EduardaRb@outlook.com",
                    Guid.Empty
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O id de usuário é obrigatório.");
        }

        #endregion

        #region Testes de E-mail

        #region Testes Gerais de E-mail

        [Fact(DisplayName = "Criar e-mail alternativo nulo")]
        public void CriarEmailAlternativo_Nulo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var emailAlternativo = new EmailAlternativo(
                    Guid.NewGuid(),
                    null,
                    Guid.NewGuid()

                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O e-mail é obrigatório.");
        }

        [Fact(DisplayName = "Criar e-mail alternativo vazio")]
        public void CriarEmailAlternativo_Vazio_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var emailAlternativo = new EmailAlternativo(
                    Guid.NewGuid(),
                    "",
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O e-mail é obrigatório.");
        }

        [Fact(DisplayName = "Criar e-mail alternativo muito curto")]
        public void CriarEmailAlternativo_MuitoCurto_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var emailAlternativo = new EmailAlternativo(
                    Guid.NewGuid(),
                    "E@O.C",
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O e-mail deve ter no mínimo 6 caracteres.");
        }

        [Fact(DisplayName = "Criar e-mail alternativo muito longo")]
        public void CriarEmailAlternativo_MuitoLongo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var emailAlternativo = new EmailAlternativo(
                    Guid.NewGuid(),
                    "MariaEduardaDominiquePereiraDosSantosOliveiraDeCastroRibeiroFernandesLimaCostaMartinsDuarte-03-05-1980-Agrônoma_Plantio15_03Colheita30_65scHaMilho120scHaIrrigacao10mmDiaFertNPK5_20_20Armazem5000scFazendaBelaVistaBR163Km78ZonaRuralSinopMT2025@agricultura.gov.br",
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O e-mail pode ter no máximo 254 caracteres.");
        }

        [Fact(DisplayName = "Criar e-mail alternativo sem arroba")]
        public void CriarEmailAlternativo_SemArroba_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var emailAlternativo = new EmailAlternativo(
                    Guid.NewGuid(),
                    "EduardaRboutlook.com",
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O e-mail deve conter um arroba (@).");
        }

        [Fact(DisplayName = "Criar e-mail alternativo com espaço")]
        public void CriarEmailAlternativo_ComEspaco_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var emailAlternativo = new EmailAlternativo(
                    Guid.NewGuid(),
                    "Eduarda Rb@outlook.com",
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O e-mail não pode conter espaços.");
        }

        [Fact(DisplayName = "Criar e-mail alternativo com mais de um arroba")]
        public void CriarEmailAlternativo_ComMaisDeUmArroba_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var emailAlternativo = new EmailAlternativo(
                    Guid.NewGuid(),
                    "Eduarda@Rb@outlook.com",
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O e-mail pode ter apenas um arroba (@).");
        }

        #endregion

        #region Testes do Nome de Usuário do E-mail

        [Fact(DisplayName = "Criar e-mail alternativo com nome de usuário nulo")]
        public void CriarEmailAlternativo_ComNomeDeUsuarioNulo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var emailAlternativo = new EmailAlternativo(
                    Guid.NewGuid(),
                    $"{null}@outlook.com",
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O nome de usuário do e-mail é obrigatório.");
        }

        [Fact(DisplayName = "Criar e-mail alternativo com nome de usuário vazio")]
        public void CriarEmailAlternativo_ComNomeDeUsuarioVazio_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var emailAlternativo = new EmailAlternativo(
                    Guid.NewGuid(),
                    "@outlook.com",
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O nome de usuário do e-mail é obrigatório.");
        }

        [Fact(DisplayName = "Criar e-mail alternativo com nome de usuário muito longo")]
        public void CriarEmailAlternativo_ComNomeDeUsuarioMuitoLongo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var emailAlternativo = new EmailAlternativo(
                    Guid.NewGuid(),
                    "MariaEduardaDominiqueDosSantosRibeiroFernandesLimaCostaMartinsDuarte@outlook.com",
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O nome de usuário do e-mail pode ter no máximo 64 caracteres.");
        }

        [Fact(DisplayName = "Criar e-mail alternativo com ponto no início")]
        public void CriarEmailAlternativo_ComPontoNoInício_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var emailAlternativo = new EmailAlternativo(
                    Guid.NewGuid(),
                    ".EduardaRb@outlook.com",
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O e-mail não pode começar com ponto (.).");
        }

        [Fact(DisplayName = "Criar e-mail alternativo com hífen no início")]
        public void CriarEmailAlternativo_ComHifenNoInício_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var emailAlternativo = new EmailAlternativo(
                    Guid.NewGuid(),
                    "-EduardaRb@outlook.com",
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O e-mail não pode começar com hífen (-).");
        }

        [Fact(DisplayName = "Criar e-mail alternativo com underscore no início")]
        public void CriarEmailAlternativo_ComUnderscoreNoInício_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var emailAlternativo = new EmailAlternativo(
                    Guid.NewGuid(),
                    "_EduardaRb@outlook.com",
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O e-mail não pode começar com underscore (_).");
        }

        [Fact(DisplayName = "Criar e-mail alternativo com caractere especial no início")]
        public void CriarEmailAlternativo_ComCaractereEspecialNoInício_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var emailAlternativo = new EmailAlternativo(
                    Guid.NewGuid(),
                    "!EduardaRb@outlook.com",
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O e-mail não pode começar com caractere especial.");
        }

        [Fact(DisplayName = "Criar e-mail alternativo com pontos consecutivos no nome de usuário")]
        public void CriarEmailAlternativo_ComPontosConsecutivosNoNomeDeUsuario_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var emailAlternativo = new EmailAlternativo(
                    Guid.NewGuid(),
                    "Eduarda..Rb@outlook.com",
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O nome de usuário do e-mail não pode conter pontos consecutivos (.., ..., .... e etc).");
        }

        [Fact(DisplayName = "Criar e-mail alternativo com hífens consecutivos no nome de usuário")]
        public void CriarEmailAlternativo_ComHifensConsecutivosNoNomeDeUsuario_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var emailAlternativo = new EmailAlternativo(
                    Guid.NewGuid(),
                    "Eduarda---Rb@outlook.com",
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O nome de usuário do e-mail não pode conter hífens consecutivos (--, ---, ---- e etc).");
        }

        [Fact(DisplayName = "Criar e-mail alternativo com underscores consecutivos no nome de usuário")]
        public void CriarEmailAlternativo_ComUnderscoresConsecutivosNoNomeDeUsuario_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var emailAlternativo = new EmailAlternativo(
                    Guid.NewGuid(),
                    "Eduarda____Rb@outlook.com",
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O nome de usuário do e-mail não pode conter underscores consecutivos (__, ___, ____ e etc).");
        }

        [Fact(DisplayName = "Criar e-mail alternativo com ponto no final do nome de usuário")]
        public void CriarEmailAlternativo_ComPontoNoFinalDoNomeDeUsuario_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var emailAlternativo = new EmailAlternativo(
                    Guid.NewGuid(),
                    "EduardaRb.@outlook.com",
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O nome de usuário do e-mail não pode terminar com ponto (.).");
        }

        [Fact(DisplayName = "Criar e-mail alternativo com hífen no final do nome de usuário")]
        public void CriarEmailAlternativo_ComHifenNoFinalDoNomeDeUsuario_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var emailAlternativo = new EmailAlternativo(
                    Guid.NewGuid(),
                    "EduardaRb-@outlook.com",
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O nome de usuário do e-mail não pode terminar com hífen (-).");
        }

        [Fact(DisplayName = "Criar e-mail alternativo com underscore no final do nome de usuário")]
        public void CriarEmailAlternativo_ComUnderscoreNoFinalDoNomeDeUsuario_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var emailAlternativo = new EmailAlternativo(
                    Guid.NewGuid(),
                    "EduardaRb_@outlook.com",
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O nome de usuário do e-mail não pode terminar com underscore (_).");
        }

        [Fact(DisplayName = "Criar e-mail alternativo com caractere especial no final do nome de usuário")]
        public void CriarEmailAlternativo_ComCaractereEspecialNoFinalDoNomeDeUsuario_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var emailAlternativo = new EmailAlternativo(
                    Guid.NewGuid(),
                    "EduardaRb$@outlook.com",
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O nome de usuário do e-mail não pode terminar com caractere especial.");
        }

        [Fact(DisplayName = "Criar e-mail alternativo com caractere especial inválido no nome de usuário")]
        public void CriarEmailAlternativo_ComCaractereEspecialInvalidoNoNomeDeUsuario_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var emailAlternativo = new EmailAlternativo(
                    Guid.NewGuid(),
                    "Eduarda,Rb@outlook.com",
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage($"O nome de usuário do e-mail não pode conter: {new string(ConstantesValidacao.CaracteresInvalidosEmailUsuario)}.");
        }

        #endregion

        #region Testes de Domínio do E-mail

        [Fact(DisplayName = "Criar e-mail alternativo com domínio nulo")]
        public void CriarEmailAlternativo_ComDominioNulo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var emailAlternativo = new EmailAlternativo(
                    Guid.NewGuid(),
                    $"EduardaRb@{null}",
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O domínio de e-mail é obrigatório.");
        }

        [Fact(DisplayName = "Criar e-mail alternativo com domínio vazio")]
        public void CriarEmailAlternativo_ComDominioVazio_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var emailAlternativo = new EmailAlternativo(
                    Guid.NewGuid(),
                    "EduardaRb@",
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O domínio de e-mail é obrigatório.");
        }

        [Fact(DisplayName = "Criar e-mail alternativo com domínio muito curto")]
        public void CriarEmailAlternativo_ComDominioMuitoCurto_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var emailAlternativo = new EmailAlternativo(
                    Guid.NewGuid(),
                    "EduardaRb@o.c",
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O domínio de e-mail deve ter no mínimo 4 caracteres.");
        }

        [Fact(DisplayName = "Criar e-mail alternativo com domínio muito longo")]
        public void CriarEmailAlternativo_ComDominioMuitoLongo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var emailAlternativo = new EmailAlternativo(
                    Guid.NewGuid(),
                    "E@please-try-to.send-me-an-email-if-you-can-possibly-begin-to-remember-this-coz.this-is-the-longest-email-address-known-to-man-but-to-be-honest.this-is-such-a-stupidly-long-sub-domain-it-could-go-on-forever.pacraig.com.construction.technology.association",
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O domínio de e-mail pode ter no máximo 251 caracteres.");
        }

        [Fact(DisplayName = "Criar e-mail alternativo sem ponto no domínio")]
        public void CriarEmailAlternativo_SemPontoNoDominio_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var emailAlternativo = new EmailAlternativo(
                    Guid.NewGuid(),
                    "EduardaRb@outlook",
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O domínio de e-mail deve conter pelo menos um ponto (.), exemplo: \"dominio.com\".");
        }

        [Fact(DisplayName = "Criar e-mail alternativo com ponto no início do domínio")]
        public void CriarEmailAlternativo_ComPontoNoInícioDoDominio_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var emailAlternativo = new EmailAlternativo(
                    Guid.NewGuid(),
                    "EduardaRb@.outlook.com",
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O domínio de e-mail não pode começar com ponto (.).");
        }

        [Fact(DisplayName = "Criar e-mail alternativo com hífen no início do domínio")]
        public void CriarEmailAlternativo_ComHifenNoInícioDoDominio_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var emailAlternativo = new EmailAlternativo(
                    Guid.NewGuid(),
                    "EduardaRb@-outlook.com",
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O domínio de e-mail não pode começar com hífen (-).");
        }

        [Fact(DisplayName = "Criar e-mail alternativo com pontos consecutivos no domínio")]
        public void CriarEmailAlternativo_ComPontosConsecutivosNoDominio_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var emailAlternativo = new EmailAlternativo(
                    Guid.NewGuid(),
                    "EduardaRb@outlook..com",
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O domínio de e-mail não pode conter pontos consecutivos (.., ..., .... e etc).");
        }

        [Fact(DisplayName = "Criar e-mail alternativo com hífens consecutivos no domínio")]
        public void CriarEmailAlternativo_ComHifensConsecutivosNoDominio_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var emailAlternativo = new EmailAlternativo(
                    Guid.NewGuid(),
                    "EduardaRb@out--look.com",
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O domínio de e-mail não pode conter hífens consecutivos (--, ---, ---- e etc).");
        }

        [Fact(DisplayName = "Criar e-mail alternativo com ponto no final")]
        public void CriarEmailAlternativo_ComPontoNoFinal_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var emailAlternativo = new EmailAlternativo(
                    Guid.NewGuid(),
                    "EduardaRb@outlook.com.",
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O e-mail não pode terminar com ponto (.).");
        }

        [Fact(DisplayName = "Criar e-mail alternativo com hífen no final")]
        public void CriarEmailAlternativo_ComHifenNoFinal_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var emailAlternativo = new EmailAlternativo(
                    Guid.NewGuid(),
                    "EduardaRb@outlook.com-",
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O e-mail não pode terminar com hífen (-).");
        }

        [Fact(DisplayName = "Criar e-mail alternativo com caractere especial inválido no domínio")]
        public void CriarEmailAlternativo_ComCaractereEspecialInvalidoNoDominio_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var emailAlternativo = new EmailAlternativo(
                    Guid.NewGuid(),
                    "EduardaRb@out*look.com",
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage($"O domínio de e-mail não pode conter: {new string(ConstantesValidacao.CaracteresInvalidosEmailDominio)}.");
        }

        [Fact(DisplayName = "Criar e-mail alternativo com rótulo do domínio muito longo")]
        public void CriarEmailAlternativo_ComRotuloDoDominioMuitoLongo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var emailAlternativo = new EmailAlternativo(
                    Guid.NewGuid(),
                    "E@send-me-an-email-if-you-can-possibly-begin-to-remember-this-bcoz.com",
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Os rótulos do domínio de e-mail podem ter no máximo 63 caracteres.");
        }

        [Fact(DisplayName = "Criar e-mail alternativo com extensão de domínio (TLD) muito curto")]
        public void CriarEmailAlternativo_ComExtensãoDeDominioMuitoCurto_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var emailAlternativo = new EmailAlternativo(
                    Guid.NewGuid(),
                    "EduardaRb@outlook.c",
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("As extensões de domínio (TLDs) devem ter no mínimo 2 caracteres.");
        }

        [Fact(DisplayName = "Criar e-mail alternativo com número na extensão de domínio (TLD)")]
        public void CriarEmailAlternativo_ComNumeroNaExtensãoDeDominio_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var emailAlternativo = new EmailAlternativo(
                    Guid.NewGuid(),
                    "EduardaRb@outlook.c0m",
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("As extensões de domínio (TLDs) não podem conter números.");
        }

        #endregion

        #endregion

        #endregion
    }
}
