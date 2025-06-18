using Xunit;
using FluentAssertions;
using InnatAPP.Domain.Shared;
using InnatAPP.Domain.Entities;

namespace InnatAPP.Domain.Tests
{
    public class MensagemUnitTest
    {
        #region Testes de Parâmetros Válidos

        [Fact(DisplayName = "Criar mensagem com estado válido")]
        public void CriarMensagem_ComParametrosValidos_ResultandoEmObjetoComEstadoValido()
        {
            Action action = () =>
            {
                var mensagem = new Mensagem(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    "EduardaRb@outlook.com",
                    "Adorei o site, mas gostaria que tivesse como favoritar produtos"
                );
            };

            action.Should()
                .NotThrow<InnatAPP.Domain.Validation.DomainExceptionValidation>();
        }

        #endregion

        #region Testes de Parâmetros Inválidos

        #region Testes de Id

        [Fact(DisplayName = "Criar mensagem com id vazio")]
        public void CriarMensagem_ComIdVazio_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var mensagem = new Mensagem(
                    Guid.Empty,
                    "Eduarda Ribeiro",
                    "EduardaRb@outlook.com",
                    "Adorei o site, mas gostaria que tivesse como favoritar produtos"
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O id é obrigatório.");
        }

        #endregion

        #region Testes de Nome

        [Fact(DisplayName = "Criar mensagem com nome nulo")]
        public void CriarMensagem_ComNomeNulo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var mensagem = new Mensagem(
                    Guid.NewGuid(),
                    null,
                    "EduardaRb@outlook.com",
                    "Adorei o site, mas gostaria que tivesse como favoritar produtos"
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O nome é obrigatório.");
        }

        [Fact(DisplayName = "Criar mensagem com nome vazio")]
        public void CriarMensagem_ComNomeVazio_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var mensagem = new Mensagem(
                    Guid.NewGuid(),
                    "",
                    "EduardaRb@outlook.com",
                    "Adorei o site, mas gostaria que tivesse como favoritar produtos"
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O nome é obrigatório.");
        }

        [Fact(DisplayName = "Criar mensagem com nome em branco")]
        public void CriarMensagem_ComNomeEmBranco_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var mensagem = new Mensagem(
                    Guid.NewGuid(),
                    "   ",
                    "EduardaRb@outlook.com",
                    "Adorei o site, mas gostaria que tivesse como favoritar produtos"
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O nome é obrigatório.");
        }

        [Fact(DisplayName = "Criar mensagem com espaço no início do nome")]
        public void CriarMensagem_ComEspacoNoInícioDoNome_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var mensagem = new Mensagem(
                    Guid.NewGuid(),
                    " Eduarda Ribeiro",
                    "EduardaRb@outlook.com",
                    "Adorei o site, mas gostaria que tivesse como favoritar produtos"
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O nome não pode começar com espaço (\" \").");
        }

        [Fact(DisplayName = "Criar mensagem com espaço no final do nome")]
        public void CriarMensagem_ComEspacoNoFinalDoNome_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var mensagem = new Mensagem(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro ",
                    "EduardaRb@outlook.com",
                    "Adorei o site, mas gostaria que tivesse como favoritar produtos"
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O nome não pode terminar com espaço (\" \").");
        }

        [Fact(DisplayName = "Criar mensagem com espaços consecutivos no nome")]
        public void CriarMensagem_ComEspacosConsecutivosNoNome_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var mensagem = new Mensagem(
                    Guid.NewGuid(),
                    "Eduarda  Ribeiro",
                    "EduardaRb@outlook.com",
                    "Adorei o site, mas gostaria que tivesse como favoritar produtos"
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O nome não pode ter espaços consecutivos (\"  \", \"   \", \"    \" e etc).");
        }

        [Fact(DisplayName = "Criar mensagem com nome muito curto")]
        public void CriarMensagem_ComNomeMuitoCurto_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var mensagem = new Mensagem(
                    Guid.NewGuid(),
                    "ER",
                    "EduardaRb@outlook.com",
                    "Adorei o site, mas gostaria que tivesse como favoritar produtos"
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O nome deve ter no mínimo 3 caracteres.");
        }

        [Fact(DisplayName = "Criar mensagem com nome muito longo")]
        public void CriarMensagem_ComNomeMuitoLongo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var mensagem = new Mensagem(
                    Guid.NewGuid(),
                    "Maria Eduarda Dominique Pereira Dos Santos Oliveira De Castro Ribeiro Fernandes Lima Costa Martins Duarte",
                    "EduardaRb@outlook.com",
                    "Adorei o site, mas gostaria que tivesse como favoritar produtos"
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O nome pode ter no máximo 100 caracteres.");
        }

