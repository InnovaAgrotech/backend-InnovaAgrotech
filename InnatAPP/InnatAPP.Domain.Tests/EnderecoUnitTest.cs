using Xunit;
using FluentAssertions;
using InnatAPP.Domain.Entities;

namespace InnatAPP.Domain.Tests
{
    public class EnderecoUnitTest
    {
        #region Testes de Parâmetros Válidos

        [Fact(DisplayName = "Criar endereço com estado válido")]
        public void CriarEndereco_ComParametrosValidos_ResultandoEmObjetoComEstadoValido()
        {
            Action action = () =>
            {
                var endereco = new Endereco(
                    Guid.NewGuid(),
                    "1234", 
                    "Avenida das Palmeiras", 
                    "Zona Rural", 
                    "Sinop", 
                    "MT", 
                    "Fazenda verde horizonte, próximo ao posto de combustível",
                    "78550000",
                    Guid.NewGuid()
                );
            };

            action.Should()
                .NotThrow<InnatAPP.Domain.Validation.DomainExceptionValidation>();
        }

        #endregion

        #region Testes de Parâmetros Inválidos

        #region Testes de Id

        [Fact(DisplayName = "Criar endereço com id vazio")]
        public void CriarEndereco_ComIdVazio_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var endereco = new Endereco(
                    Guid.Empty,
                    "1234",
                    "Avenida das Palmeiras",
                    "Zona Rural",
                    "Sinop",
                    "MT",
                    "Fazenda verde horizonte, próximo ao posto de combustível",
                    "78550000",
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O id é obrigatório.");
        }

        #endregion

        #region Testes de Id de Usuario

        [Fact(DisplayName = "Criar endereço com id de usuário vazio")]
        public void CriarEndereco_ComIdDeUsuarioVazio_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var endereco = new Endereco(
                    Guid.NewGuid(),
                    "1234",
                    "Avenida das Palmeiras",
                    "Zona Rural",
                    "Sinop",
                    "MT",
                    "Fazenda verde horizonte, próximo ao posto de combustível",
                    "78550000",
                    Guid.Empty
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O id de usuário é obrigatório.");
        }

        #endregion

        #region Testes de Número

        [Fact(DisplayName = "Criar endereço com número muito longo")]
        public void CriarEndereco_ComNumeroMuitoLongo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var endereco = new Endereco(
                    Guid.NewGuid(),
                    "012345678910",
                    "Avenida das Palmeiras",
                    "Zona Rural",
                    "Sinop",
                    "MT",
                    "Fazenda verde horizonte, próximo ao posto de combustível",
                    "78550000",
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O número pode ter no máximo 10 caracteres.");
        }

        #endregion

        #region Testes de Rua

        [Fact(DisplayName = "Criar endereço com rua nula")]
        public void CriarEndereco_ComRuaNula_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var endereco = new Endereco(
                    Guid.NewGuid(),
                    "1234",
                    null,
                    "Zona Rural",
                    "Sinop",
                    "MT",
                    "Fazenda verde horizonte, próximo ao posto de combustível",
                    "78550000",
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("A rua é obrigatória.");
        }

        [Fact(DisplayName = "Criar endereço com rua vazia")]
        public void CriarEndereco_ComRuaVazia_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var endereco = new Endereco(
                    Guid.NewGuid(),
                    "1234",
                    "",
                    "Zona Rural",
                    "Sinop",
                    "MT",
                    "Fazenda verde horizonte, próximo ao posto de combustível",
                    "78550000",
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("A rua é obrigatória.");
        }

        [Fact(DisplayName = "Criar endereço com rua em branco")]
        public void CriarEndereco_ComRuaEmBraco_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var endereco = new Endereco(
                    Guid.NewGuid(),
                    "1234",
                    "  ",
                    "Zona Rural",
                    "Sinop",
                    "MT",
                    "Fazenda verde horizonte, próximo ao posto de combustível",
                    "78550000",
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("A rua é obrigatória.");
        }

        [Fact(DisplayName = "Criar endereço com rua muito curta")]
        public void CriarEndereco_ComRuaMuitoCurta_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var endereco = new Endereco(
                    Guid.NewGuid(),
                    "1234",
                    "Av",
                    "Zona Rural",
                    "Sinop",
                    "MT",
                    "Fazenda verde horizonte, próximo ao posto de combustível",
                    "78550000",
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("A rua deve ter no mínimo 3 caracteres.");
        }

        [Fact(DisplayName = "Criar endereço com rua muito longa")]
        public void CriarEndereco_ComRuaMuitoLonga_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var endereco = new Endereco(
                    Guid.NewGuid(),
                    "1234",
                    "Avenida das Colheitas Douradas do Cerrado Brasileiro entre os Rios Verde e Araguaia na Região dos Chapadões",
                    "Zona Rural",
                    "Sinop",
                    "MT",
                    "Fazenda verde horizonte, próximo ao posto de combustível",
                    "78550000",
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("A rua pode ter no máximo 100 caracteres.");
        }

        #endregion

        #region Testes de Bairro

