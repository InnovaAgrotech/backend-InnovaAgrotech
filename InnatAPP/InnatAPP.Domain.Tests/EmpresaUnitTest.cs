#region Importações

using Xunit;
using FluentAssertions;
using InnatAPP.Domain.Shared;
using InnatAPP.Domain.Entities;

#endregion

namespace InnatAPP.Domain.Tests
{
    public class EmpresaUnitTest
    {
        #region Testes de parâmetros válidos

        [Fact(DisplayName = "Criar empresa com estado válido")]
        public void CriarEmpresa_ComParametrosValidos_ResultandoEmObjetoComEstadoValido()
        {
            Action action = () => new Empresa(1, "Empresa x", "Empresa.x@gmail.com", "Empresax1978!", "EmpresaX.png", "Nossa empresa vende tratores");
            action.Should()
                .NotThrow<InnatAPP.Domain.Validation.DomainExceptionValidation>();
        }

        #endregion

        #region Testes de Id

        [Fact(DisplayName = "Criar empresa com id negativo")]
        public void CriarEmpresa_ComIdNegativo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Empresa(-1, "Empresa x", "Empresa.x@gmail.com", "Empresax1978!", "EmpresaX.png", "Nossa empresa vende tratores");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Valor de id inválido.");
        }

        #endregion

        #region Testes de nome