        #endregion

        #region Testes de E-mail

        #region Testes Gerais de E-mail

        [Fact(DisplayName = "Criar mensagem com e-mail nulo")]
        public void CriarMensagem_ComEmailNulo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var mensagem = new Mensagem(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    null,
                    "Adorei o site, mas gostaria que tivesse como favoritar produtos"
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O e-mail é obrigatório.");
        }

        [Fact(DisplayName = "Criar mensagem com e-mail vazio")]
        public void CriarMensagem_ComEmailVazio_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var mensagem = new Mensagem(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    "",
                    "Adorei o site, mas gostaria que tivesse como favoritar produtos"
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O e-mail é obrigatório.");
        }

        [Fact(DisplayName = "Criar mensagem com e-mail muito curto")]
        public void CriarMensagem_ComEmailMuitoCurto_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var mensagem = new Mensagem(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    "E@O.C",
                    "Adorei o site, mas gostaria que tivesse como favoritar produtos"
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O e-mail deve ter no mínimo 6 caracteres.");
        }

        [Fact(DisplayName = "Criar mensagem com e-mail muito longo")]
        public void CriarMensagem_ComEmailMuitoLongo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var mensagem = new Mensagem(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    "MariaEduardaDominiquePereiraDosSantosOliveiraDeCastroRibeiroFernandesLimaCostaMartinsDuarte-03-05-1980-Agrônoma_Plantio15_03Colheita30_65scHaMilho120scHaIrrigacao10mmDiaFertNPK5_20_20Armazem5000scFazendaBelaVistaBR163Km78ZonaRuralSinopMT2025@agricultura.gov.br",
                    "Adorei o site, mas gostaria que tivesse como favoritar produtos"
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O e-mail pode ter no máximo 254 caracteres.");
        }

        [Fact(DisplayName = "Criar mensagem sem arroba no e-mail")]
        public void CriarMensagem_SemArrobaNoEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var mensagem = new Mensagem(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    "EduardaRboutlook.com",
                    "Adorei o site, mas gostaria que tivesse como favoritar produtos"
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O e-mail deve conter um arroba (@).");
        }

        [Fact(DisplayName = "Criar mensagem com espaço no e-mail")]
        public void CriarMensagem_ComEspacoNoEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var mensagem = new Mensagem(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    "Eduarda Rb@outlook.com",
                    "Adorei o site, mas gostaria que tivesse como favoritar produtos"
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O e-mail não pode conter espaços.");
        }

        [Fact(DisplayName = "Criar mensagem com mais de um arroba no e-mail")]
        public void CriarMensagem_ComMaisDeUmArrobaNoEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var mensagem = new Mensagem(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    "Eduarda@Rb@outlook.com",
                    "Adorei o site, mas gostaria que tivesse como favoritar produtos"
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O e-mail pode ter apenas um arroba (@).");
        }

        #endregion

        #region Testes do Nome de Usuário do E-mail

        [Fact(DisplayName = "Criar mensagem com nome de usuário do e-mail nulo")]
        public void CriarMensagem_ComNomeDeUsuarioDoEmailNulo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var mensagem = new Mensagem(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    $"{null}@outlook.com",
                    "Adorei o site, mas gostaria que tivesse como favoritar produtos"
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O nome de usuário do e-mail é obrigatório.");
        }

        [Fact(DisplayName = "Criar mensagem com nome de usuário do e-mail vazio")]
        public void CriarMensagem_ComNomeDeUsuarioDoEmailVazio_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var mensagem = new Mensagem(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    "@outlook.com",
                    "Adorei o site, mas gostaria que tivesse como favoritar produtos"
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O nome de usuário do e-mail é obrigatório.");
        }

        [Fact(DisplayName = "Criar mensagem com nome de usuário do e-mail muito longo")]
        public void CriarMensagem_ComNomeDeUsuarioDoEmailMuitoLongo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var mensagem = new Mensagem(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    "MariaEduardaDominiqueDosSantosRibeiroFernandesLimaCostaMartinsDuarte@outlook.com",
                    "Adorei o site, mas gostaria que tivesse como favoritar produtos"
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O nome de usuário do e-mail pode ter no máximo 64 caracteres.");
        }

        [Fact(DisplayName = "Criar mensagem com ponto no início do e-mail")]
        public void CriarMensagem_ComPontoNoInícioDoEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var mensagem = new Mensagem(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    ".EduardaRb@outlook.com",
                    "Adorei o site, mas gostaria que tivesse como favoritar produtos"
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O e-mail não pode começar com ponto (.).");
        }

