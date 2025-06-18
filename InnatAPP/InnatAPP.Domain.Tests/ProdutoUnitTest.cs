using Xunit;
using FluentAssertions;
using InnatAPP.Domain.Entities;

namespace InnatAPP.Domain.Tests
{
    public class ProdutoUnitTest
    {
        #region Testes de Parâmetros Válidos

        [Fact(DisplayName = "Criar produto com estado válido")]
        public void CriarProduto_ComParametrosValidos_ResultandoEmObjetoComEstadoValido()
        {
            Action action = () =>
            {
                var produto = new Produto(
                    Guid.NewGuid(),
                    "Drone AgroScan T-24", 
                    "Um drone de modelo simples.",
                    "Drone.png",
                    3.6m,  
                    78,
                    Guid.NewGuid(),
                    Guid.NewGuid()
                );
            };

            action.Should()
                .NotThrow<InnatAPP.Domain.Validation.DomainExceptionValidation>();
        }

        #endregion

        #region Testes de Parâmetros Inválidos

        #region Testes de Id

        [Fact(DisplayName = "Criar produto com id vazio")]
        public void CriarProduto_ComIdVazio_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var produto = new Produto(
                    Guid.Empty,
                    "Drone AgroScan T-24",
                    "Um drone de modelo simples.",
                    "Drone.png",
                    3.6m,
                    78,
                    Guid.NewGuid(),
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O id é obrigatório.");
        }

        #endregion

        #region Testes de Id de Categoria

        [Fact(DisplayName = "Criar produto com id de categoria vazio")]
        public void CriarProduto_ComIdDeCategoriaVazio_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var produto = new Produto(
                    Guid.NewGuid(),
                    "Drone AgroScan T-24",
                    "Um drone de modelo simples.",
                    "Drone.png",
                    3.6m,
                    78,
                    Guid.Empty,
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O id de categoria é obrigatório.");
        }

        #endregion

        #region Testes de Id de Empresa

        [Fact(DisplayName = "Criar produto com id de empresa vazio")]
        public void CriarProduto_ComIdDeEmpresaVazio_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var produto = new Produto(
                    Guid.NewGuid(),
                    "Drone AgroScan T-24",
                    "Um drone de modelo simples.",
                    "Drone.png",
                    3.6m,
                    78,
                    Guid.NewGuid(),
                    Guid.Empty
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O id de empresa é obrigatório.");
        }

        #endregion

        #region Testes de Nome

        [Fact(DisplayName = "Criar produto com nome nulo")]
        public void CriarProduto_ComNomeNulo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var produto = new Produto(
                    Guid.NewGuid(),
                    null,
                    "Um drone de modelo simples.",
                    "Drone.png",
                    3.6m,
                    78,
                    Guid.NewGuid(),
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O nome é obrigatório.");
        }

        [Fact(DisplayName = "Criar produto com nome vazio")]
        public void CriarProduto_ComNomeVazio_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var produto = new Produto(
                    Guid.NewGuid(),
                    "",
                    "Um drone de modelo simples.",
                    "Drone.png",
                    3.6m,
                    78,
                    Guid.NewGuid(),
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O nome é obrigatório.");
        }

        [Fact(DisplayName = "Criar produto com nome em branco")]
        public void CriarProduto_ComNomeEmBranco_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var produto = new Produto(
                    Guid.NewGuid(),
                    " ",
                    "Um drone de modelo simples.",
                    "Drone.png",
                    3.6m,
                    78,
                    Guid.NewGuid(),
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O nome é obrigatório.");
        }

        [Fact(DisplayName = "Criar produto com espaço no início do nome")]
        public void CriarProduto_ComEspacoNoInícioDoNome_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var produto = new Produto(
                    Guid.NewGuid(),
                    " Drone AgroScan T-24",
                    "Um drone de modelo simples.",
                    "Drone.png",
                    3.6m,
                    78,
                    Guid.NewGuid(),
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O nome não pode começar com espaço (\" \").");
        }

        [Fact(DisplayName = "Criar produto com espaço no final do nome")]
        public void CriarProduto_ComEspacoNoFinalDoNome_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var produto = new Produto(
                    Guid.NewGuid(),
                    "Drone AgroScan T-24 ",
                    "Um drone de modelo simples.",
                    "Drone.png",
                    3.6m,
                    78,
                    Guid.NewGuid(),
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O nome não pode terminar com espaço (\" \").");
        }

        [Fact(DisplayName = "Criar produto com espaços consecutivos no nome")]
        public void CriarProduto_ComEspacosConsecutivosNoNome_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var produto = new Produto(
                    Guid.NewGuid(),
                    "Drone  AgroScan T-24",
                    "Um drone de modelo simples.",
                    "Drone.png",
                    3.6m,
                    78,
                    Guid.NewGuid(),
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O nome não pode ter espaços consecutivos (\"  \", \"   \", \"    \" e etc).");
        }

        [Fact(DisplayName = "Criar produto com nome muito curto")]
        public void CriarProduto_ComNomeMuitoCurto_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var produto = new Produto(
                    Guid.NewGuid(),
                    "D",
                    "Um drone de modelo simples.",
                    "Drone.png",
                    3.6m,
                    78,
                    Guid.NewGuid(),
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O nome deve ter no mínimo 2 caracteres.");
        }

