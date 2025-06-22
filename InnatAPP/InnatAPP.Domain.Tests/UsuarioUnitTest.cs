using Xunit;
using FluentAssertions;
using InnatAPP.Domain.Shared;
using InnatAPP.Domain.Entities;
using InnatAPP.Domain.ValueObjects;

namespace InnatAPP.Domain.Tests
{
    public class UsuarioUnitTest
    {
        #region Testes de Parâmetros Válidos

        [Fact(DisplayName = "Criar usuário com estado válido")]
        public void CriarUsuario_ComParametrosValidos_ResultandoEmObjetoComEstadoValido()
        {
            Action action = () =>
            {
                var usuario = new Usuario(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    "EduardaRb@outlook.com",
                    "Edu@rd@9382",
                    "Foto-de-perfil.png",
                    "Agrônoma há mais de 10 anos.",
                    TipoUsuario.FromString("Avaliador")
                );
            };

            action.Should()
                .NotThrow<InnatAPP.Domain.Validation.DomainExceptionValidation>();
        }

        #endregion

        #region Testes de Parâmetros Inválidos

        #region Testes de Id

        [Fact(DisplayName = "Criar usuário com id vazio")]
        public void CriarUsuario_ComIdVazio_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var usuario = new Usuario(
                    Guid.Empty,
                    "Eduarda Ribeiro",
                    "EduardaRb@outlook.com",
                    "Edu@rd@9382",
                    "Foto-de-perfil.png",
                    "Agrônoma há mais de 10 anos.",
                    TipoUsuario.FromString("Avaliador")
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O id é obrigatório.");
        }

        #endregion

        #region Testes de Nome

        [Fact(DisplayName = "Criar usuário com nome nulo")]
        public void CriarUsuario_ComNomeNulo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var usuario = new Usuario(
                    Guid.NewGuid(),
                    null,
                    "EduardaRb@outlook.com",
                    "Edu@rd@9382",
                    "Foto-de-perfil.png",
                    "Agrônoma há mais de 10 anos.",
                    TipoUsuario.FromString("Avaliador")
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O nome de usuário é obrigatório.");
        }

        [Fact(DisplayName = "Criar usuário com nome vazio")]
        public void CriarUsuario_ComNomeVazio_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var usuario = new Usuario(
                    Guid.NewGuid(),
                    "",
                    "EduardaRb@outlook.com",
                    "Edu@rd@9382",
                    "Foto-de-perfil.png",
                    "Agrônoma há mais de 10 anos.",
                    TipoUsuario.FromString("Avaliador")
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O nome de usuário é obrigatório.");
        }

        [Fact(DisplayName = "Criar usuário com nome em branco")]
        public void CriarUsuario_ComNomeEmBranco_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var usuario = new Usuario(
                    Guid.NewGuid(),
                    "   ",
                    "EduardaRb@outlook.com",
                    "Edu@rd@9382",
                    "Foto-de-perfil.png",
                    "Agrônoma há mais de 10 anos.",
                    TipoUsuario.FromString("Avaliador")
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O nome de usuário é obrigatório.");
        }

        [Fact(DisplayName = "Criar usuário com espaço no início do nome")]
        public void CriarUsuario_ComEspacoNoInícioDoNome_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var usuario = new Usuario(
                    Guid.NewGuid(),
                    " Eduarda Ribeiro",
                    "EduardaRb@outlook.com",
                    "Edu@rd@9382",
                    "Foto-de-perfil.png",
                    "Agrônoma há mais de 10 anos.",
                    TipoUsuario.FromString("Avaliador")
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O nome de usuário não pode começar com espaço (\" \").");
        }

        [Fact(DisplayName = "Criar usuário com espaço no final do nome")]
        public void CriarUsuario_ComEspacoNoFinalDoNome_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var usuario = new Usuario(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro ",
                    "EduardaRb@outlook.com",
                    "Edu@rd@9382",
                    "Foto-de-perfil.png",
                    "Agrônoma há mais de 10 anos.",
                    TipoUsuario.FromString("Avaliador")
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O nome de usuário não pode terminar com espaço (\" \").");
        }

