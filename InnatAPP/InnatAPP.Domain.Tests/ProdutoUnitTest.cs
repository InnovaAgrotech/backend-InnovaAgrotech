#region Importações

using Xunit;
using FluentAssertions;
using InnatAPP.Domain.Entities;

#endregion

namespace InnatAPP.Domain.Tests
{
    public class ProdutoUnitTest
    {
        #region Testes de parâmetros válidos

        [Fact(DisplayName = "Criar produto com estado válido")]
        public void CriarProduto_ComParametrosValidos_ResultandoEmObjetoComEstadoValido()
        {
            Action action = () => new Produto(1, "Drone AgroScan T-24", "Um drone de modelo simples", 3.6m, "Drone.png", 78);
            action.Should()
                .NotThrow<InnatAPP.Domain.Validation.DomainExceptionValidation>();
        }

        #endregion

        #region Testes de id

        [Fact(DisplayName = "Criar produto com id negativo")]
        public void CriarProduto_ComIdNegativo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Produto(-1, "Drone AgroScan T-24", "Um drone de modelo simples", 3.6m, "Drone.png", 78);
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Valor de id inválido.");
        }

        #endregion

        #region Testes de nome

        [Fact(DisplayName = "Criar produto com nome nulo")]
        public void CriarProduto_ComNomeNulo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Produto(1, null, "Um drone de modelo simples", 3.6m, "Drone.png", 78);
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Nome inválido, o nome é obrigatório.");
        }

        [Fact(DisplayName = "Criar produto com nome vazio")]
        public void CriarProduto_ComNomeVazio_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Produto(1, "", "Um drone de modelo simples", 3.6m, "Drone.png", 78);
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Nome inválido, o nome é obrigatório.");
        }

        [Fact(DisplayName = "Criar produto com nome muito curto")]
        public void CriarProduto_ComNomeMuitoCurto_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Produto(1, "D", "Um drone de modelo simples", 3.6m, "Drone.png", 78);
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Nome inválido, o nome deve ter no mínimo 2 caracteres.");
        }

        [Fact(DisplayName = "Criar produto com nome muito longo")]
        public void CriarProduto_ComNomeMuitoLongo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Produto(1, "AgroScan T-24: Drone Multiespectral com Autonomia de 60 Minutos e Sistema de Pulverização Inteligente.", "Um drone de modelo simples", 3.6m, "Drone.png", 78);
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Nome inválido, o nome pode ter no máximo 100 caracteres.");
        }

        #endregion

        #region Testes de descrição

        [Fact(DisplayName = "Criar produto com descrição nula")]
        public void CriarProduto_ComDescricaoNula_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Produto(1, "Drone AgroScan T-24", null, 3.6m, "Drone.png", 78);
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Descrição inválida, a descrição é obrigatória.");
        }

        [Fact(DisplayName = "Criar produto com descrição vazia")]
        public void CriarProduto_ComDescricaoVazia_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Produto(1, "Drone AgroScan T-24", "", 3.6m, "Drone.png", 78);
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Descrição inválida, a descrição é obrigatória.");
        }

        [Fact(DisplayName = "Criar produto com descrição muito curta")]
        public void CriarProduto_ComDescricaoMuitoCurta_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Produto(1, "Drone AgroScan T-24", "Um drone", 3.6m, "Drone.png", 78);
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Descrição inválida, a descrição deve ter no mínimo 10 caracteres.");
        }

        [Fact(DisplayName = "Criar produto com descrição muito longa")]
        public void CriarProduto_ComDescricaoMuitoLonga_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Produto(1, "Drone AgroScan T-24", "AgroScan T-42 Xtreme Precision Farming Drone: Sistema Aéreo Inteligente para Agricultura 4.0 com Câmera Multiespectral 12MP, Sensor NDVI Hi-Res, Autonomia de 60 Minutos, Bateria Dupla Swappable, Alcance de 30km em Tempo Real via 5G, Sistema de Pulverização Inteligente com Tanque de 15L, Modo Automático de Varredura em Padrão Zig-Zag, Alerta de Áreas com Deficiência Nutricional, Certificação ANAC/Mapa, Suporte Técnico 24/7 e Garantia Estendida de 3 Anos - Edição Limitada Fazendas Inteligentes 2024.", 3.6m, "Drone.png", 78);
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Descrição inválida, a descrição pode ter no máximo 500 caracteres.");
        }

        #endregion

        #region Testes de avaliação

        [Fact(DisplayName = "Criar produto com avaliação menor que zero")]
        public void CriarProduto_ComAvaliacaoMenorQueZero_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Produto(1, "Drone AgroScan T-24", "Um drone de modelo simples", -3.6m, "Drone.png", 78);
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Avaliação inválida, o valor de avaliação tem ser entre 0 e 5.");
        }

        [Fact(DisplayName = "Criar produto com avaliação maior que cinco")]
        public void CriarProduto_ComAvaliacaoMaiorQueCinco_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Produto(1, "Drone AgroScan T-24", "Um drone de modelo simples", 6.2m, "Drone.png", 78);
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Avaliação inválida, o valor de avaliação tem ser entre 0 e 5.");
        }

        #endregion

        #region Testes de imagem

        [Fact(DisplayName = "Criar produto com URL de imagem muito longa")]
        public void CriarProduto_ComURLMuitoLonga_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Produto(1, "Drone AgroScan T-24", "Um drone de modelo simples", 3.6m, "drone-profissional-phantom-4-pro-v2-0-com-camera-4k-ultra-hd-estabilizador-gimbal-gps-retorno-automatico-sensor-anticolisao-bateria-longa-duracao-voo-inteligente-autonomo-controle-remoto-7km-transmissao-hd-foto-video-aereo-tecnologia-avancada-xpt123.jpg", 78);
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("URL da imagem inválida, a URL pode ter no máximo 250 caracteres.");
        }

        #endregion

        #region Testes de total de reviews

        [Fact(DisplayName = "Criar produto com total de reviews negativa")]
        public void CriarProduto_ComTotalDeReviewsNegativa_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Produto(1, "Drone AgroScan T-24", "Um drone de modelo simples", 3.6m, "Drone.png", -78);
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Valor de total de reviews inválido.");
        }

        #endregion
    }
}
