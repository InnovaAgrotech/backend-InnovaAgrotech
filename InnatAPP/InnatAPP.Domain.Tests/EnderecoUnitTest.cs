#region Importações

using Xunit;
using FluentAssertions;
using InnatAPP.Domain.Entities;

#endregion

namespace InnatAPP.Domain.Tests
{
    public class EnderecoUnitTest
    {
        #region Testes de parâmetros válidos

        [Fact(DisplayName = "Criar endereço com estado válido")]
        public void CriarEndereco_ComParametrosValidos_ResultandoEmObjetoComEstadoValido()
        {
            Action action = () => new Endereco(1, "1234", "Avenida das Palmeiras", "Zona Rural", "Sinop", "MT", "78550000", "Fazenda verde horizonte, próximo ao posto de combustível");
            action.Should()
                .NotThrow<InnatAPP.Domain.Validation.DomainExceptionValidation>();
        }

        #endregion

        #region Testes de Id

        [Fact(DisplayName = "Criar endereço com id negativo")]
        public void CriarEndereco_ComIdNegativo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Endereco(-1, "1234", "Avenida das Palmeiras", "Zona Rural", "Sinop", "MT", "78550000", "Fazenda verde horizonte, próximo ao posto de combustível");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Valor de id inválido.");
        }

        #endregion

        #region Testes de número