        [Fact(DisplayName = "Criar usuário com espaços consecutivos no nome")]
        public void CriarUsuario_ComEspacosConsecutivosNoNome_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var usuario = new Usuario(
                    Guid.NewGuid(),
                    "Eduarda  Ribeiro",
                    "EduardaRb@outlook.com",
                    "Edu@rd@9382",
                    "Foto-de-perfil.png",
                    "Agrônoma há mais de 10 anos.",
                    TipoUsuario.FromString("Avaliador")
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O nome de usuário não pode ter espaços consecutivos (\"  \", \"   \", \"    \" e etc).");
        }

        [Fact(DisplayName = "Criar usuário com nome muito curto")]
        public void CriarUsuario_ComNomeMuitoCurto_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var usuario = new Usuario(
                    Guid.NewGuid(),
                    "ER",
                    "EduardaRb@outlook.com",
                    "Edu@rd@9382",
                    "Foto-de-perfil.png",
                    "Agrônoma há mais de 10 anos.",
                    TipoUsuario.FromString("Avaliador")
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O nome de usuário deve ter no mínimo 3 caracteres.");
        }

        [Fact(DisplayName = "Criar usuário com nome muito longo")]
        public void CriarUsuario_ComNomeMuitoLongo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var usuario = new Usuario(
                    Guid.NewGuid(),
                    "Maria Eduarda Dominique Pereira Dos Santos Oliveira De Castro Ribeiro Fernandes Lima Costa Martins Duarte",
                    "EduardaRb@outlook.com",
                    "Edu@rd@9382",
                    "Foto-de-perfil.png",
                    "Agrônoma há mais de 10 anos.",
                    TipoUsuario.FromString("Avaliador")
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O nome de usuário pode ter no máximo 100 caracteres.");
        }

        #endregion

        #region Testes de E-mail

        #region Testes Gerais de E-mail

        [Fact(DisplayName = "Criar usuário com e-mail nulo")]
        public void CriarUsuario_ComEmailNulo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var usuario = new Usuario(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    null,
                    "Edu@rd@9382",
                    "Foto-de-perfil.png",
                    "Agrônoma há mais de 10 anos.",
                    TipoUsuario.FromString("Avaliador")
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O e-mail é obrigatório.");
        }

        [Fact(DisplayName = "Criar usuário com e-mail vazio")]
        public void CriarUsuario_ComEmailVazio_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var usuario = new Usuario(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    "",
                    "Edu@rd@9382",
                    "Foto-de-perfil.png",
                    "Agrônoma há mais de 10 anos.",
                    TipoUsuario.FromString("Avaliador")
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O e-mail é obrigatório.");
        }

        [Fact(DisplayName = "Criar usuário com e-mail muito curto")]
        public void CriarUsuario_ComEmailMuitoCurto_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var usuario = new Usuario(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    "E@O.C",
                    "Edu@rd@9382",
                    "Foto-de-perfil.png",
                    "Agrônoma há mais de 10 anos.",
                    TipoUsuario.FromString("Avaliador")
                );  
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O e-mail deve ter no mínimo 6 caracteres.");
        }

        [Fact(DisplayName = "Criar usuário com e-mail muito longo")]
        public void CriarUsuario_ComEmailMuitoLongo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var usuario = new Usuario(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    "MariaEduardaDominiquePereiraDosSantosOliveiraDeCastroRibeiroFernandesLimaCostaMartinsDuarte-03-05-1980-Agrônoma_Plantio15_03Colheita30_65scHaMilho120scHaIrrigacao10mmDiaFertNPK5_20_20Armazem5000scFazendaBelaVistaBR163Km78ZonaRuralSinopMT2025@agricultura.gov.br",
                    "Edu@rd@9382",
                    "Foto-de-perfil.png",
                    "Agrônoma há mais de 10 anos.",
                    TipoUsuario.FromString("Avaliador")
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O e-mail pode ter no máximo 254 caracteres.");
        }

        [Fact(DisplayName = "Criar usuário sem arroba no e-mail")]
        public void CriarUsuario_SemArrobaNoEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var usuario = new Usuario(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    "EduardaRboutlook.com",
                    "Edu@rd@9382",
                    "Foto-de-perfil.png",
                    "Agrônoma há mais de 10 anos.",
                    TipoUsuario.FromString("Avaliador")
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O e-mail deve conter um arroba (@).");
        }

