using Xunit;
using FluentAssertions;
using InnatAPP.Domain.Entities;

namespace InnatAPP.Domain.Tests
{
    public class ReviewUnitTest
    {
        #region Testes de Parâmetros Válidos

        [Fact(DisplayName = "Criar review com estado válido")]
        public void CriarReview_ComParametrosValidos_ResultandoEmObjetoComEstadoValido()
        {
            Action action = () =>
            {
                var review = new Review(
                    Guid.NewGuid(),
                    4.8m, 
                    "Produto ótimo, adorei!", 
                    DateTime.UtcNow, 
                    DateTime.UtcNow, 
                    57, 
                    12,
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

        [Fact(DisplayName = "Criar review com id vazio")]
        public void CriarReview_ComIdVazio_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var review = new Review(
                    Guid.Empty,
                    4.8m,
                    "Produto ótimo, adorei!",
                    DateTime.UtcNow,
                    DateTime.UtcNow,
                    57,
                    12,
                    Guid.NewGuid(),
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O id é obrigatório.");
        }

        #endregion

        #region Testes de Id de Avaliador

        [Fact(DisplayName = "Criar review com id de avaliador vazio")]
        public void CriarReview_ComIdDeAvaliadorVazio_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var review = new Review(
                    Guid.NewGuid(),
                    4.8m,
                    "Produto ótimo, adorei!",
                    DateTime.UtcNow,
                    DateTime.UtcNow,
                    57,
                    12,
                    Guid.Empty,
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O id de avaliador é obrigatório.");
        }

        #endregion

        #region Testes de Id de Produto

        [Fact(DisplayName = "Criar review com id de produto vazio")]
        public void CriarReview_ComIdDeProdutoVazio_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var review = new Review(
                    Guid.NewGuid(),
                    4.8m,
                    "Produto ótimo, adorei!",
                    DateTime.UtcNow,
                    DateTime.UtcNow,
                    57,
                    12,
                    Guid.NewGuid(),
                    Guid.Empty
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O id de produto é obrigatório.");
        }

        #endregion

        #region Testes de Nota

        [Fact(DisplayName = "Criar review com valor de nota menor que 0")]
        public void CriarReview_ComValorDeNotaMenorQueZero_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var review = new Review(
                    Guid.NewGuid(),
                    -4.8m,
                    "Produto ótimo, adorei!",
                    DateTime.UtcNow,
                    DateTime.UtcNow,
                    57,
                    12,
                    Guid.NewGuid(),
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("A nota não pode ser menor que zero (0).");
        }

        [Fact(DisplayName = "Criar review com valor de nota maior que 5")]
        public void CriarReview_ComValorDeNotaMaiorQueCinco_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var review = new Review(
                    Guid.NewGuid(),
                    6.0m,
                    "Produto ótimo, adorei!",
                    DateTime.UtcNow,
                    DateTime.UtcNow,
                    57,
                    12,
                    Guid.NewGuid(),
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("A nota não pode ser maior que cinco (5).");
        }

        #endregion

        #region Testes de Resenha

        [Fact(DisplayName = "Criar review com resenha muito curta")]
        public void CriarReview_ComResenhaMuitoCurta_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var review = new Review(
                    Guid.NewGuid(),
                    4.8m,
                    "Bom",
                    DateTime.UtcNow,
                    DateTime.UtcNow,
                    57,
                    12,
                    Guid.NewGuid(),
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("A resenha deve ter no mínimo 5 caracteres.");
        }

        [Fact(DisplayName = "Criar review com resenha muito longa")]
        public void CriarReview_ComResenhaMuitoLonga_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var review = new Review(
                    Guid.NewGuid(),
                    4.8m,
                    "Comprei o Drone AgroScan T-24 para usar na fazenda e fiquei muito satisfeito. Ele tem excelente autonomia, cobre grandes áreas com precisão e a qualidade dos sensores é impressionante. A pulverização é uniforme e economiza produto, além de agilizar muito o trabalho no campo. A conexão com o app é estável e fácil de usar, mesmo para quem não tem tanta experiência com tecnologia. Achei a estrutura resistente e o voo super estável, mesmo com vento. Vale cada centavo, recomendo muito pra quem quer mais eficiência na lavoura.",
                    DateTime.UtcNow,
                    DateTime.UtcNow,
                    57,
                    12,
                    Guid.NewGuid(),
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("A resenha pode ter no máximo 500 caracteres.");
        }

        #endregion

        #region Testes de Curtidas

        [Fact(DisplayName = "Criar review com valor total de curtidas menor que 0")]
        public void CriarReview_ComValorTotalDeCurtidasMenorQueZero_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var review = new Review(
                    Guid.NewGuid(),
                    4.8m,
                    "Produto ótimo, adorei!",
                    DateTime.UtcNow,
                    DateTime.UtcNow,
                    -57,
                    12,
                    Guid.NewGuid(),
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O número de curtidas não pode ser menor que zero (0).");
        }

        #endregion

        #region Testes de Descurtidas

        [Fact(DisplayName = "Criar review com valor total de descurtidas menor que 0")]
        public void CriarReview_ComValorTotalDeDescurtidasMenorQueZero_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var review = new Review(
                    Guid.NewGuid(),
                    4.8m,
                    "Produto ótimo, adorei!",
                    DateTime.UtcNow,
                    DateTime.UtcNow,
                    57,
                    -12,
                    Guid.NewGuid(),
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O número de descurtidas não pode ser menor que zero (0).");
        }

        #endregion

        #endregion
    }
}