        [Fact(DisplayName = "Criar mensagem com hífen no início do e-mail")]
        public void CriarMensagem_ComHifenNoInícioDoEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var mensagem = new Mensagem(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    "-EduardaRb@outlook.com",
                    "Adorei o site, mas gostaria que tivesse como favoritar produtos"
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O e-mail não pode começar com hífen (-).");
        }

        [Fact(DisplayName = "Criar mensagem com underscore no início do e-mail")]
        public void CriarMensagem_ComUnderscoreNoInícioDoEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var mensagem = new Mensagem(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    "_EduardaRb@outlook.com",
                    "Adorei o site, mas gostaria que tivesse como favoritar produtos"
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O e-mail não pode começar com underscore (_).");
        }

        [Fact(DisplayName = "Criar mensagem com caractere especial no início do e-mail")]
        public void CriarMensagem_ComCaractereEspecialNoInícioDoEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var mensagem = new Mensagem(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    "!EduardaRb@outlook.com",
                    "Adorei o site, mas gostaria que tivesse como favoritar produtos"
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O e-mail não pode começar com caractere especial.");
        }

        [Fact(DisplayName = "Criar mensagem com pontos consecutivos no nome de usuário do e-mail")]
        public void CriarMensagem_ComPontosConsecutivosNoNomeDeUsuarioDoEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var mensagem = new Mensagem(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    "Eduarda..Rb@outlook.com",
                    "Adorei o site, mas gostaria que tivesse como favoritar produtos"
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O nome de usuário do e-mail não pode conter pontos consecutivos (.., ..., .... e etc).");
        }

        [Fact(DisplayName = "Criar mensagem com hífens consecutivos no nome de usuário do e-mail")]
        public void CriarMensagem_ComHifensConsecutivosNoNomeDeUsuarioDoEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var mensagem = new Mensagem(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    "Eduarda---Rb@outlook.com",
                    "Adorei o site, mas gostaria que tivesse como favoritar produtos"
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O nome de usuário do e-mail não pode conter hífens consecutivos (--, ---, ---- e etc).");
        }

        [Fact(DisplayName = "Criar mensagem com underscores consecutivos no nome de usuário do e-mail")]
        public void CriarMensagem_ComUnderscoresConsecutivosNoNomeDeUsuarioDoEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var mensagem = new Mensagem(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    "Eduarda____Rb@outlook.com",
                    "Adorei o site, mas gostaria que tivesse como favoritar produtos"
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O nome de usuário do e-mail não pode conter underscores consecutivos (__, ___, ____ e etc).");
        }

        [Fact(DisplayName = "Criar mensagem com ponto no final do nome de usuário do e-mail")]
        public void CriarMensagem_ComPontoNoFinalDoNomeDeUsuarioDoEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var mensagem = new Mensagem(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    "EduardaRb.@outlook.com",
                    "Adorei o site, mas gostaria que tivesse como favoritar produtos"
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O nome de usuário do e-mail não pode terminar com ponto (.).");
        }

        [Fact(DisplayName = "Criar mensagem com hífen no final do nome de usuário do e-mail")]
        public void CriarMensagem_ComHifenNoFinalDoNomeDeUsuarioDoEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var mensagem = new Mensagem(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    "EduardaRb-@outlook.com",
                    "Adorei o site, mas gostaria que tivesse como favoritar produtos"
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O nome de usuário do e-mail não pode terminar com hífen (-).");
        }

        [Fact(DisplayName = "Criar mensagem com underscore no final do nome de usuário do e-mail")]
        public void CriarMensagem_ComUnderscoreNoFinalDoNomeDeUsuarioDoEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var mensagem = new Mensagem(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    "EduardaRb_@outlook.com",
                    "Adorei o site, mas gostaria que tivesse como favoritar produtos"
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O nome de usuário do e-mail não pode terminar com underscore (_).");
        }

        [Fact(DisplayName = "Criar mensagem com caractere especial no final do nome de usuário do e-mail")]
        public void CriarMensagem_ComCaractereEspecialNoFinalDoNomeDeUsuarioDoEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var mensagem = new Mensagem(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    "EduardaRb$@outlook.com",
                    "Adorei o site, mas gostaria que tivesse como favoritar produtos"
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O nome de usuário do e-mail não pode terminar com caractere especial.");
        }