        [Fact(DisplayName = "Criar usuário com espaço no e-mail")]
        public void CriarUsuario_ComEspacoNoEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var usuario = new Usuario(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    "Eduarda Rb@outlook.com",
                    "Edu@rd@9382",
                    "Foto-de-perfil.png",
                    "Agrônoma há mais de 10 anos.",
                    TipoUsuario.FromString("Avaliador")
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O e-mail não pode conter espaços.");
        }

        [Fact(DisplayName = "Criar usuário com mais de um arroba no e-mail")]
        public void CriarUsuario_ComMaisDeUmArrobaNoEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var usuario = new Usuario(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    "Eduarda@Rb@outlook.com",
                    "Edu@rd@9382",
                    "Foto-de-perfil.png",
                    "Agrônoma há mais de 10 anos.",
                    TipoUsuario.FromString("Avaliador")
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O e-mail pode ter apenas um arroba (@).");
        }

        #endregion

        #region Testes do Nome de Usuário do E-mail

        [Fact(DisplayName = "Criar usuário com nome de usuário do e-mail nulo")]
        public void CriarUsuario_ComNomeDeUsuarioDoEmailNulo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var usuario = new Usuario(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    $"{null}@outlook.com",
                    "Edu@rd@9382",
                    "Foto-de-perfil.png",
                    "Agrônoma há mais de 10 anos.",
                    TipoUsuario.FromString("Avaliador")
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O nome de usuário do e-mail é obrigatório.");
        }

        [Fact(DisplayName = "Criar usuário com nome de usuário do e-mail vazio")]
        public void CriarUsuario_ComNomeDeUsuarioDoEmailVazio_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var usuario = new Usuario(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    "@outlook.com",
                    "Edu@rd@9382",
                    "Foto-de-perfil.png",
                    "Agrônoma há mais de 10 anos.",
                    TipoUsuario.FromString("Avaliador")
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O nome de usuário do e-mail é obrigatório.");
        }

        [Fact(DisplayName = "Criar usuário com nome de usuário do e-mail muito longo")]
        public void CriarUsuario_ComNomeDeUsuarioDoEmailMuitoLongo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var usuario = new Usuario(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    "MariaEduardaDominiqueDosSantosRibeiroFernandesLimaCostaMartinsDuarte@outlook.com",
                    "Edu@rd@9382",
                    "Foto-de-perfil.png",
                    "Agrônoma há mais de 10 anos.",
                    TipoUsuario.FromString("Avaliador")
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O nome de usuário do e-mail pode ter no máximo 64 caracteres.");
        }

        [Fact(DisplayName = "Criar usuário com ponto no início do e-mail")]
        public void CriarUsuario_ComPontoNoInícioDoEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var usuario = new Usuario(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    ".EduardaRb@outlook.com",
                    "Edu@rd@9382",
                    "Foto-de-perfil.png",
                    "Agrônoma há mais de 10 anos.",
                    TipoUsuario.FromString("Avaliador")
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O e-mail não pode começar com ponto (.).");
        }

        [Fact(DisplayName = "Criar usuário com hífen no início do e-mail")]
        public void CriarUsuario_ComHifenNoInícioDoEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var usuario = new Usuario(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    "-EduardaRb@outlook.com",
                    "Edu@rd@9382",
                    "Foto-de-perfil.png",
                    "Agrônoma há mais de 10 anos.",
                    TipoUsuario.FromString("Avaliador")
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O e-mail não pode começar com hífen (-).");
        }

        [Fact(DisplayName = "Criar usuário com underscore no início do e-mail")]
        public void CriarUsuario_ComUnderscoreNoInícioDoEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var usuario = new Usuario(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    "_EduardaRb@outlook.com",
                    "Edu@rd@9382",
                    "Foto-de-perfil.png",
                    "Agrônoma há mais de 10 anos.",
                    TipoUsuario.FromString("Avaliador")
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O e-mail não pode começar com underscore (_).");
        }

