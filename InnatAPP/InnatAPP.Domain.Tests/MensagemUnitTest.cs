#region Importações

using Xunit;
using FluentAssertions;
using InnatAPP.Domain.Shared;
using InnatAPP.Domain.Entities;

#endregion

namespace InnatAPP.Domain.Tests
{
    public class MensagemUnitTest
    {
        #region Testes de parâmetros válidos

        [Fact(DisplayName = "Criar mensagem com estado válido")]
        public void CriarMensagem_ComParametrosValidos_ResultandoEmObjetoComEstadoValido()
        {
            Action action = () => new Mensagem(1, "Eduarda Ribeiro", "EduardaRb@outlook.com", "Adorei o site, mas gostaria que tivesse como favoritar produtos");
            action.Should()
                .NotThrow<InnatAPP.Domain.Validation.DomainExceptionValidation>();
        }

        #endregion

        #region Testes de Id

        [Fact(DisplayName = "Criar mensagem com id negativo")]
        public void CriarMensagem_ComIdNegativo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Mensagem(-1, "Eduarda Ribeiro", "EduardaRb@outlook.com", "Adorei o site, mas gostaria que tivesse como favoritar produtos");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Valor de id inválido.");
        }

        #endregion

        #region Testes de nome

        [Fact(DisplayName = "Criar mensagem com nome nulo")]
        public void CriarMensagem_ComNomeNulo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Mensagem(1, null, "EduardaRb@outlook.com", "Adorei o site, mas gostaria que tivesse como favoritar produtos");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Nome inválido, o nome é obrigatório.");
        }

        [Fact(DisplayName = "Criar mensagem com nome vazio")]
        public void CriarMensagem_ComNomeVazio_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Mensagem(1, "", "EduardaRb@outlook.com", "Adorei o site, mas gostaria que tivesse como favoritar produtos");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Nome inválido, o nome é obrigatório.");
        }

        [Fact(DisplayName = "Criar mensagem com nome muito curto")]
        public void CriarMensagem_ComNomeMuitoCurto_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Mensagem(1, "E", "EduardaRb@outlook.com", "Adorei o site, mas gostaria que tivesse como favoritar produtos");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Nome inválido, o nome deve ter no mínimo 2 caracteres.");
        }

        [Fact(DisplayName = "Criar mensagem com nome muito longo")]
        public void CriarMensagem_ComNomeMuitoLongo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Mensagem(1, "Maria Eduarda Dominique Pereira Dos Santos Oliveira De Castro Ribeiro Fernandes Lima Costa Martins Duarte", "EduardaRb@outlook.com", "Adorei o site, mas gostaria que tivesse como favoritar produtos");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Nome inválido, o nome pode ter no máximo 100 caracteres.");
        }

        #endregion

        #region Testes de e-mail

        [Fact(DisplayName = "Criar mensagem com email nulo")]
        public void CriarMensagem_ComEmailNulo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Mensagem(1, "Eduarda Ribeiro", null, "Adorei o site, mas gostaria que tivesse como favoritar produtos");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o e-mail é obrigatório.");
        }

        [Fact(DisplayName = "Criar mensagem com email vazio")]
        public void CriarMensagem_ComEmailVazio_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Mensagem(1, "Eduarda Ribeiro", "", "Adorei o site, mas gostaria que tivesse como favoritar produtos");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o e-mail é obrigatório.");
        }

        [Fact(DisplayName = "Criar mensagem com email muito curto")]
        public void CriarMensagem_ComEmailMuitoCurto_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Mensagem(1, "Eduarda Ribeiro", "E@o", "Adorei o site, mas gostaria que tivesse como favoritar produtos");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o e-mail deve ter no mínimo 5 caracteres.");
        }

        [Fact(DisplayName = "Criar mensagem com email muito longo")]
        public void CriarMensagem_ComEmailMuitoLongo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Mensagem(1, "Eduarda Ribeiro", "MariaEduardaDominiquePereiraDosSantosOliveiraDeCastroRibeiroFernandesLimaCostaMartinsDuarte-03-05-1980-Agrônoma_Plantio15_03Colheita30_65scHaMilho120scHaIrrigacao10mmDiaFertNPK5_20_20Armazem5000scFazendaBelaVistaBR163Km78ZonaRuralSinopMT2025@agricultura.gov.br", "Adorei o site, mas gostaria que tivesse como favoritar produtos");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o e-mail pode ter no máximo 255 caracteres.");
        }

        [Fact(DisplayName = "Criar mensagem sem @ no email")]
        public void CriarMensagem_SemArrobaNoEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Mensagem(1, "Eduarda Ribeiro", "EduardaRboutlook.com", "Adorei o site, mas gostaria que tivesse como favoritar produtos");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o e-mail deve conter um '@'.");
        }

        [Fact(DisplayName = "Criar mensagem com espaço no email")]
        public void CriarMensagem_ComEspacoNoEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Mensagem(1, "Eduarda Ribeiro", "Eduarda Rb@outlook.com", "Adorei o site, mas gostaria que tivesse como favoritar produtos");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o e-mail não pode conter espaços.");
        }

        [Fact(DisplayName = "Criar mensagem com mais de um arroba no email")]
        public void CriarMensagem_ComMaisDeUmArrobaNoEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Mensagem(1, "Eduarda Ribeiro", "Eduarda@Rb@outlook.com", "Adorei o site, mas gostaria que tivesse como favoritar produtos");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o e-mail pode ter apenas um '@'.");
        }

        [Fact(DisplayName = "Criar mensagem com usuário de email vazio")]
        public void CriarMensagem_ComUsuarioDeEmailVazio_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Mensagem(1, "Eduarda Ribeiro", "@outlook.com", "Adorei o site, mas gostaria que tivesse como favoritar produtos");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o nome de usuário é obrigatório.");
        }

        [Fact(DisplayName = "Criar mensagem com ponto no início do email")]
        public void CriarMensagem_ComPontoNoInicioDoEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Mensagem(1, "Eduarda Ribeiro", ".EduardaRb@outlook.com", "Adorei o site, mas gostaria que tivesse como favoritar produtos");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o email não pode começar com ponto (.).");
        }

        [Fact(DisplayName = "Criar mensagem com ponto no final do usuário de email")]
        public void CriarMensagem_ComPontoNoFinalDoUsuarioDeEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Mensagem(1, "Eduarda Ribeiro", "EduardaRb.@outlook.com", "Adorei o site, mas gostaria que tivesse como favoritar produtos");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o nome de usuário não pode terminar com ponto (.).");
        }

        [Fact(DisplayName = "Criar mensagem com caracteres inválidos no usuario de email")]
        public void CriarMensagem_ComCaracteresInvalidosNoUsuarioDeEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Mensagem(1, "Eduarda Ribeiro", "<EduardaRb>@outlook.com", "Adorei o site, mas gostaria que tivesse como favoritar produtos");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage($"E-mail inválido, o nome de usuário não pode conter: {ConstantesValidacao.caracteresInvalidosEmailUsuario}.");
        }

        [Fact(DisplayName = "Criar mensagem com domínio de email vazio")]
        public void CriarMensagem_ComDominioDeEmailVazio_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Mensagem(1, "Eduarda Ribeiro", "EduardaRb@", "Adorei o site, mas gostaria que tivesse como favoritar produtos");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o domínio é obrigatório.");
        }

        [Fact(DisplayName = "Criar mensagem sem ponto no domínio de email")]
        public void CriarMensagem_SemPontoNoDominioDeEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Mensagem(1, "Eduarda Ribeiro", "EduardaRb@outlook", "Adorei o site, mas gostaria que tivesse como favoritar produtos");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o domínio deve conter pelo menos um '.' (Exemplo: gmail.com).");
        }

        [Fact(DisplayName = "Criar mensagem com hifén no início do domínio de email")]
        public void CriarMensagem_ComHifenNoInicoDoDominioDeEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Mensagem(1, "Eduarda Ribeiro", "EduardaRb@-outlook.com", "Adorei o site, mas gostaria que tivesse como favoritar produtos");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o domínio não pode começar com hífen (-).");
        }

        [Fact(DisplayName = "Criar mensagem com hífen no final do email")]
        public void CriarMensagem_ComHifenNoFinalDoEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Mensagem(1, "Eduarda Ribeiro", "EduardaRb@outlook.com-", "Adorei o site, mas gostaria que tivesse como favoritar produtos");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o e-mail não pode terminar com hífen (-).");
        }

        [Fact(DisplayName = "Criar mensagem com caracteres inválidos no domínio de email")]
        public void CriarMensagem_ComCaracteresInvalidosNoDominioDeEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Mensagem(1, "Eduarda Ribeiro", "EduardaRb@outlook#.com", "Adorei o site, mas gostaria que tivesse como favoritar produtos");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage($"E-mail inválido, o domínio não pode conter: {ConstantesValidacao.caracteresInvalidosEmailDominio}.");
        }

        #endregion

        #region Testes de texto

        [Fact(DisplayName = "Criar mensagem com texto nulo")]
        public void CriarMensagem_ComTextoNulo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Mensagem(1, "Eduarda Ribeiro", "EduardaRb@outlook.com", null);
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Mensagem inválida, a mensagem é obrigatória.");
        }

        [Fact(DisplayName = "Criar mensagem com texto vazio")]
        public void CriarMensagem_ComTextoVazio_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Mensagem(1, "Eduarda Ribeiro", "EduardaRb@outlook.com", "");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Mensagem inválida, a mensagem é obrigatória.");
        }

        [Fact(DisplayName = "Criar mensagem com texto muito curto")]
        public void CriarMensagem_ComTextoMuitoCurto_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Mensagem(1, "Eduarda Ribeiro", "EduardaRb@outlook.com", "A");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Mensagem inválida, a mensagem deve ter no mínimo 2 caracteres.");
        }

        [Fact(DisplayName = "Criar mensagem com texto muito longo")]
        public void CriarMensagem_ComTextoMuitoLongo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Mensagem(1, "Eduarda Ribeiro", "EduardaRb@outlook.com", "Prezada equipe do Inova Agro Tech, sou Maria Eduarda, engenheira agrônoma de Sinop-MT, e venho utilizando a plataforma desde o ano passado. Gostaria de compartilhar algumas observações que poderiam melhorar ainda mais essa excelente iniciativa. Primeiramente, parabéns pelo design intuitivo e pelo sistema de reviews - tem sido fundamental para minhas decisões de compra na fazenda. Seria interessante adicionar filtros para reviews de profissionais verificados, como agrônomos com CREA, pois daria mais credibilidade às avaliações técnicas. Outra sugestão seria permitir o upload de manuais técnicos nos cadastros de produtos, o que ajudaria nós, produtores, a entender melhor as especificações. Por fim, o pódio de melhores avaliações é muito bom, mas talvez pudesse ter versões por categoria, como tratores e sistemas de irrigação separadamente. Agradeço pela atenção e parabenizo novamente toda a equipe pelo trabalho.");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Mensagem inválida, a mensagem pode ter no máximo 700 caracteres.");
        }

        #endregion
    }
}
