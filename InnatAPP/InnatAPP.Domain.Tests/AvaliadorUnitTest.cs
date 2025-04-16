#region Importações

using Xunit;
using FluentAssertions;
using InnatAPP.Domain.Shared;
using InnatAPP.Domain.Entities;

#endregion

namespace InnatAPP.Domain.Tests
{
    public class AvaliadorUnitTest
    {
        #region Testes de parâmetros válidos

        [Fact(DisplayName = "Criar avaliador com estado válido")]
        public void CriarAvaliador_ComParametrosValidos_ResultandoEmObjetoComEstadoValido()
        {
            Action action = () => new Avaliador(1, "Eduarda Ribeiro", "EduardaRb@outlook.com", "Edu@rd@9382", "Foto-de-perfil.png", "Agrônoma há mais de 10 anos.");
            action.Should()
                .NotThrow<InnatAPP.Domain.Validation.DomainExceptionValidation>();
        }

        #endregion

        #region Testes de Id

        [Fact(DisplayName = "Criar avaliador com id negativo")]
        public void CriarAvaliador_ComIdNegativo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Avaliador(-1, "Eduarda Ribeiro", "EduardaRb@outlook.com", "Edu@rd@9382", "Foto-de-perfil.png", "Agrônoma há mais de 10 anos.");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Valor de id inválido.");
        }

        #endregion

        #region Testes de nome

