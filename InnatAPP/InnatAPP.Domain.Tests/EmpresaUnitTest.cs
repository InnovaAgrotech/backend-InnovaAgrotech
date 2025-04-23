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
            Action action = () => new Empresa(1, "AgroMecânica Brasil Ltda", "vendas@agromecanicabrasil.com.br", "Tr@t0res2024!", "agromecanica-brasil.jpg", "Fabricante líder de maquinário agrícola desde 1987.");
            action.Should()
                .NotThrow<InnatAPP.Domain.Validation.DomainExceptionValidation>();
        }

        #endregion

        #region Testes de Id

        [Fact(DisplayName = "Criar empresa com id negativo")]
        public void CriarEmpresa_ComIdNegativo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Empresa(-1, "AgroMecânica Brasil Ltda", "vendas@agromecanicabrasil.com.br", "Tr@t0res2024!", "agromecanica-brasil.jpg", "Fabricante líder de maquinário agrícola desde 1987.");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Valor de id inválido.");
        }

        #endregion

        #region Testes de nome

        [Fact(DisplayName = "Criar empresa com nome nulo")]
        public void CriarEmpresa_ComNomeNulo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Empresa(1, null, "vendas@agromecanicabrasil.com.br", "Tr@t0res2024!", "agromecanica-brasil.jpg", "Fabricante líder de maquinário agrícola desde 1987.");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Nome inválido, o nome é obrigatório.");
        }

        [Fact(DisplayName = "Criar empresa com nome vazio")]
        public void CriarEmpresa_ComNomeVazio_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Empresa(1, "", "vendas@agromecanicabrasil.com.br", "Tr@t0res2024!", "agromecanica-brasil.jpg", "Fabricante líder de maquinário agrícola desde 1987.");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Nome inválido, o nome é obrigatório.");
        }

        [Fact(DisplayName = "Criar empresa com nome muito curto")]
        public void CriarEmpresa_ComNomeMuitoCurto_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Empresa(1, "A", "vendas@agromecanicabrasil.com.br", "Tr@t0res2024!", "agromecanica-brasil.jpg", "Fabricante líder de maquinário agrícola desde 1987.");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Nome inválido, o nome deve ter no mínimo 2 caracteres.");
        }

        [Fact(DisplayName = "Criar empresa com nome muito longo")]
        public void CriarEmpresa_ComNomeMuitoLongo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Empresa(1, "AgroMecânica Brasil Industrial Ltda. - Fabricante de Maquinários Agrícolas de Alta Performance desde 1987", "vendas@agromecanicabrasil.com.br", "Tr@t0res2024!", "agromecanica-brasil.jpg", "Fabricante líder de maquinário agrícola desde 1987.");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Nome inválido, o nome pode ter no máximo 100 caracteres.");
        }

        #endregion

        #region Testes de e-mail

        [Fact(DisplayName = "Criar empresa com email nulo")]
        public void CriarEmpresa_ComEmailNulo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Empresa(1, "AgroMecânica Brasil Ltda", null, "Tr@t0res2024!", "agromecanica-brasil.jpg", "Fabricante líder de maquinário agrícola desde 1987.");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o e-mail é obrigatório.");
        }

        [Fact(DisplayName = "Criar empresa com email vazio")]
        public void CriarEmpresa_ComEmailVazio_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Empresa(1, "AgroMecânica Brasil Ltda", "", "Tr@t0res2024!", "agromecanica-brasil.jpg", "Fabricante líder de maquinário agrícola desde 1987.");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o e-mail é obrigatório.");
        }

        [Fact(DisplayName = "Criar empresa com email muito curto")]
        public void CriarEmpresa_ComEmailMuitoCurto_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Empresa(1, "AgroMecânica Brasil Ltda", "v@a", "Tr@t0res2024!", "agromecanica-brasil.jpg", "Fabricante líder de maquinário agrícola desde 1987.");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o e-mail deve ter no mínimo 5 caracteres.");
        }

        [Fact(DisplayName = "Criar empresa com email muito longo")]
        public void CriarEmpresa_ComEmailMuitoLongo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Empresa(1, "AgroMecânica Brasil Ltda", "Agro_Mecanica_Brasil_Industria_Ltda_2025_Fabricacao&Vendas_Maquinas_Agriculas_1987_12.345.678/0001-99_Industrialização&Comercialização_AgroNegocio_Tratores_Colheitadeiras_Pulverizadores_Drones_BR-060_Km78_ZonaUrbana_NovoHorizonteSP@maquinariosagricolas.gov.br", "Tr@t0res2024!", "agromecanica-brasil.jpg", "Fabricante líder de maquinário agrícola desde 1987.");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o e-mail pode ter no máximo 255 caracteres.");
        }

        [Fact(DisplayName = "Criar empresa sem @ no email")]
        public void CriarEmpresa_SemArrobaNoEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Empresa(1, "AgroMecânica Brasil Ltda", "vendasagromecanicabrasil.com.br", "Tr@t0res2024!", "agromecanica-brasil.jpg", "Fabricante líder de maquinário agrícola desde 1987.");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o e-mail deve conter um '@'.");
        }

        [Fact(DisplayName = "Criar empresa com espaço no email")]
        public void CriarEmpresa_ComEspacoNoEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Empresa(1, "AgroMecânica Brasil Ltda", "vendas@agro mecanica brasil.com.br", "Tr@t0res2024!", "agromecanica-brasil.jpg", "Fabricante líder de maquinário agrícola desde 1987.");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o e-mail não pode conter espaços.");
        }

        [Fact(DisplayName = "Criar empresa com mais de um arroba no email")]
        public void CriarEmpresa_ComMaisDeUmArrobaNoEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Empresa(1, "AgroMecânica Brasil Ltda", "vendas@agro@mecanicabrasil.com.br", "Tr@t0res2024!", "agromecanica-brasil.jpg", "Fabricante líder de maquinário agrícola desde 1987.");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o e-mail pode ter apenas um '@'.");
        }

        [Fact(DisplayName = "Criar empresa com usuário de email vazio")]
        public void CriarEmpresa_ComUsuarioDeEmailVazio_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Empresa(1, "AgroMecânica Brasil Ltda", "@agromecanicabrasil.com.br", "Tr@t0res2024!", "agromecanica-brasil.jpg", "Fabricante líder de maquinário agrícola desde 1987.");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o nome de usuário é obrigatório.");
        }

        [Fact(DisplayName = "Criar empresa com ponto no início do email")]
        public void CriarEmpresa_ComPontoNoInicioDoEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Empresa(1, "AgroMecânica Brasil Ltda", ".vendas@agromecanicabrasil.com.br", "Tr@t0res2024!", "agromecanica-brasil.jpg", "Fabricante líder de maquinário agrícola desde 1987.");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o email não pode começar com ponto (.).");
        }

        [Fact(DisplayName = "Criar empresa com ponto no final do usuário de email")]
        public void CriarEmpresa_ComPontoNoFinalDoUsuarioDeEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Empresa(1, "AgroMecânica Brasil Ltda", "vendas.@agromecanicabrasil.com.br", "Tr@t0res2024!", "agromecanica-brasil.jpg", "Fabricante líder de maquinário agrícola desde 1987.");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o nome de usuário não pode terminar com ponto (.).");
        }

        [Fact(DisplayName = "Criar empresa com caracteres inválidos no usuario de email")]
        public void CriarEmpresa_ComCaracteresInvalidosNoUsuarioDeEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Empresa(1, "AgroMecânica Brasil Ltda", "[vendas]@agromecanicabrasil.com.br", "Tr@t0res2024!", "agromecanica-brasil.jpg", "Fabricante líder de maquinário agrícola desde 1987.");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage($"E-mail inválido, o nome de usuário não pode conter: {new string(ConstantesValidacao.caracteresInvalidosEmailUsuario)}.");
        }

        [Fact(DisplayName = "Criar empresa com domínio de email vazio")]
        public void CriarEmpresa_ComDominioDeEmailVazio_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Empresa(1, "AgroMecânica Brasil Ltda", "vendas@", "Tr@t0res2024!", "agromecanica-brasil.jpg", "Fabricante líder de maquinário agrícola desde 1987.");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o domínio é obrigatório.");
        }

        [Fact(DisplayName = "Criar empresa sem ponto no domínio de email")]
        public void CriarEmpresa_SemPontoNoDominioDeEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Empresa(1, "AgroMecânica Brasil Ltda", "vendas@agromecanicabrasil", "Tr@t0res2024!", "agromecanica-brasil.jpg", "Fabricante líder de maquinário agrícola desde 1987.");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o domínio deve conter pelo menos um '.' (Exemplo: gmail.com).");
        }

        [Fact(DisplayName = "Criar empresa com hifén no início do domínio de email")]
        public void CriarEmpresa_ComHifenNoInicoDoDominioDeEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Empresa(1, "AgroMecânica Brasil Ltda", "vendas@-agromecanicabrasil.com.br", "Tr@t0res2024!", "agromecanica-brasil.jpg", "Fabricante líder de maquinário agrícola desde 1987.");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o domínio não pode começar com hífen (-).");
        }

        [Fact(DisplayName = "Criar empresa com hífen no final do email")]
        public void CriarEmpresa_ComHifenNoFinalDoEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Empresa(1, "AgroMecânica Brasil Ltda", "vendas@agromecanicabrasil.com.br-", "Tr@t0res2024!", "agromecanica-brasil.jpg", "Fabricante líder de maquinário agrícola desde 1987.");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-mail inválido, o e-mail não pode terminar com hífen (-).");
        }

        [Fact(DisplayName = "Criar empresa com caracteres inválidos no domínio de email")]
        public void CriarEmpresa_ComCaracteresInvalidosNoDominioDeEmail_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Empresa(1, "AgroMecânica Brasil Ltda", "vendas@agromecanica*brasil.com.br", "Tr@t0res2024!", "agromecanica-brasil.jpg", "Fabricante líder de maquinário agrícola desde 1987.");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage($"E-mail inválido, o domínio não pode conter: {new string(ConstantesValidacao.caracteresInvalidosEmailDominio)}.");
        }

        #endregion

        #region Testes de senha

        [Fact(DisplayName = "Criar empresa com senha nula")]
        public void CriarEmpresa_ComSenhaNula_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Empresa(1, "AgroMecânica Brasil Ltda", "vendas@agromecanicabrasil.com.br", null, "agromecanica-brasil.jpg", "Fabricante líder de maquinário agrícola desde 1987.");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Senha inválida, a senha é obrigatória.");
        }

        [Fact(DisplayName = "Criar empresa com senha vazia")]
        public void CriarEmpresa_ComSenhaVazia_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Empresa(1, "AgroMecânica Brasil Ltda", "vendas@agromecanicabrasil.com.br", "", "agromecanica-brasil.jpg", "Fabricante líder de maquinário agrícola desde 1987.");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Senha inválida, a senha é obrigatória.");
        }

        [Fact(DisplayName = "Criar empresa com senha muito curta")]
        public void CriarEmpresa_ComSenhaMuitoCurta_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Empresa(1, "AgroMecânica Brasil Ltda", "vendas@agromecanicabrasil.com.br", "Dron&24", "agromecanica-brasil.jpg", "Fabricante líder de maquinário agrícola desde 1987.");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Senha inválida, a senha deve ter no mínimo 8 caracteres.");
        }

        [Fact(DisplayName = "Criar empresa com senha muito longa")]
        public void CriarEmpresa_ComSenhaMuitoLonga_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Empresa(1, "AgroMecânica Brasil Ltda", "vendas@agromecanicabrasil.com.br", "@gr0M&c@n!c@Br@s!lLtd@1987_2025#F@bric@ca0&V3nd@s*Maquinas*Agriculas*", "agromecanica-brasil.jpg", "Fabricante líder de maquinário agrícola desde 1987.");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Senha inválida, a senha pode ter no máximo 64 caracteres.");
        }

        [Fact(DisplayName = "Criar empresa com espaço na senha")]
        public void CriarEmpresa_ComEspacoNaSenha_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Empresa(1, "AgroMecânica Brasil Ltda", "vendas@agromecanicabrasil.com.br", "Tr@t0res 2024!", "agromecanica-brasil.jpg", "Fabricante líder de maquinário agrícola desde 1987.");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Senha inválida, a senha não pode conter espaços.");
        }

        [Fact(DisplayName = "Criar empresa sem letra maiúscula na senha")]
        public void CriarEmpresa_SemLetraMaiusculaNaSenha_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Empresa(1, "AgroMecânica Brasil Ltda", "vendas@agromecanicabrasil.com.br", "tr@t0res2024!", "agromecanica-brasil.jpg", "Fabricante líder de maquinário agrícola desde 1987.");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Senha inválida, a senha deve conter pelo menos uma letra maiúscula.");
        }

        [Fact(DisplayName = "Criar empresa sem letra minúscula na senha")]
        public void CriarEmpresa_SemLetraMinusculaNaSenha_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Empresa(1, "AgroMecânica Brasil Ltda", "vendas@agromecanicabrasil.com.br", "TR@T0RES2024!", "agromecanica-brasil.jpg", "Fabricante líder de maquinário agrícola desde 1987.");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Senha inválida, a senha deve conter pelo menos uma letra minúscula.");
        }

        [Fact(DisplayName = "Criar empresa sem número na senha")]
        public void CriarEmpresa_SemNumeroNaSenha_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Empresa(1, "AgroMecânica Brasil Ltda", "vendas@agromecanicabrasil.com.br", "Tr@tores!", "agromecanica-brasil.jpg", "Fabricante líder de maquinário agrícola desde 1987.");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Senha inválida, a senha deve conter pelo menos um número.");
        }

        [Fact(DisplayName = "Criar empresa sem caracteres especiais na senha")]
        public void CriarEmpresa_SemCaracteresEspeciaisNaSenha_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Empresa(1, "AgroMecânica Brasil Ltda", "vendas@agromecanicabrasil.com.br", "Trat0res2024", "agromecanica-brasil.jpg", "Fabricante líder de maquinário agrícola desde 1987.");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage($"Senha inválida, a senha deve conter pelo menos um caractere especial. Exemplo: {new string(ConstantesValidacao.caracteresEspeciaisPermitidosSenha)}.");
        }

        #endregion

        #region Testes de imagem

        [Fact(DisplayName = "Criar empresa com URL de foto muito longa")]
        public void CriarEmpresa_ComURLMuitoLonga_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Empresa(1, "AgroMecânica Brasil Ltda", "vendas@agromecanicabrasil.com.br", "Tr@t0res2024!", "agromecanica-brasil.com.br/images/catalog/2024/tratores/trator-8320r-4x4-comando-atuador-frontal-precision-pro-bordo-verde-amarelo-foto-industrial-360graus-highres-8k-background-transparente-motor-9.0L-powertech-psd-transmissao-command-24-velocidade.png", "Fabricante líder de maquinário agrícola desde 1987.");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("URL da imagem inválida, a URL pode ter no máximo 250 caracteres.");
        }

        #endregion

        #region Testes de biografia

        [Fact(DisplayName = "Criar empresa com bio muito longa")]
        public void CriarEmpresa_ComBioMuitoLonga_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Empresa(1, "AgroMecânica Brasil Ltda", "vendas@agromecanicabrasil.com.br", "Tr@t0res2024!", "agromecanica-brasil.jpg", "A AgroMecânica Brasil é líder na fabricação de máquinas agrícolas de alta tecnologia desde 1987. Especializada em tratores, colheitadeiras e pulverizadores autopropelidos, nossa linha inclui modelos com precisão sub-centimétrica, motores PowerTech e telemetria integrada. Atuamos em todo o território nacional, oferecendo suporte técnico 24h. Premiada como 'Melhor Inovação em Agricultura de Precisão 2023', investimos em soluções sustentáveis, como motores Stage V e sistemas de pulverização inteligente.");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Biografia inválida, a biografia pode ter no máximo 500 caracteres.");
        }

        #endregion
    }
}