        [Fact(DisplayName = "Criar usuário com caractere especial no início do e-mail")]
        public void CriarUsuario_ComCaractereEspecialNoInícioDoEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var usuario = new Usuario(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    "!EduardaRb@outlook.com",
                    "Edu@rd@9382",
                    "Foto-de-perfil.png",
                    "Agrônoma há mais de 10 anos.",
                    TipoUsuario.FromString("Avaliador")
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O e-mail não pode começar com caractere especial.");
        }

        [Fact(DisplayName = "Criar usuário com pontos consecutivos no nome de usuário do e-mail")]
        public void CriarUsuario_ComPontosConsecutivosNoNomeDeUsuarioDoEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var usuario = new Usuario(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    "Eduarda..Rb@outlook.com",
                    "Edu@rd@9382",
                    "Foto-de-perfil.png",
                    "Agrônoma há mais de 10 anos.",
                    TipoUsuario.FromString("Avaliador")
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O nome de usuário do e-mail não pode conter pontos consecutivos (.., ..., .... e etc).");
        }

        [Fact(DisplayName = "Criar usuário com hífens consecutivos no nome de usuário do e-mail")]
        public void CriarUsuario_ComHifensConsecutivosNoNomeDeUsuarioDoEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var usuario = new Usuario(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    "Eduarda---Rb@outlook.com",
                    "Edu@rd@9382",
                    "Foto-de-perfil.png",
                    "Agrônoma há mais de 10 anos.",
                    TipoUsuario.FromString("Avaliador")
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O nome de usuário do e-mail não pode conter hífens consecutivos (--, ---, ---- e etc).");
        }

        [Fact(DisplayName = "Criar usuário com underscores consecutivos no nome de usuário do e-mail")]
        public void CriarUsuario_ComUnderscoresConsecutivosNoNomeDeUsuarioDoEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var usuario = new Usuario(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    "Eduarda____Rb@outlook.com",
                    "Edu@rd@9382",
                    "Foto-de-perfil.png",
                    "Agrônoma há mais de 10 anos.",
                    TipoUsuario.FromString("Avaliador")
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O nome de usuário do e-mail não pode conter underscores consecutivos (__, ___, ____ e etc).");
        }

        [Fact(DisplayName = "Criar usuário com ponto no final do nome de usuário do e-mail")]
        public void CriarUsuario_ComPontoNoFinalDoNomeDeUsuarioDoEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var usuario = new Usuario(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    "EduardaRb.@outlook.com",
                    "Edu@rd@9382",
                    "Foto-de-perfil.png",
                    "Agrônoma há mais de 10 anos.",
                    TipoUsuario.FromString("Avaliador")
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O nome de usuário do e-mail não pode terminar com ponto (.).");
        }

        [Fact(DisplayName = "Criar usuário com hífen no final do nome de usuário do e-mail")]
        public void CriarUsuario_ComHifenNoFinalDoNomeDeUsuarioDoEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var usuario = new Usuario(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    "EduardaRb-@outlook.com",
                    "Edu@rd@9382",
                    "Foto-de-perfil.png",
                    "Agrônoma há mais de 10 anos.",
                    TipoUsuario.FromString("Avaliador")
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O nome de usuário do e-mail não pode terminar com hífen (-).");
        }

        [Fact(DisplayName = "Criar usuário com underscore no final do nome de usuário do e-mail")]
        public void CriarUsuario_ComUnderscoreNoFinalDoNomeDeUsuarioDoEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var usuario = new Usuario(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    "EduardaRb_@outlook.com",
                    "Edu@rd@9382",
                    "Foto-de-perfil.png",
                    "Agrônoma há mais de 10 anos.",
                    TipoUsuario.FromString("Avaliador")
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O nome de usuário do e-mail não pode terminar com underscore (_).");
        }

        [Fact(DisplayName = "Criar usuário com caractere especial no final do nome de usuário do e-mail")]
        public void CriarUsuario_ComCaractereEspecialNoFinalDoNomeDeUsuarioDoEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var usuario = new Usuario(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    "EduardaRb$@outlook.com",
                    "Edu@rd@9382",
                    "Foto-de-perfil.png",
                    "Agrônoma há mais de 10 anos.",
                    TipoUsuario.FromString("Avaliador")
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O nome de usuário do e-mail não pode terminar com caractere especial.");
        }