        [Fact(DisplayName = "Criar endereço com bairro nulo")]
        public void CriarEndereco_ComBairroNulo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var endereco = new Endereco(
                    Guid.NewGuid(),
                    "1234",
                    "Avenida das Palmeiras",
                    null,
                    "Sinop",
                    "MT",
                    "Fazenda verde horizonte, próximo ao posto de combustível",
                    "78550000",
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O bairro é obrigatório.");
        }

        [Fact(DisplayName = "Criar endereço com bairro vazio")]
        public void CriarEndereco_ComBairroVazio_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var endereco = new Endereco(
                    Guid.NewGuid(),
                    "1234",
                    "Avenida das Palmeiras",
                    "",
                    "Sinop",
                    "MT",
                    "Fazenda verde horizonte, próximo ao posto de combustível",
                    "78550000",
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O bairro é obrigatório.");
        }

        [Fact(DisplayName = "Criar endereço com bairro em branco")]
        public void CriarEndereco_ComBairroEmBraco_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var endereco = new Endereco(
                    Guid.NewGuid(),
                    "1234",
                    "Avenida das Palmeiras",
                    " ",
                    "Sinop",
                    "MT",
                    "Fazenda verde horizonte, próximo ao posto de combustível",
                    "78550000",
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O bairro é obrigatório.");
        }

        [Fact(DisplayName = "Criar endereço com bairro muito curto")]
        public void CriarEndereco_ComBairroMuitoCurto_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var endereco = new Endereco(
                    Guid.NewGuid(),
                    "1234",
                    "Avenida das Palmeiras",
                    "Zo",
                    "Sinop",
                    "MT",
                    "Fazenda verde horizonte, próximo ao posto de combustível",
                    "78550000",
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O bairro deve ter no mínimo 3 caracteres.");
        }

        [Fact(DisplayName = "Criar endereço com bairro muito longo")]
        public void CriarEndereco_ComBairroMuitoLongo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var endereco = new Endereco(
                    Guid.NewGuid(),
                    "1234",
                    "Avenida das Palmeiras",
                    "Jardim das Oliveiras na Zona Sul da Cidade com Acesso à Rodovia",
                    "Sinop",
                    "MT",
                    "Fazenda verde horizonte, próximo ao posto de combustível",
                    "78550000",
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O bairro pode ter no máximo 60 caracteres.");
        }

        #endregion

        #region Testes de Cidade

        [Fact(DisplayName = "Criar endereço com cidade nula")]
        public void CriarEndereco_ComCidadeNula_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var endereco = new Endereco(
                    Guid.NewGuid(),
                    "1234",
                    "Avenida das Palmeiras",
                    "Zona Rural",
                    null,
                    "MT",
                    "Fazenda verde horizonte, próximo ao posto de combustível",
                    "78550000",
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("A cidade é obrigatória.");
        }

        [Fact(DisplayName = "Criar endereço com cidade vazia")]
        public void CriarEndereco_ComCidadeVazia_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var endereco = new Endereco(
                    Guid.NewGuid(),
                    "1234",
                    "Avenida das Palmeiras",
                    "Zona Rural",
                    "",
                    "MT",
                    "Fazenda verde horizonte, próximo ao posto de combustível",
                    "78550000",
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("A cidade é obrigatória.");
        }

        [Fact(DisplayName = "Criar endereço com cidade em branco")]
        public void CriarEndereco_ComCidadeEmBraco_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var endereco = new Endereco(
                    Guid.NewGuid(),
                    "1234",
                    "Avenida das Palmeiras",
                    "Zona Rural",
                    " ",
                    "MT",
                    "Fazenda verde horizonte, próximo ao posto de combustível",
                    "78550000",
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("A cidade é obrigatória.");
        }

        [Fact(DisplayName = "Criar endereço com cidade muito curta")]
        public void CriarEndereco_ComCidadeMuitoCurta_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var endereco = new Endereco(
                    Guid.NewGuid(),
                    "1234",
                    "Avenida das Palmeiras",
                    "Zona Rural",
                    "S",
                    "MT",
                    "Fazenda verde horizonte, próximo ao posto de combustível",
                    "78550000",
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("A cidade deve ter no mínimo 2 caracteres.");
        }

        [Fact(DisplayName = "Criar endereço com cidade muito longa")]
        public void CriarEndereco_ComCidadeMuitoLonga_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var endereco = new Endereco(
                    Guid.NewGuid(),
                    "1234",
                    "Avenida das Palmeiras",
                    "Zona Rural",
                    "Santa Rita Costa do Vale Fértil das Terras Agricultáveis Douradas no Sul de Goiás",
                    "MT",
                    "Fazenda verde horizonte, próximo ao posto de combustível",
                    "78550000",
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("A cidade pode ter no máximo 80 caracteres.");
        }

        #endregion

        #region Testes de Estado

        [Fact(DisplayName = "Criar endereço com estado nulo")]
        public void CriarEndereco_ComEstadoNulo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var endereco = new Endereco(
                    Guid.NewGuid(),
                    "1234",
                    "Avenida das Palmeiras",
                    "Zona Rural",
                    "Sinop",
                    null,
                    "Fazenda verde horizonte, próximo ao posto de combustível",
                    "78550000",
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O estado é obrigatório.");
        }