        [Fact(DisplayName = "Criar produto com nome muito longo")]
        public void CriarProduto_ComNomeMuitoLongo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var produto = new Produto(
                    Guid.NewGuid(),
                    "AgroScan T-24: Drone Multiespectral com Autonomia de 60 Minutos e Sistema de Pulverização Inteligente.",
                    "Um drone de modelo simples.",
                    "Drone.png",
                    3.6m,
                    78,
                    Guid.NewGuid(),
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O nome pode ter no máximo 100 caracteres.");
        }

        #endregion

        #region Testes de Descrição

        [Fact(DisplayName = "Criar produto com descrição nula")]
        public void CriarProduto_ComDescricaoNula_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var produto = new Produto(
                    Guid.NewGuid(),
                    "Drone AgroScan T-24",
                    null,
                    "Drone.png",
                    3.6m,
                    78,
                    Guid.NewGuid(),
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("A descrição é obrigatória.");
        }

        [Fact(DisplayName = "Criar produto com descrição vazia")]
        public void CriarProduto_ComDescricaoVazia_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var produto = new Produto(
                    Guid.NewGuid(),
                    "Drone AgroScan T-24",
                    "",
                    "Drone.png",
                    3.6m,
                    78,
                    Guid.NewGuid(),
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("A descrição é obrigatória.");
        }

        [Fact(DisplayName = "Criar produto com descrição em branco")]
        public void CriarProduto_ComDescricaoEmBranco_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var produto = new Produto(
                    Guid.NewGuid(),
                    "Drone AgroScan T-24",
                    " ",
                    "Drone.png",
                    3.6m,
                    78,
                    Guid.NewGuid(),
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("A descrição é obrigatória.");
        }

        [Fact(DisplayName = "Criar produto com descrição muito curta")]
        public void CriarProduto_ComDescriçãoMuitoCurta_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var produto = new Produto(
                    Guid.NewGuid(),
                    "Drone AgroScan T-24",
                    "Um drone",
                    "Drone.png",
                    3.6m,
                    78,
                    Guid.NewGuid(),
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("A descrição deve ter no mínimo 10 caracteres.");
        }

        [Fact(DisplayName = "Criar produto com descrição muito longa")]
        public void CriarProduto_ComDescriçãoMuitoLonga_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var produto = new Produto(
                    Guid.NewGuid(),
                    "Drone AgroScan T-24",
                    "AgroScan T-42 Xtreme Precision Farming Drone: Sistema Aéreo Inteligente para Agricultura 4.0 com Câmera Multiespectral 12MP, Sensor NDVI Hi-Res, Autonomia de 60 Minutos, Bateria Dupla Swappable, Alcance de 30km em Tempo Real via 5G, Sistema de Pulverização Inteligente com Tanque de 15L, Modo Automático de Varredura em Padrão Zig-Zag, Alerta de Áreas com Deficiência Nutricional, Certificação ANAC/Mapa, Suporte Técnico 24/7 e Garantia Estendida de 3 Anos - Edição Limitada Fazendas Inteligentes 2024.",
                    "Drone.png",
                    3.6m,
                    78,
                    Guid.NewGuid(),
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("A descrição pode ter no máximo 500 caracteres.");
        }

        #endregion

        #region Testes de Foto

        [Fact(DisplayName = "Criar produto com URL de foto muito longa")]
        public void CriarProduto_ComUrlDeFotoMuitoLonga_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var produto = new Produto(
                    Guid.NewGuid(),
                    "Drone AgroScan T-24",
                    "Um drone de modelo simples.",
                    "drone-profissional-phantom-4-pro-v2-0-com-camera-4k-ultra-hd-estabilizador-gimbal-gps-retorno-automatico-sensor-anticolisao-bateria-longa-duracao-voo-inteligente-autonomo-controle-remoto-7km-transmissao-hd-foto-video-aereo-tecnologia-avancada-xpt123.jpg",
                    3.6m,
                    78,
                    Guid.NewGuid(),
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("A URL da foto pode ter no máximo 250 caracteres.");
        }

        #endregion

        #region Testes de Nota

        [Fact(DisplayName = "Criar produto com valor de nota menor que 0")]
        public void CriarProduto_ComValorDeNotaMenorQueZero_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var produto = new Produto(
                    Guid.NewGuid(),
                    "Drone AgroScan T-24",
                    "Um drone de modelo simples.",
                    "Drone.png",
                    -3.6m,
                    78,
                    Guid.NewGuid(),
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("A nota não pode ser menor que zero (0).");
        }

        [Fact(DisplayName = "Criar produto com valor de nota maior que 5")]
        public void CriarProduto_ComValorDeNotaMaiorQueCinco_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var produto = new Produto(
                    Guid.NewGuid(),
                    "Drone AgroScan T-24",
                    "Um drone de modelo simples.",
                    "Drone.png",
                    6.0m,
                    78,
                    Guid.NewGuid(),
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("A nota não pode ser maior que cinco (5).");
        }

        #endregion

        #region Testes de Total de Reviews

        [Fact(DisplayName = "Criar produto com valor total de reviews menor que 0")]
        public void CriarProduto_ComValorTotalDeReviewsMenorQueZero_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var produto = new Produto(
                    Guid.NewGuid(),
                    "Drone AgroScan T-24",
                    "Um drone de modelo simples.",
                    "Drone.png",
                    3.6m,
                    -1,
                    Guid.NewGuid(),
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O valor total de reviews não pode ser menor que zero (0).");
        }

        #endregion

        #endregion
    }
}