        [Fact(DisplayName = "Criar endereço com número nulo")]
        public void CriarEndereco_ComNumeroNulo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Endereco(1, null, "Avenida das Palmeiras", "Zona Rural", "Sinop", "MT", "78550000", "Fazenda verde horizonte, próximo ao posto de combustível");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Endereço inválido, o número é obrigatório.");
        }

        [Fact(DisplayName = "Criar endereço com número vazio")]
        public void CriarEndereco_ComNumeroVazio_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Endereco(1, "", "Avenida das Palmeiras", "Zona Rural", "Sinop", "MT", "78550000", "Fazenda verde horizonte, próximo ao posto de combustível");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Endereço inválido, o número é obrigatório.");
        }

        [Fact(DisplayName = "Criar endereço com caracteres que não são dígitos no número")]
        public void CriarEndereco_ComCaracteresQueNaoSaoDigitosNoNumero_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Endereco(1, "UmDoisTrêsQuatro", "Avenida das Palmeiras", "Zona Rural", "Sinop", "MT", "78550000", "Fazenda verde horizonte, próximo ao posto de combustível");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Endereço inválido, o número deve conter apenas dígitos.");
        }

        [Fact(DisplayName = "Criar endereço com número muito longo")]
        public void CriarEndereco_ComNumeroMuitoLongo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Endereco(1, "012345678910", "Avenida das Palmeiras", "Zona Rural", "Sinop", "MT", "78550000", "Fazenda verde horizonte, próximo ao posto de combustível");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Endereço inválido, o número pode ter no máximo 10 dígitos.");
        }

        #endregion

        #region Testes de rua

        [Fact(DisplayName = "Criar endereço com rua nula")]
        public void CriarEndereco_ComRuaNula_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Endereco(1, "1234", null, "Zona Rural", "Sinop", "MT", "78550000", "Fazenda verde horizonte, próximo ao posto de combustível");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Endereço inválido, a rua é obrigatória.");
        }

        [Fact(DisplayName = "Criar endereço com rua vazia")]
        public void CriarEndereco_ComRuaVazia_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Endereco(1, "1234", "", "Zona Rural", "Sinop", "MT", "78550000", "Fazenda verde horizonte, próximo ao posto de combustível");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Endereço inválido, a rua é obrigatória.");
        }

        [Fact(DisplayName = "Criar endereço com rua muito curta")]
        public void CriarEndereco_ComRuaMuitoCurta_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Endereco(1, "1234", "Av", "Zona Rural", "Sinop", "MT", "78550000", "Fazenda verde horizonte, próximo ao posto de combustível");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Endereço inválido, a rua deve ter no mínimo 3 caracteres.");
        }

        [Fact(DisplayName = "Criar endereço com rua muito longa")]
        public void CriarEndereco_ComRuaMuitoLonga_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Endereco(1, "1234", "Avenida das Colheitas Douradas do Cerrado Brasileiro entre os Rios Verde e Araguaia na Região dos Chapadões", "Zona Rural", "Sinop", "MT", "78550000", "Fazenda verde horizonte, próximo ao posto de combustível");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Endereço inválido, a rua pode ter no máximo 100 caracteres.");
        }

        #endregion

        #region Testes de bairro

        [Fact(DisplayName = "Criar endereço com bairro nulo")]
        public void CriarEndereco_ComBairroNulo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Endereco(1, "1234", "Avenida das Palmeiras", null, "Sinop", "MT", "78550000", "Fazenda verde horizonte, próximo ao posto de combustível");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Endereço inválido, o bairro é obrigatório.");
        }

        [Fact(DisplayName = "Criar endereço com bairro vazio")]
        public void CriarEndereco_ComBairroVazio_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Endereco(1, "1234", "Avenida das Palmeiras", "", "Sinop", "MT", "78550000", "Fazenda verde horizonte, próximo ao posto de combustível");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Endereço inválido, o bairro é obrigatório.");
        }

        [Fact(DisplayName = "Criar endereço com bairro muito curto")]
        public void CriarEndereco_ComBairroMuitoCurto_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Endereco(1, "1234", "Avenida das Palmeiras", "Zo", "Sinop", "MT", "78550000", "Fazenda verde horizonte, próximo ao posto de combustível");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Endereço inválido, o bairro deve ter no mínimo 3 caracteres.");
        }

        [Fact(DisplayName = "Criar endereço com bairro muito longo")]
        public void CriarEndereco_ComBairroMuitoLongo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Endereco(1, "1234", "Avenida das Palmeiras", "Jardim das Oliveiras na Zona Sul da Cidade com Acesso à Rodovia", "Sinop", "MT", "78550000", "Fazenda verde horizonte, próximo ao posto de combustível");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Endereço inválido, o bairro pode ter no máximo 60 caracteres.");
        }

        #endregion

        #region Testes de cidade

        [Fact(DisplayName = "Criar endereço com cidade nula")]
        public void CriarEndereco_ComCidadeNula_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Endereco(1, "1234", "Avenida das Palmeiras", "Zona Rural", null, "MT", "78550000", "Fazenda verde horizonte, próximo ao posto de combustível");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Endereço inválido, a cidade é obrigatória.");
        }

        [Fact(DisplayName = "Criar endereço com cidade vazia")]
        public void CriarEndereco_ComCidadeVazia_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Endereco(1, "1234", "Avenida das Palmeiras", "Zona Rural", "", "MT", "78550000", "Fazenda verde horizonte, próximo ao posto de combustível");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Endereço inválido, a cidade é obrigatória.");
        }

        [Fact(DisplayName = "Criar endereço com cidade muito curta")]
        public void CriarEndereco_ComCidadeMuitoCurta_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Endereco(1, "1234", "Avenida das Palmeiras", "Zona Rural", "S", "MT", "78550000", "Fazenda verde horizonte, próximo ao posto de combustível");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Endereço inválido, a cidade deve ter no mínimo 2 caracteres.");
        }

        [Fact(DisplayName = "Criar endereço com cidade muito longa")]
        public void CriarEndereco_ComCidadeMuitoLonga_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Endereco(1, "1234", "Avenida das Palmeiras", "Zona Rural", "Santa Rita Costa do Vale Fértil das Terras Agricultáveis Douradas no Sul de Goiás", "MT", "78550000", "Fazenda verde horizonte, próximo ao posto de combustível");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Endereço inválido, a cidade pode ter no máximo 80 caracteres.");
        }

        #endregion

        #region Testes de número

        [Fact(DisplayName = "Criar endereço com estado nulo")]
        public void CriarEndereco_ComEstadoNulo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Endereco(1, "1234", "Avenida das Palmeiras", "Zona Rural", "Sinop", null, "78550000", "Fazenda verde horizonte, próximo ao posto de combustível");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Endereço inválido, o estado é obrigatório.");
        }

        [Fact(DisplayName = "Criar endereço com estado vazio")]
        public void CriarEndereco_ComEstadoVazio_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Endereco(1, "1234", "Avenida das Palmeiras", "Zona Rural", "Sinop", "", "78550000", "Fazenda verde horizonte, próximo ao posto de combustível");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Endereço inválido, o estado é obrigatório.");
        }

        [Fact(DisplayName = "Criar endereço com caracteres que não são letras no estado")]
        public void CriarEndereco_ComCaracteresQueNaoSaoLetrasNoEstado_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Endereco(1, "1234", "Avenida das Palmeiras", "Zona Rural", "Sinop", "52", "78550000", "Fazenda verde horizonte, próximo ao posto de combustível");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Endereço inválido, o estado deve conter apenas letras.");
        }

        [Fact(DisplayName = "Criar endereço com menos de duas letras no estado")]
        public void CriarEndereco_ComMenosDeDuasLetrasNoEstado_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Endereco(1, "1234", "Avenida das Palmeiras", "Zona Rural", "Sinop", "M", "78550000", "Fazenda verde horizonte, próximo ao posto de combustível");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Endereço inválido, o estado deve ter 2 letras (UF).");
        }

        [Fact(DisplayName = "Criar endereço com mais de duas letras no estado")]
        public void CriarEndereco_ComMaisDeDuasLetrasNoEstado_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Endereco(1, "1234", "Avenida das Palmeiras", "Zona Rural", "Sinop", "MTS", "78550000", "Fazenda verde horizonte, próximo ao posto de combustível");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Endereço inválido, o estado deve ter 2 letras (UF).");
        }

        #endregion

        #region Testes de CEP

        [Fact(DisplayName = "Criar endereço com CEP nulo")]
        public void CriarEndereco_ComCEPNulo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Endereco(1, "1234", "Avenida das Palmeiras", "Zona Rural", "Sinop", "MT", null, "Fazenda verde horizonte, próximo ao posto de combustível");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Endereço inválido, o CEP é obrigatório.");
        }

        [Fact(DisplayName = "Criar endereço com CEP vazio")]
        public void CriarEndereco_ComCEPVazio_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Endereco(1, "1234", "Avenida das Palmeiras", "Zona Rural", "Sinop", "MT", "", "Fazenda verde horizonte, próximo ao posto de combustível");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Endereço inválido, o CEP é obrigatório.");
        }

        [Fact(DisplayName = "Criar endereço com caracteres que não são dígitos no CEP")]
        public void CriarEndereco_ComCaracteresQueNaoSaoDigitosNoCEP_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Endereco(1, "1234", "Avenida das Palmeiras", "Zona Rural", "Sinop", "MT", "SeteOito2Cinco4Zero", "Fazenda verde horizonte, próximo ao posto de combustível");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Endereço inválido, o CEP deve conter apenas dígitos.");
        }

        [Fact(DisplayName = "Criar endereço com menos de oito dígitos no CEP")]
        public void CriarEndereco_ComMenosDeOitoDigitosNoCEP_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Endereco(1, "1234", "Avenida das Palmeiras", "Zona Rural", "Sinop", "MT", "785500", "Fazenda verde horizonte, próximo ao posto de combustível");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Endereço inválido, o CEP deve ter 8 dígitos (Sem traço).");
        }

        [Fact(DisplayName = "Criar endereço com mais de oito dígito no CEP")]
        public void CriarEndereco_ComMaisDeOitoDigitosNoCEP_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Endereco(1, "1234", "Avenida das Palmeiras", "Zona Rural", "Sinop", "MT", "7855000000", "Fazenda verde horizonte, próximo ao posto de combustível");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Endereço inválido, o CEP deve ter 8 dígitos (Sem traço).");
        }


        #endregion

        #region Testes de complemento

        [Fact(DisplayName = "Criar endereço com complemento muito longo")]
        public void CriarEndereco_ComComplementoMuitoLongo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Endereco(1, "1234", "Avenida das Palmeiras", "Zona Rural", "Sinop", "MT", "78550000", "Galpão Agrícola 3, Fundos da Propriedade, próximo ao Silo de Armazenamento, acesso pela Estrada Rural KM 12");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Endereço inválido, o complemento pode ter no máximo 100 caracteres.");
        }

        #endregion
    }
}