        [Fact(DisplayName = "Criar endereço com estado vazio")]
        public void CriarEndereco_ComEstadoVazio_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var endereco = new Endereco(
                    Guid.NewGuid(),
                    "1234",
                    "Avenida das Palmeiras",
                    "Zona Rural",
                    "Sinop",
                    "",
                    "Fazenda verde horizonte, próximo ao posto de combustível",
                    "78550000",
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O estado é obrigatório.");
        }

        [Fact(DisplayName = "Criar endereço com caracteres que não são letras no estado")]
        public void CriarEndereco_ComCaracteresQueNaoSaoLetrasNoEstado_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var endereco = new Endereco(
                    Guid.NewGuid(),
                    "1234",
                    "Avenida das Palmeiras",
                    "Zona Rural",
                    "Sinop",
                    "M7",
                    "Fazenda verde horizonte, próximo ao posto de combustível",
                    "78550000",
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O estado deve conter apenas letras.");
        }

        [Fact(DisplayName = "Criar endereço com menos de duas letras no estado")]
        public void CriarEndereco_ComMenosDeDuasLetrasNoEstado_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var endereco = new Endereco(
                    Guid.NewGuid(),
                    "1234",
                    "Avenida das Palmeiras",
                    "Zona Rural",
                    "Sinop",
                    "M",
                    "Fazenda verde horizonte, próximo ao posto de combustível",
                    "78550000",
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O estado deve ter 2 letras (UF).");
        }

        [Fact(DisplayName = "Criar endereço com mais de duas letras no estado")]
        public void CriarEndereco_ComMaisDeDuasLetrasNoEstado_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var endereco = new Endereco(
                    Guid.NewGuid(),
                    "1234",
                    "Avenida das Palmeiras",
                    "Zona Rural",
                    "Sinop",
                    "MTG",
                    "Fazenda verde horizonte, próximo ao posto de combustível",
                    "78550000",
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O estado deve ter 2 letras (UF).");
        }

        #endregion

        #region Testes de Complemento

        [Fact(DisplayName = "Criar endereço com complemento muito longo")]
        public void CriarEndereco_ComComplementoMuitoLongo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var endereco = new Endereco(
                    Guid.NewGuid(),
                    "1234",
                    "Avenida das Palmeiras",
                    "Zona Rural",
                    "Sinop",
                    "MT",
                    "Galpão Agrícola 3, Fundos da Propriedade, próximo ao Silo de Armazenamento, acesso pela Estrada Rural KM 12",
                    "78550000",
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O complemento pode ter no máximo 100 caracteres.");
        }

        #endregion

        #region Testes de CEP

        [Fact(DisplayName = "Criar endereço com CEP nulo")]
        public void CriarEndereco_ComCepNulo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var endereco = new Endereco(
                    Guid.NewGuid(),
                    "1234",
                    "Avenida das Palmeiras",
                    "Zona Rural",
                    "Sinop",
                    "MT",
                    "Fazenda verde horizonte, próximo ao posto de combustível",
                    null,
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O CEP é obrigatório.");
        }

        [Fact(DisplayName = "Criar endereço com CEP vazio")]
        public void CriarEndereco_ComCepVazio_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var endereco = new Endereco(
                    Guid.NewGuid(),
                    "1234",
                    "Avenida das Palmeiras",
                    "Zona Rural",
                    "Sinop",
                    "MT",
                    "Fazenda verde horizonte, próximo ao posto de combustível",
                    "",
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O CEP é obrigatório.");
        }

        [Fact(DisplayName = "Criar endereço com caracteres que não são dígitos no CEP")]
        public void CriarEndereco_ComCaracteresQueNaoSaoNumerosNoCep_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var endereco = new Endereco(
                    Guid.NewGuid(),
                    "1234",
                    "Avenida das Palmeiras",
                    "Zona Rural",
                    "Sinop",
                    "MT",
                    "Fazenda verde horizonte, próximo ao posto de combustível",
                    "7855OOOO",
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O CEP deve conter apenas dígitos.");
        }

        [Fact(DisplayName = "Criar endereço com menos de oito dígitos no CEP")]
        public void CriarEndereco_ComMenosDeOitoDigitosNoCep_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var endereco = new Endereco(
                    Guid.NewGuid(),
                    "1234",
                    "Avenida das Palmeiras",
                    "Zona Rural",
                    "Sinop",
                    "MT",
                    "Fazenda verde horizonte, próximo ao posto de combustível",
                    "7855",
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O CEP deve ter 8 dígitos (Sem traço).");
        }

        [Fact(DisplayName = "Criar endereço com mais de dois dígitos no estado")]
        public void CriarEndereco_ComMaisDeOitoDigitosNoCep_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var endereco = new Endereco(
                    Guid.NewGuid(),
                    "1234",
                    "Avenida das Palmeiras",
                    "Zona Rural",
                    "Sinop",
                    "MT",
                    "Fazenda verde horizonte, próximo ao posto de combustível",
                    "78550000000",
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O CEP deve ter 8 dígitos (Sem traço).");
        }

        #endregion

        #endregion
    }
}