        [Fact(DisplayName = "Criar usuário com caractere especial inválido no nome de usuário do e-mail")]
        public void CriarUsuario_ComCaractereEspecialInvalidoNoNomeDeUsuarioDoEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var usuario = new Usuario(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    "Eduarda,Rb@outlook.com",
                    "Edu@rd@9382",
                    "Foto-de-perfil.png",
                    "Agrônoma há mais de 10 anos.",
                    TipoUsuario.FromString("Avaliador")
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage($"O nome de usuário do e-mail não pode conter: {new string(ConstantesValidacao.CaracteresInvalidosEmailUsuario)}.");
        }

        #endregion

        #region Testes de Domínio do E-mail

        [Fact(DisplayName = "Criar usuário com domínio de e-mail nulo")]
        public void CriarUsuario_ComDominioDeEmailNulo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var usuario = new Usuario(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    $"EduardaRb@{null}",
                    "Edu@rd@9382",
                    "Foto-de-perfil.png",
                    "Agrônoma há mais de 10 anos.",
                    TipoUsuario.FromString("Avaliador")
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O domínio de e-mail é obrigatório.");
        }

        [Fact(DisplayName = "Criar usuário com domínio de e-mail vazio")]
        public void CriarUsuario_ComDominioDeEmailVazio_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var usuario = new Usuario(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    "EduardaRb@",
                    "Edu@rd@9382",
                    "Foto-de-perfil.png",
                    "Agrônoma há mais de 10 anos.",
                    TipoUsuario.FromString("Avaliador")
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O domínio de e-mail é obrigatório.");
        }

        [Fact(DisplayName = "Criar usuário com domínio de e-mail muito curto")]
        public void CriarUsuario_ComDominioDeEmailMuitoCurto_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var usuario = new Usuario(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    "EduardaRb@o.c",
                    "Edu@rd@9382",
                    "Foto-de-perfil.png",
                    "Agrônoma há mais de 10 anos.",
                    TipoUsuario.FromString("Avaliador")
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O domínio de e-mail deve ter no mínimo 4 caracteres.");
        }

        [Fact(DisplayName = "Criar usuário com domínio de e-mail muito longo")]
        public void CriarUsuario_ComDominioDeEmailMuitoLongo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var usuario = new Usuario(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    "E@please-try-to.send-me-an-email-if-you-can-possibly-begin-to-remember-this-coz.this-is-the-longest-email-address-known-to-man-but-to-be-honest.this-is-such-a-stupidly-long-sub-domain-it-could-go-on-forever.pacraig.com.construction.technology.association",
                    "Edu@rd@9382",
                    "Foto-de-perfil.png",
                    "Agrônoma há mais de 10 anos.",
                    TipoUsuario.FromString("Avaliador")
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O domínio de e-mail pode ter no máximo 251 caracteres.");
        }