        [Fact(DisplayName = "Criar avaliador com nome nulo")]
        public void CriarAvaliador_ComNomeNulo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Avaliador(1, null, "EduardaRb@outlook.com", "Edu@rd@9382", "Foto-de-perfil.png", "Agrônoma há mais de 10 anos.");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Nome inválido, o nome é obrigatório.");
        }

        [Fact(DisplayName = "Criar avaliador com nome vazio")]
        public void CriarAvaliador_ComNomeVazio_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Avaliador(1, "", "EduardaRb@outlook.com", "Edu@rd@9382", "Foto-de-perfil.png", "Agrônoma há mais de 10 anos.");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Nome inválido, o nome é obrigatório.");
        }

        [Fact(DisplayName = "Criar avaliador com nome muito curto")]
        public void CriarAvaliador_ComNomeMuitoCurto_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Avaliador(1, "E", "EduardaRb@outlook.com", "Edu@rd@9382", "Foto-de-perfil.png", "Agrônoma há mais de 10 anos.");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Nome inválido, o nome deve ter no mínimo 2 caracteres.");
        }

        [Fact(DisplayName = "Criar avaliador com nome muito longo")]
        public void CriarAvaliador_ComNomeMuitoLongo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Avaliador(1, "Maria Eduarda Dominique Pereira Dos Santos Oliveira De Castro Ribeiro Fernandes Lima Costa Martins Duarte", "EduardaRb@outlook.com", "Edu@rd@9382", "Foto-de-perfil.png", "Agrônoma há mais de 10 anos.");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Nome inválido, o nome pode ter no máximo 100 caracteres.");
        }

        #endregion

        #region Testes de e-mail

        [Fact(DisplayName = "Criar avaliador com email nulo")]
        public void CriarAvaliador_ComEmailNulo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Avaliador(1, "Eduarda Ribeiro", null, "Edu@rd@9382", "Foto-de-perfil.png", "Agrônoma há mais de 10 anos.");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o e-mail é obrigatório.");
        }

        [Fact(DisplayName = "Criar avaliador com email vazio")]
        public void CriarAvaliador_ComEmailVazio_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Avaliador(1, "Eduarda Ribeiro", "", "Edu@rd@9382", "Foto-de-perfil.png", "Agrônoma há mais de 10 anos.");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o e-mail é obrigatório.");
        }

        [Fact(DisplayName = "Criar avaliador com email muito curto")]
        public void CriarAvaliador_ComEmailMuitoCurto_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Avaliador(1, "Eduarda Ribeiro", "E@o", "Edu@rd@9382", "Foto-de-perfil.png", "Agrônoma há mais de 10 anos.");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o e-mail deve ter no mínimo 5 caracteres.");
        }

        [Fact(DisplayName = "Criar avaliador com email muito longo")]
        public void CriarAvaliador_ComEmailMuitoLongo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Avaliador(1, "Eduarda Ribeiro", "MariaEduardaDominiquePereiraDosSantosOliveiraDeCastroRibeiroFernandesLimaCostaMartinsDuarte-03-05-1980-Agrônoma_Plantio15_03Colheita30_65scHaMilho120scHaIrrigacao10mmDiaFertNPK5_20_20Armazem5000scFazendaBelaVistaBR163Km78ZonaRuralSinopMT2025@agricultura.gov.br", "Edu@rd@9382", "Foto-de-perfil.png", "Agrônoma há mais de 10 anos.");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o e-mail pode ter no máximo 255 caracteres.");
        }

        [Fact(DisplayName = "Criar avaliador sem @ no email")]
        public void CriarAvaliador_SemArrobaNoEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Avaliador(1, "Eduarda Ribeiro", "EduardaRboutlook.com", "Edu@rd@9382", "Foto-de-perfil.png", "Agrônoma há mais de 10 anos.");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o e-mail deve conter um '@'.");
        }

        [Fact(DisplayName = "Criar avaliador com espaço no email")]
        public void CriarAvaliador_ComEspacoNoEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Avaliador(1, "Eduarda Ribeiro", "Eduarda Rb@outlook.com", "Edu@rd@9382", "Foto-de-perfil.png", "Agrônoma há mais de 10 anos.");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o e-mail não pode conter espaços.");
        }

        [Fact(DisplayName = "Criar avaliador com mais de um arroba no email")]
        public void CriarAvaliador_ComMaisDeUmArrobaNoEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Avaliador(1, "Eduarda Ribeiro", "Eduarda@Rb@outlook.com", "Edu@rd@9382", "Foto-de-perfil.png", "Agrônoma há mais de 10 anos.");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o e-mail pode ter apenas um '@'.");
        }

        [Fact(DisplayName = "Criar avaliador com usuário de email vazio")]
        public void CriarAvaliador_ComUsuarioDeEmailVazio_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Avaliador(1, "Eduarda Ribeiro", "@outlook.com", "Edu@rd@9382", "Foto-de-perfil.png", "Agrônoma há mais de 10 anos.");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o nome de usuário é obrigatório.");
        }

        [Fact(DisplayName = "Criar avaliador com ponto no início do email")]
        public void CriarAvaliador_ComPontoNoInicioDoEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Avaliador(1, "Eduarda Ribeiro", ".EduardaRb@outlook.com", "Edu@rd@9382", "Foto-de-perfil.png", "Agrônoma há mais de 10 anos.");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o email não pode começar com ponto (.).");
        }

        [Fact(DisplayName = "Criar avaliador com ponto no final do usuário de email")]
        public void CriarAvaliador_ComPontoNoFinalDoUsuarioDeEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Avaliador(1, "Eduarda Ribeiro", "EduardaRb.@outlook.com", "Edu@rd@9382", "Foto-de-perfil.png", "Agrônoma há mais de 10 anos.");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o nome de usuário não pode terminar com ponto (.).");
        }

        [Fact(DisplayName = "Criar avaliador com caracteres inválidos no usuario de email")]
        public void CriarAvaliador_ComCaracteresInvalidosNoUsuarioDeEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Avaliador(1, "Eduarda Ribeiro", "<EduardaRb>@outlook.com", "Edu@rd@9382", "Foto-de-perfil.png", "Agrônoma há mais de 10 anos.");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage($"E-mail inválido, o nome de usuário não pode conter: {ConstantesValidacao.caracteresInvalidosEmailUsuario}.");
        }

        [Fact(DisplayName = "Criar avaliador com domínio de email vazio")]
        public void CriarAvaliador_ComDominioDeEmailVazio_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Avaliador(1, "Eduarda Ribeiro", "EduardaRb@", "Edu@rd@9382", "Foto-de-perfil.png", "Agrônoma há mais de 10 anos.");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o domínio é obrigatório.");
        }

        [Fact(DisplayName = "Criar avaliador sem ponto no domínio de email")]
        public void CriarAvaliador_SemPontoNoDominioDeEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Avaliador(1, "Eduarda Ribeiro", "EduardaRb@outlook", "Edu@rd@9382", "Foto-de-perfil.png", "Agrônoma há mais de 10 anos.");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o domínio deve conter pelo menos um '.' (Exemplo: gmail.com).");
        }

        [Fact(DisplayName = "Criar avaliador com hifén no início do domínio de email")]
        public void CriarAvaliador_ComHifenNoInicoDoDominioDeEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Avaliador(1, "Eduarda Ribeiro", "EduardaRb@-outlook.com", "Edu@rd@9382", "Foto-de-perfil.png", "Agrônoma há mais de 10 anos.");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o domínio não pode começar com hífen (-).");
        }

        [Fact(DisplayName = "Criar avaliador com hífen no final do email")]
        public void CriarAvaliador_ComHifenNoFinalDoEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Avaliador(1, "Eduarda Ribeiro", "EduardaRb@outlook.com-", "Edu@rd@9382", "Foto-de-perfil.png", "Agrônoma há mais de 10 anos.");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o e-mail não pode terminar com hífen (-).");
        }

        [Fact(DisplayName = "Criar avaliador com caracteres inválidos no domínio de email")]
        public void CriarAvaliador_ComCaracteresInvalidosNoDominioDeEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Avaliador(1, "Eduarda Ribeiro", "EduardaRb@outlook#.com", "Edu@rd@9382", "Foto-de-perfil.png", "Agrônoma há mais de 10 anos.");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage($"E-mail inválido, o domínio não pode conter: {ConstantesValidacao.caracteresInvalidosEmailDominio}.");
        }

        #endregion

        #region Testes de senha

        [Fact(DisplayName = "Criar avaliador com senha nula")]
        public void CriarAvaliador_ComSenhaNula_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Avaliador(1, "Eduarda Ribeiro", "EduardaRb@outlook.com", null, "Foto-de-perfil.png", "Agrônoma há mais de 10 anos.");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Senha inválida, a senha é obrigatória.");
        }

        [Fact(DisplayName = "Criar avaliador com senha vazia")]
        public void CriarAvaliador_ComSenhaVazia_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Avaliador(1, "Eduarda Ribeiro", "EduardaRb@outlook.com", "", "Foto-de-perfil.png", "Agrônoma há mais de 10 anos.");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Senha inválida, a senha é obrigatória.");
        }

        [Fact(DisplayName = "Criar avaliador com senha muito curta")]
        public void CriarAvaliador_ComSenhaMuitoCurta_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Avaliador(1, "Eduarda Ribeiro", "EduardaRb@outlook.com", "Dud@93", "Foto-de-perfil.png", "Agrônoma há mais de 10 anos.");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Senha inválida, a senha deve ter no mínimo 8 caracteres.");
        }

        [Fact(DisplayName = "Criar avaliador com senha muito longa")]
        public void CriarAvaliador_ComSenhaMuitoLonga_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Avaliador(1, "Eduarda Ribeiro", "EduardaRb@outlook.com", "Edu@rd@R!Be!R09382M1lh0rS3nh@Agr0n0m!@2025#Segur@nç@T0t@lD0M1n!065", "Foto-de-perfil.png", "Agrônoma há mais de 10 anos.");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Senha inválida, a senha pode ter no máximo 64 caracteres.");
        }

        [Fact(DisplayName = "Criar avaliador com espaço na senha")]
        public void CriarAvaliador_ComEspacoNaSenha_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Avaliador(1, "Eduarda Ribeiro", "EduardaRb@outlook.com", "Edu@rd@ 9382", "Foto-de-perfil.png", "Agrônoma há mais de 10 anos.");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Senha inválida, a senha não pode conter espaços.");
        }

        [Fact(DisplayName = "Criar avaliador sem letra maiúscula na senha")]
        public void CriarAvaliador_SemLetraMaiusculaNaSenha_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Avaliador(1, "Eduarda Ribeiro", "EduardaRb@outlook.com", "edu@rd@9382", "Foto-de-perfil.png", "Agrônoma há mais de 10 anos.");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Senha inválida, a senha deve conter pelo menos uma letra maiúscula.");
        }

        [Fact(DisplayName = "Criar avaliador sem letra minúscula na senha")]
        public void CriarAvaliador_SemLetraMinusculaNaSenha_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Avaliador(1, "Eduarda Ribeiro", "EduardaRb@outlook.com", "EDU@RD@9382", "Foto-de-perfil.png", "Agrônoma há mais de 10 anos.");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Senha inválida, a senha deve conter pelo menos uma letra minúscula.");
        }

        [Fact(DisplayName = "Criar avaliador sem número na senha")]
        public void CriarAvaliador_SemNumeroNaSenha_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Avaliador(1, "Eduarda Ribeiro", "EduardaRb@outlook.com", "Edu@rd@Rb", "Foto-de-perfil.png", "Agrônoma há mais de 10 anos.");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Senha inválida, a senha deve conter pelo menos um número.");
        }

        [Fact(DisplayName = "Criar avaliador sem caracteres especiais na senha")]
        public void CriarAvaliador_SemCaracteresEspeciaisNaSenha_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Avaliador(1, "Eduarda Ribeiro", "EduardaRb@outlook.com", "Eduarda9382", "Foto-de-perfil.png", "Agrônoma há mais de 10 anos.");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage($"Senha inválida, a senha deve conter pelo menos um caractere especial. Exemplo: {ConstantesValidacao.caracteresEspeciaisPermitidosSenha}.");
        }

        #endregion

        #region Testes de imagem

        [Fact(DisplayName = "Criar avaliador com URL de foto muito longa")]
        public void CriarAvaliador_ComURLMuitoLonga_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Avaliador(1, "Eduarda Ribeiro", "EduardaRb@outlook.com", "Edu@rd@9382", "Foto-de-perfil-2024-ultra-hd-4k-agronomia-soja-milho-cafe-plantio-colheita-solo-adubacao-irrigacao-tratore-sagricultura-precision-farming-fertiliizantes-sustentabilidade-biomas-brasileiros-certificacao-iso-9001-14001-global-gap-ifarm-logo-marca-dagua-selos.png", "Agrônoma há mais de 10 anos.");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("URL da imagem inválida, a URL pode ter no máximo 250 caracteres.");
        }

        #endregion

        #region Testes de biografia

        [Fact(DisplayName = "Criar avaliador com bio muito longa")]
        public void CriarAvaliador_ComBioMuitoLonga_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Avaliador(1, "Eduarda Ribeiro", "EduardaRb@outlook.com", "Edu@rd@9382", "Foto-de-perfil.png", "Agrônoma há 12 anos, especialista em solos e agricultura digital. Mestra em Agronomia pela UFV, com MBA em Gestão Agroindustrial. Atuo no desenvolvimento de sistemas sustentáveis que unem tecnologia de precisão e práticas ancestrais. Apaixonada por café specialty, controle biológico e drones agrícolas. Criadora do projeto 'Adote um Hectare', que conecta produtores a investidores. Acredito que o futuro da agricultura está na ciência de dados sem perder o contato com a terra. Mãe de dois filhos, esposa de um produtor rural e viciada em fotografia de paisagens rurais. Minha missão: alimentar o mundo sem esgotar o planeta. Atualmente desenvolvendo um app para diagnóstico de pragas via IA.");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Biografia inválida, a biografia pode ter no máximo 500 caracteres.");
        }

        #endregion
    }
}