        [Fact(DisplayName = "Criar empresa com nome nulo")]
        public void CriarEmpresa_ComNomeNulo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Empresa(1, null, "Empresa.x@gmail.com", "Empresax1978!", "EmpresaX.png", "Nossa empresa vende tratores");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Nome inválido, o nome é obrigatório.");
        }

        [Fact(DisplayName = "Criar empresa com nome vazio")]
        public void CriarEmpresa_ComNomeVazio_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Empresa(1, "", "Empresa.x@gmail.com", "Empresax1978!", "EmpresaX.png", "Nossa empresa vende tratores");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Nome inválido, o nome é obrigatório.");
        }

        [Fact(DisplayName = "Criar empresa com nome muito curto")]
        public void CriarEmpresa_ComNomeMuitoCurto_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Empresa(1, "X", "Empresa.x@gmail.com", "Empresax1978!", "EmpresaX.png", "Nossa empresa vende tratores");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Nome inválido, o nome deve ter no mínimo 2 caracteres.");
        }

        [Fact(DisplayName = "Criar empresa com nome muito longo")]
        public void CriarEmpresa_ComNomeMuitoLongo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Empresa(1, "Morbi leo mi, nonummy eget, tristique non, rhoncus non, leo. Nullam faucibus mi quis velit. Integer in", "Empresa.x@gmail.com", "Empresax1978!", "EmpresaX.png", "Nossa empresa vende tratores");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Nome inválido, o nome pode ter no máximo 100 caracteres.");
        }

        #endregion

        #region Testes de e-mail

        [Fact(DisplayName = "Criar empresa com email nulo")]
        public void CriarEmpresa_ComEmailNulo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Empresa(1, "Empresa x", null, "Empresax1978!", "EmpresaX.png", "Nossa empresa vende tratores");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o e-mail é obrigatório.");
        }

        [Fact(DisplayName = "Criar empresa com email vazio")]
        public void CriarEmpresa_ComEmailVazio_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Empresa(1, "Empresa x", "", "Empresax1978!", "EmpresaX.png", "Nossa empresa vende tratores");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o e-mail é obrigatório.");
        }

        [Fact(DisplayName = "Criar empresa com email muito curto")]
        public void CriarEmpresa_ComEmailMuitoCurto_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Empresa(1, "Empresa x", "x@gm", "Empresax1978!", "EmpresaX.png", "Nossa empresa vende tratores");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o e-mail deve ter no mínimo 5 caracteres.");
        }

        [Fact(DisplayName = "Criar empresa com email muito longo")]
        public void CriarEmpresa_ComEmailMuitoLongo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Empresa(1, "Empresa x", "In sem justo, commodo ut, suscipit at, pharetra vitae, orci. Duis sapien nunc, commodo et, interdum suscipit, sollicitudin et, dolor. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Aliquam id dolor. Class aptent", "Empresax1978!", "EmpresaX.png", "Nossa empresa vende tratores");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o e-mail pode ter no máximo 255 caracteres.");
        }

        [Fact(DisplayName = "Criar empresa sem @ no email")]
        public void CriarEmpresa_SemArrobaNoEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Empresa(1, "Empresa x", "Empresaxgmail.com", "Empresax1978!", "EmpresaX.png", "Nossa empresa vende tratores");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o e-mail deve conter um '@'.");
        }

        [Fact(DisplayName = "Criar empresa com espaço no email")]
        public void CriarEmpresa_ComEspacoNoEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Empresa(1, "Empresa x", "Empresa x @ gmail.com", "Empresax1978!", "EmpresaX.png", "Nossa empresa vende tratores");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o e-mail não pode conter espaços.");
        }

        [Fact(DisplayName = "Criar empresa com mais de um arroba no email")]
        public void CriarEmpresa_ComMaisDeUmArrobaNoEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Empresa(1, "Empresa x", "Empresa@x@gmail.com", "Empresax1978!", "EmpresaX.png", "Nossa empresa vende tratores");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o e-mail pode ter apenas um '@'.");
        }

        [Fact(DisplayName = "Criar empresa com usuário de email vazio")]
        public void CriarEmpresa_ComUsuarioDeEmailVazio_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Empresa(1, "Empresa x", "@gmail.com", "Empresax1978!", "EmpresaX.png", "Nossa empresa vende tratores");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o nome de usuário é obrigatório.");
        }

        [Fact(DisplayName = "Criar empresa com ponto no início do email")]
        public void CriarEmpresa_ComPontoNoInicioDoEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Empresa(1, "Empresa x", ".Empresa.x@gmail.com", "Empresax1978!", "EmpresaX.png", "Nossa empresa vende tratores");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o email não pode começar com ponto (.).");
        }

        [Fact(DisplayName = "Criar empresa com ponto no final do usuário de email")]
        public void CriarEmpresa_ComPontoNoFinalDoUsuarioDeEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Empresa(1, "Empresa x", "Empresa.x.@gmail.com", "Empresax1978!", "EmpresaX.png", "Nossa empresa vende tratores");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o nome de usuário não pode terminar com ponto (.).");
        }

        [Fact(DisplayName = "Criar empresa com caracteres inválidos no usuario de email")]
        public void CriarEmpresa_ComCaracteresInvalidosNoUsuarioDeEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Empresa(1, "Empresa x", "Empresa(x)@gmail.com", "Empresax1978!", "EmpresaX.png", "Nossa empresa vende tratores");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage($"E-mail inválido, o nome de usuário não pode conter: {ConstantesValidacao.caracteresInvalidosEmailUsuario}.");
        }

        [Fact(DisplayName = "Criar empresa com domínio de email vazio")]
        public void CriarEmpresa_ComDominioDeEmailVazio_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Empresa(1, "Empresa x", "Empresa.x@", "Empresax1978!", "EmpresaX.png", "Nossa empresa vende tratores");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o domínio é obrigatório.");
        }

        [Fact(DisplayName = "Criar empresa sem ponto no domínio de email")]
        public void CriarEmpresa_SemPontoNoDominioDeEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Empresa(1, "Empresa x", "Empresa.x@gmail", "Empresax1978!", "EmpresaX.png", "Nossa empresa vende tratores");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o domínio deve conter pelo menos um '.' (Exemplo: gmail.com).");
        }

        [Fact(DisplayName = "Criar empresa com hifén no início do domínio de email")]
        public void CriarEmpresa_ComHifenNoInicoDoDominioDeEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Empresa(1, "Empresa x", "Empresa.x@-gmail.com", "Empresax1978!", "EmpresaX.png", "Nossa empresa vende tratores");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o domínio não pode começar com hífen (-).");
        }

        [Fact(DisplayName = "Criar empresa com hífen no final do email")]
        public void CriarEmpresa_ComHifenNoFinalDoEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Empresa(1, "Empresa x", "Empresa.x@gmail.com-", "Empresax1978!", "EmpresaX.png", "Nossa empresa vende tratores");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o e-mail não pode terminar com hífen (-).");
        }

        [Fact(DisplayName = "Criar empresa com caracteres inválidos no domínio de email")]
        public void CriarEmpresa_ComCaracteresInvalidosNoDominioDeEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Empresa(1, "Empresa x", "Empresa.x@gmail*.com", "Empresax1978!", "EmpresaX.png", "Nossa empresa vende tratores");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage($"E-mail inválido, o domínio não pode conter: {ConstantesValidacao.caracteresInvalidosEmailDominio}.");
        }

        #endregion

        #region Testes de senha

        [Fact(DisplayName = "Criar empresa com senha nula")]
        public void CriarEmpresa_ComSenhaNula_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Empresa(1, "Empresa x", "Empresa.x@gmail.com", null, "EmpresaX.png", "Nossa empresa vende tratores");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Senha inválida, a senha é obrigatória.");
        }

        [Fact(DisplayName = "Criar empresa com senha vazia")]
        public void CriarEmpresa_ComSenhaVazia_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Empresa(1, "Empresa x", "Empresa.x@gmail.com", "", "EmpresaX.png", "Nossa empresa vende tratores");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Senha inválida, a senha é obrigatória.");
        }

        [Fact(DisplayName = "Criar empresa com senha muito curta")]
        public void CriarEmpresa_ComSenhaMuitoCurta_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Empresa(1, "Empresa x", "Empresa.x@gmail.com", "Emprx3!", "EmpresaX.png", "Nossa empresa vende tratores");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Senha inválida, a senha deve ter no mínimo 8 caracteres.");
        }

        [Fact(DisplayName = "Criar empresa com senha muito longa")]
        public void CriarEmpresa_ComSenhaMuitoLonga_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Empresa(1, "Empresa x", "Empresa.x@gmail.com", "EmpresaxJ7kP9qR2sL5vX8wT3zY6bN4cM1dF0gHAeB9rY2pX8zL3wK5tQ7mN4vC6fD1hG2jR0t17081978!", "EmpresaX.png", "Nossa empresa vende tratores");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Senha inválida, a senha pode ter no máximo 64 caracteres.");
        }

        [Fact(DisplayName = "Criar empresa com espaço na senha")]
        public void CriarEmpresa_ComEspacoNaSenha_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Empresa(1, "Empresa x", "Empresa.x@gmail.com", "empresa x 1978 !", "EmpresaX.png", "Nossa empresa vende tratores");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Senha inválida, a senha não pode conter espaços.");
        }

        [Fact(DisplayName = "Criar empresa sem letra maiúscula na senha")]
        public void CriarEmpresa_SemLetraMaiusculaNaSenha_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Empresa(1, "Empresa x", "Empresa.x@gmail.com", "empresax1978!", "EmpresaX.png", "Nossa empresa vende tratores");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Senha inválida, a senha deve conter pelo menos uma letra maiúscula.");
        }

        [Fact(DisplayName = "Criar empresa sem letra minúscula na senha")]
        public void CriarEmpresa_SemLetraMinusculaNaSenha_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Empresa(1, "Empresa x", "Empresa.x@gmail.com", "EMPRESAX1978!", "EmpresaX.png", "Nossa empresa vende tratores");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Senha inválida, a senha deve conter pelo menos uma letra minúscula.");
        }

        [Fact(DisplayName = "Criar empresa sem número na senha")]
        public void CriarEmpresa_SemNumeroNaSenha_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Empresa(1, "Empresa x", "Empresa.x@gmail.com", "Empresax!", "EmpresaX.png", "Nossa empresa vende tratores");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Senha inválida, a senha deve conter pelo menos um número.");
        }

        [Fact(DisplayName = "Criar empresa sem caracteres especiais na senha")]
        public void CriarEmpresa_SemCaracteresEspeciaisNaSenha_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Empresa(1, "Empresa x", "Empresa.x@gmail.com", "Empresax1978", "EmpresaX.png", "Nossa empresa vende tratores");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage($"Senha inválida, a senha deve conter pelo menos um caractere especial. Exemplo: {ConstantesValidacao.caracteresEspeciaisPermitidosSenha}.");
        }

        #endregion

        #region Testes de imagem

        [Fact(DisplayName = "Criar empresa com URL de foto muito longa")]
        public void CriarEmpresa_ComURLMuitoLonga_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Empresa(1, "Empresa x", "Empresa.x@gmail.com", "Empresax123!", "Praesent in mauris eu tortor porttitor accumsan. Mauris suscipit, ligula sit amet pharetra semper, nibh ante cursus purus, vel sagittis velit mauris vel metus. Aenean fermentum risus id tortor. Integer imperdiet lectus quis justo. Integer tempor. Vivamus ac", "Nossa empresa vende tratores");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("URL da imagem inválida, a URL pode ter no máximo 250 caracteres.");
        }

        #endregion

        #region Testes de biografia

        [Fact(DisplayName = "Criar empresa com bio muito longa")]
        public void CriarEmpresa_ComBioMuitoLonga_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Empresa(1, "Empresa x", "Empresa.x@gmail.com", "Empresax123!", "EmpresaX.png", "Etiam posuere quam ac quam. Maecenas aliquet accumsan leo. Nullam dapibus fermentum ipsum. Etiam quis quam. Integer lacinia. Nulla est. Nulla turpis magna, cursus sit amet, suscipit a, interdum id, felis. Integer vulputate sem a nibh rutrum consequat. Maecenas lorem. Pellentesque pretium lectus id turpis. Etiam sapien elit, consequat eget, tristique non, venenatis quis, ante. Fusce wisi. Phasellus faucibus molestie nisl. Fusce eget urna. Curabitur vitae diam non enim vestibulum interdum. Nulla quis");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Biografia inválida, a biografia pode ter no máximo 500 caracteres.");
        }

        #endregion
    }
}