        [Fact(DisplayName = "Criar usuário sem ponto no domínio de e-mail")]
        public void CriarUsuario_SemPontoNoDominioDeEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var usuario = new Usuario(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    "EduardaRb@outlook",
                    "Edu@rd@9382",
                    "Foto-de-perfil.png",
                    "Agrônoma há mais de 10 anos.",
                    TipoUsuario.FromString("Avaliador")
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O domínio de e-mail deve conter pelo menos um ponto (.), exemplo: \"dominio.com\".");
        }

        [Fact(DisplayName = "Criar usuário com ponto no início do domínio de e-mail")]
        public void CriarUsuario_ComPontoNoInícioDoDominioDeEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var usuario = new Usuario(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    "EduardaRb@.outlook.com",
                    "Edu@rd@9382",
                    "Foto-de-perfil.png",
                    "Agrônoma há mais de 10 anos.",
                    TipoUsuario.FromString("Avaliador")
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O domínio de e-mail não pode começar com ponto (.).");
        }

        [Fact(DisplayName = "Criar usuário com hífen no início do domínio de e-mail")]
        public void CriarUsuario_ComHifenNoInícioDoDominioDeEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var usuario = new Usuario(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    "EduardaRb@-outlook.com",
                    "Edu@rd@9382",
                    "Foto-de-perfil.png",
                    "Agrônoma há mais de 10 anos.",
                    TipoUsuario.FromString("Avaliador")
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O domínio de e-mail não pode começar com hífen (-).");
        }

        [Fact(DisplayName = "Criar usuário com pontos consecutivos no domínio de e-mail")]
        public void CriarUsuario_ComPontosConsecutivosNoDominioDeEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var usuario = new Usuario(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    "EduardaRb@outlook..com",
                    "Edu@rd@9382",
                    "Foto-de-perfil.png",
                    "Agrônoma há mais de 10 anos.",
                    TipoUsuario.FromString("Avaliador")
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O domínio de e-mail não pode conter pontos consecutivos (.., ..., .... e etc).");
        }

        [Fact(DisplayName = "Criar usuário com hífens consecutivos no domínio de e-mail")]
        public void CriarUsuario_ComHifensConsecutivosNoDominioDeEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var usuario = new Usuario(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    "EduardaRb@out--look.com",
                    "Edu@rd@9382",
                    "Foto-de-perfil.png",
                    "Agrônoma há mais de 10 anos.",
                    TipoUsuario.FromString("Avaliador")
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O domínio de e-mail não pode conter hífens consecutivos (--, ---, ---- e etc).");
        }

        [Fact(DisplayName = "Criar usuário com ponto no final do e-mail")]
        public void CriarUsuario_ComPontoNoFinalDoEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var usuario = new Usuario(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    "EduardaRb@outlook.com.",
                    "Edu@rd@9382",
                    "Foto-de-perfil.png",
                    "Agrônoma há mais de 10 anos.",
                    TipoUsuario.FromString("Avaliador")
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O e-mail não pode terminar com ponto (.).");
        }

        [Fact(DisplayName = "Criar usuário com hífen no final do e-mail")]
        public void CriarUsuario_ComHifenNoFinalDoEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var usuario = new Usuario(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    "EduardaRb@outlook.com-",
                    "Edu@rd@9382",
                    "Foto-de-perfil.png",
                    "Agrônoma há mais de 10 anos.",
                    TipoUsuario.FromString("Avaliador")
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O e-mail não pode terminar com hífen (-).");
        }

        [Fact(DisplayName = "Criar usuário com caractere especial inválido no domínio de e-mail")]
        public void CriarUsuario_ComCaractereEspecialInvalidoNoDominioDeEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var usuario = new Usuario(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    "EduardaRb@out*look.com",
                    "Edu@rd@9382",
                    "Foto-de-perfil.png",
                    "Agrônoma há mais de 10 anos.",
                    TipoUsuario.FromString("Avaliador")
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage($"O domínio de e-mail não pode conter: {new string(ConstantesValidacao.CaracteresInvalidosEmailDominio)}.");
        }

        [Fact(DisplayName = "Criar usuário com rótulo do domínio de e-mail muito longo")]
        public void CriarUsuario_ComRotuloDoDominioDeEmailMuitoLongo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var usuario = new Usuario(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    "E@send-me-an-email-if-you-can-possibly-begin-to-remember-this-bcoz.com",
                    "Edu@rd@9382",
                    "Foto-de-perfil.png",
                    "Agrônoma há mais de 10 anos.",
                    TipoUsuario.FromString("Avaliador")
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Os rótulos do domínio de e-mail podem ter no máximo 63 caracteres.");
        }

        [Fact(DisplayName = "Criar usuário com extensão de domínio (TLD) de e-mail muito curto")]
        public void CriarUsuario_ComExtensãoDeDominioDeEmailMuitoCurto_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var usuario = new Usuario(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    "EduardaRb@outlook.c",
                    "Edu@rd@9382",
                    "Foto-de-perfil.png",
                    "Agrônoma há mais de 10 anos.",
                    TipoUsuario.FromString("Avaliador")
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("As extensões de domínio (TLDs) devem ter no mínimo 2 caracteres.");
        }

        [Fact(DisplayName = "Criar usuário com número na extensão de domínio (TLD) de e-mail")]
        public void CriarUsuario_ComNumeroNaExtensãoDeDominioDeEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var usuario = new Usuario(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    "EduardaRb@outlook.c0m",
                    "Edu@rd@9382",
                    "Foto-de-perfil.png",
                    "Agrônoma há mais de 10 anos.",
                    TipoUsuario.FromString("Avaliador")
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("As extensões de domínio (TLDs) não podem conter números.");
        }

        #endregion

        #endregion

        #region Testes de Senha

        [Fact(DisplayName = "Criar usuário com senha nula")]
        public void CriarUsuario_ComSenhaNula_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var usuario = new Usuario(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    "EduardaRb@outlook.com",
                    null,
                    "Foto-de-perfil.png",
                    "Agrônoma há mais de 10 anos.",
                    TipoUsuario.FromString("Avaliador")
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("A senha é obrigatória.");
        }

        [Fact(DisplayName = "Criar usuário com senha vazia")]
        public void CriarUsuario_ComSenhaVazia_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var usuario = new Usuario(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    "EduardaRb@outlook.com",
                    "",
                    "Foto-de-perfil.png",
                    "Agrônoma há mais de 10 anos.",
                    TipoUsuario.FromString("Avaliador")
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("A senha é obrigatória.");
        }

        [Fact(DisplayName = "Criar usuário com senha muito curta")]
        public void CriarUsuario_ComSenhaMuitoCurta_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var usuario = new Usuario(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    "EduardaRb@outlook.com",
                    "Dud@9",
                    "Foto-de-perfil.png",
                    "Agrônoma há mais de 10 anos.",
                    TipoUsuario.FromString("Avaliador")
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("A senha deve ter no mínimo 8 caracteres.");
        }

        [Fact(DisplayName = "Criar usuário com senha muito longa")]
        public void CriarUsuario_ComSenhaMuitoLonga_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var usuario = new Usuario(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    "EduardaRb@outlook.com",
                    "Edu@rd@R!Be!R09382M1lh0rS3nh@Agr0n0m!@2025#Segur@nç@T0t@lD0M1n!065",
                    "Foto-de-perfil.png",
                    "Agrônoma há mais de 10 anos.",
                    TipoUsuario.FromString("Avaliador")
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("A senha pode ter no máximo 64 caracteres.");
        }

        [Fact(DisplayName = "Criar usuário com espaço na senha")]
        public void CriarUsuario_ComEspacoNaSenha_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var usuario = new Usuario(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    "EduardaRb@outlook.com",
                    "Edu@rd@ 9382",
                    "Foto-de-perfil.png",
                    "Agrônoma há mais de 10 anos.",
                    TipoUsuario.FromString("Avaliador")
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("A senha não pode conter espaços.");
        }

        [Fact(DisplayName = "Criar usuário sem letra maiúscula na senha")]
        public void CriarUsuario_SemLetraMaiusculaNaSenha_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var usuario = new Usuario(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    "EduardaRb@outlook.com",
                    "edu@rd@9382",
                    "Foto-de-perfil.png",
                    "Agrônoma há mais de 10 anos.",
                    TipoUsuario.FromString("Avaliador")
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("A senha deve conter pelo menos uma letra maiúscula.");
        }

        [Fact(DisplayName = "Criar usuário sem letra minúscula na senha")]
        public void CriarUsuario_SemLetraMinusculaNaSenha_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var usuario = new Usuario(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    "EduardaRb@outlook.com",
                    "EDU@RD@9382",
                    "Foto-de-perfil.png",
                    "Agrônoma há mais de 10 anos.",
                    TipoUsuario.FromString("Avaliador")
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("A senha deve conter pelo menos uma letra minúscula.");
        }

        [Fact(DisplayName = "Criar usuário sem número na senha")]
        public void CriarUsuario_SemNumeroNaSenha_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var usuario = new Usuario(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    "EduardaRb@outlook.com",
                    "Edu@rd@NoveTresOitoDois",
                    "Foto-de-perfil.png",
                    "Agrônoma há mais de 10 anos.",
                    TipoUsuario.FromString("Avaliador")
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("A senha deve conter pelo menos um número.");
        }

        [Fact(DisplayName = "Criar usuário sem caractere especial na senha")]
        public void CriarUsuario_SemCaractereEspecialNaSenha_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var usuario = new Usuario(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    "EduardaRb@outlook.com",
                    "Eduarda9382",
                    "Foto-de-perfil.png",
                    "Agrônoma há mais de 10 anos.",
                    TipoUsuario.FromString("Avaliador")
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage($"A senha deve conter pelo menos um caractere especial. Exemplo: {new string(ConstantesValidacao.CaracteresEspeciaisPermitidosSenha)}.");
        }

        #endregion

        #region Testes de Foto

        [Fact(DisplayName = "Criar usuário com URL de foto muito longa")]
        public void CriarUsuario_ComUrlDeFotoMuitoLonga_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var usuario = new Usuario(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    "EduardaRb@outlook.com",
                    "Edu@rd@9382",
                    "Foto-de-perfil-2024-ultra-hd-4k-agronomia-soja-milho-cafe-plantio-colheita-solo-adubacao-irrigacao-tratore-sagricultura-precision-farming-fertiliizantes-sustentabilidade-biomas-brasileiros-certificacao-iso-9001-14001-global-gap-ifarm-logo-marca-dagua-selos.png",
                    "Agrônoma há mais de 10 anos.",
                    TipoUsuario.FromString("Avaliador")
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("A URL da foto pode ter no máximo 250 caracteres.");
        }

        #endregion

        #region Testes de Biografia

        [Fact(DisplayName = "Criar usuário com biografia muito longa")]
        public void CriarUsuario_ComBiografiaMuitoLonga_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var usuario = new Usuario(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    "EduardaRb@outlook.com",
                    "Edu@rd@9382",
                    "Foto-de-perfil.png",
                    "Agrônoma há 12 anos, especialista em solos e agricultura digital. Mestra em Agronomia pela UFV, com MBA em Gestão Agroindustrial. Atuo no desenvolvimento de sistemas sustentáveis que unem tecnologia de precisão e práticas ancestrais. Apaixonada por café specialty, controle biológico e drones agrícolas. Criadora do projeto 'Adote um Hectare', que conecta produtores a investidores. Acredito que o futuro da agricultura está na ciência de dados sem perder o contato com a terra. Mãe de dois filhos, esposa de um produtor rural e viciada em fotografia de paisagens rurais. Minha missão: alimentar o mundo sem esgotar o planeta. Atualmente desenvolvendo um app para diagnóstico de pragas via IA.",
                    TipoUsuario.FromString("Avaliador")
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("A biografia pode ter no máximo 500 caracteres.");
        }

        #endregion

        #region Testes de Tipo de Usuário

        [Fact(DisplayName = "Criar usuário com tipo nulo")]
        public void CriarUsuario_ComTipoNulo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var usuario = new Usuario(
                    Guid.NewGuid(),
                    "Eduarda Ribeiro",
                    "EduardaRb@outlook.com",
                    "Edu@rd@9382",
                    "Foto-de-perfil.png",
                    "Agrônoma há mais de 10 anos.",
                    null
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O tipo de usuário é obrigatório.");
        }

        [Fact(DisplayName = "Criar usuário com tipo vazio")]
        public void CriarUsuario_ComTipoVazio_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => TipoUsuario.FromString("");
            action.Should()
                .Throw<ArgumentException>()
                .WithMessage($"Tipo de usuário inválido, use \"Empresa\", \"Avaliador\" ou \"Administrador\".*");
        }

        [Fact(DisplayName = "Criar usuário com tipo em branco")]
        public void CriarUsuario_ComTipoEmBranco_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => TipoUsuario.FromString("  ");
            action.Should()
                .Throw<ArgumentException>()
                .WithMessage($"Tipo de usuário inválido, use \"Empresa\", \"Avaliador\" ou \"Administrador\".*");
        }

        [Fact(DisplayName = "Criar usuário com tipo inválido")]
        public void CriarUsuario_ComTipoInvalido_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => TipoUsuario.FromString("Estagiário");
            action.Should()
                .Throw<ArgumentException>()
                .WithMessage($"Tipo de usuário inválido, use \"Empresa\", \"Avaliador\" ou \"Administrador\".*");
        }

        #endregion

        #endregion
    }
}