        [Fact(DisplayName = "Criar mensagem com caractere especial inválido no nome de usuário do e-mail")]
        public void CriarMensagem_ComCaractereEspecialInvalidoNoNomeDeUsuarioDoEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var mensagem = new Mensagem(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    "Eduarda,Rb@outlook.com",
                    "Adorei o site, mas gostaria que tivesse como favoritar produtos"
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage($"O nome de usuário do e-mail não pode conter: {new string(ConstantesValidacao.CaracteresInvalidosEmailUsuario)}.");
        }

        #endregion

        #region Testes de Domínio do E-mail

        [Fact(DisplayName = "Criar mensagem com domínio de e-mail nulo")]
        public void CriarMensagem_ComDominioDeEmailNulo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var mensagem = new Mensagem(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    $"EduardaRb@{null}",
                    "Adorei o site, mas gostaria que tivesse como favoritar produtos"
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O domínio de e-mail é obrigatório.");
        }

        [Fact(DisplayName = "Criar mensagem com domínio de e-mail vazio")]
        public void CriarMensagem_ComDominioDeEmailVazio_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var mensagem = new Mensagem(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    "EduardaRb@",
                    "Adorei o site, mas gostaria que tivesse como favoritar produtos"
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O domínio de e-mail é obrigatório.");
        }

        [Fact(DisplayName = "Criar mensagem com domínio de e-mail muito curto")]
        public void CriarMensagem_ComDominioDeEmailMuitoCurto_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var mensagem = new Mensagem(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    "EduardaRb@o.c",
                    "Adorei o site, mas gostaria que tivesse como favoritar produtos"
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O domínio de e-mail deve ter no mínimo 4 caracteres.");
        }

        [Fact(DisplayName = "Criar mensagem com domínio de e-mail muito longo")]
        public void CriarMensagem_ComDominioDeEmailMuitoLongo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var mensagem = new Mensagem(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    "E@please-try-to.send-me-an-email-if-you-can-possibly-begin-to-remember-this-coz.this-is-the-longest-email-address-known-to-man-but-to-be-honest.this-is-such-a-stupidly-long-sub-domain-it-could-go-on-forever.pacraig.com.construction.technology.association",
                    "Adorei o site, mas gostaria que tivesse como favoritar produtos"
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O domínio de e-mail pode ter no máximo 251 caracteres.");
        }

        [Fact(DisplayName = "Criar mensagem sem ponto no domínio de e-mail")]
        public void CriarMensagem_SemPontoNoDominioDeEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var mensagem = new Mensagem(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    "EduardaRb@outlook",
                    "Adorei o site, mas gostaria que tivesse como favoritar produtos"
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O domínio de e-mail deve conter pelo menos um ponto (.), exemplo: \"dominio.com\".");
        }

        [Fact(DisplayName = "Criar mensagem com ponto no início do domínio de e-mail")]
        public void CriarMensagem_ComPontoNoInícioDoDominioDeEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var mensagem = new Mensagem(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    "EduardaRb@.outlook.com",
                    "Adorei o site, mas gostaria que tivesse como favoritar produtos"
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O domínio de e-mail não pode começar com ponto (.).");
        }

        [Fact(DisplayName = "Criar mensagem com hífen no início do domínio de e-mail")]
        public void CriarMensagem_ComHifenNoInícioDoDominioDeEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var mensagem = new Mensagem(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    "EduardaRb@-outlook.com",
                    "Adorei o site, mas gostaria que tivesse como favoritar produtos"
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O domínio de e-mail não pode começar com hífen (-).");
        }

        [Fact(DisplayName = "Criar mensagem com pontos consecutivos no domínio de e-mail")]
        public void CriarMensagem_ComPontosConsecutivosNoDominioDeEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var mensagem = new Mensagem(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    "EduardaRb@outlook..com",
                    "Adorei o site, mas gostaria que tivesse como favoritar produtos"
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O domínio de e-mail não pode conter pontos consecutivos (.., ..., .... e etc).");
        }

        [Fact(DisplayName = "Criar mensagem com hífens consecutivos no domínio de e-mail")]
        public void CriarMensagem_ComHifensConsecutivosNoDominioDeEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var mensagem = new Mensagem(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    "EduardaRb@out--look.com",
                    "Adorei o site, mas gostaria que tivesse como favoritar produtos"
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O domínio de e-mail não pode conter hífens consecutivos (--, ---, ---- e etc).");
        }

        [Fact(DisplayName = "Criar mensagem com ponto no final do e-mail")]
        public void CriarMensagem_ComPontoNoFinalDoEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var mensagem = new Mensagem(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    "EduardaRb@outlook.com.",
                    "Adorei o site, mas gostaria que tivesse como favoritar produtos"
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O e-mail não pode terminar com ponto (.).");
        }

        [Fact(DisplayName = "Criar mensagem com hífen no final do e-mail")]
        public void CriarMensagem_ComHifenNoFinalDoEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var mensagem = new Mensagem(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    "EduardaRb@outlook.com-",
                    "Adorei o site, mas gostaria que tivesse como favoritar produtos"
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O e-mail não pode terminar com hífen (-).");
        }

        [Fact(DisplayName = "Criar mensagem com caractere especial inválido no domínio de e-mail")]
        public void CriarMensagem_ComCaractereEspecialInvalidoNoDominioDeEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var mensagem = new Mensagem(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    "EduardaRb@out*look.com",
                    "Adorei o site, mas gostaria que tivesse como favoritar produtos"
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage($"O domínio de e-mail não pode conter: {new string(ConstantesValidacao.CaracteresInvalidosEmailDominio)}.");
        }

        [Fact(DisplayName = "Criar mensagem com rótulo do domínio de e-mail muito longo")]
        public void CriarMensagem_ComRotuloDoDominioDeEmailMuitoLongo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var mensagem = new Mensagem(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    "E@send-me-an-email-if-you-can-possibly-begin-to-remember-this-bcoz.com",
                    "Adorei o site, mas gostaria que tivesse como favoritar produtos"
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Os rótulos do domínio de e-mail podem ter no máximo 63 caracteres.");
        }

        [Fact(DisplayName = "Criar mensagem com extensão de domínio (TLD) de e-mail muito curto")]
        public void CriarMensagem_ComExtensãoDeDominioDeEmailMuitoCurto_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var mensagem = new Mensagem(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    "EduardaRb@outlook.c",
                    "Adorei o site, mas gostaria que tivesse como favoritar produtos"
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("As extensões de domínio (TLDs) devem ter no mínimo 2 caracteres.");
        }

        [Fact(DisplayName = "Criar mensagem com número na extensão de domínio (TLD) de e-mail")]
        public void CriarMensagem_ComNumeroNaExtensãoDeDominioDeEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var mensagem = new Mensagem(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    "EduardaRb@outlook.c0m",
                    "Adorei o site, mas gostaria que tivesse como favoritar produtos"
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("As extensões de domínio (TLDs) não podem conter números.");
        }

        #endregion

        #endregion

        #region Testes de Texto

        [Fact(DisplayName = "Criar mensagem com texto nulo")]
        public void CriarMensagem_ComTextoNulo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var mensagem = new Mensagem(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    "EduardaRb@outlook.com",
                    null
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("A mensagem é obrigatória.");
        }

        [Fact(DisplayName = "Criar mensagem com texto vazio")]
        public void CriarMensagem_ComTextoVazio_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var mensagem = new Mensagem(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    "EduardaRb@outlook.com",
                    ""
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("A mensagem é obrigatória.");
        }

        [Fact(DisplayName = "Criar mensagem com texto em branco")]
        public void CriarMensagem_ComTextoEmBranco_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var mensagem = new Mensagem(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    "EduardaRb@outlook.com",
                    " "
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("A mensagem é obrigatória.");
        }



        [Fact(DisplayName = "Criar mensagem com texto muito curto")]
        public void CriarMensagem_ComTextoMuitoCurto_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var mensagem = new Mensagem(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    "EduardaRb@outlook.com",
                    "Ok"
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("A mensagem deve ter no mínimo 5 caracteres.");
        }

        [Fact(DisplayName = "Criar mensagem com texto muito longo")]
        public void CriarMensagem_ComTextoMuitoLongo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var mensagem = new Mensagem(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    "EduardaRb@outlook.com",
                    "Prezada equipe do Inova Agro Tech, sou Maria Eduarda, engenheira agrônoma de Sinop-MT, e venho utilizando a plataforma desde o ano passado. Gostaria de compartilhar algumas observações que poderiam melhorar ainda mais essa excelente iniciativa. Primeiramente, parabéns pelo design intuitivo e pelo sistema de reviews - tem sido fundamental para minhas decisões de compra na fazenda. Seria interessante adicionar filtros para reviews de profissionais verificados, como agrônomos com CREA, pois daria mais credibilidade às avaliações técnicas. Outra sugestão seria permitir o upload de manuais técnicos nos cadastros de produtos, o que ajudaria nós, produtores, a entender melhor as especificações. Por fim, o pódio de melhores avaliações é muito bom, mas talvez pudesse ter versões por categoria, como tratores e sistemas de irrigação separadamente. Agradeço pela atenção e parabenizo novamente toda a equipe pelo trabalho."
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("A mensagem pode ter no máximo 700 caracteres.");
        }

        #endregion

        #endregion

    }
}