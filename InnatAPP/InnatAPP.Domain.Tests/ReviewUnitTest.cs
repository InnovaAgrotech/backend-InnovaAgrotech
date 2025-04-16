#region Importações

using Xunit;
using FluentAssertions;
using InnatAPP.Domain.Entities;

#endregion

namespace InnatAPP.Domain.Tests
{
    public class ReviewUnitTest
    {
        #region Testes de parâmetros válidos

        [Fact(DisplayName = "Criar review com estado válido")]
        public void CriarReview_ComParametrosValidos_ResultandoEmObjetoComEstadoValido()
        {
            Action action = () => new Review(1, 2, "Produto ótimo, adorei!", DateTime.UtcNow, DateTime.UtcNow, 12, 57, 4.8m);
            action.Should()
                .NotThrow<InnatAPP.Domain.Validation.DomainExceptionValidation>();
        }

        #endregion

        #region Testes de id

        [Fact(DisplayName = "Criar review com id negativo")]
        public void CriarReview_ComIdNegativo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Review(-1, 2, "Produto ótimo, adorei!", DateTime.UtcNow, DateTime.UtcNow, 12, 57, 4.8m);
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Valor de id inválido.");
        }

        #endregion

        #region Testes de satisfação

        [Fact(DisplayName = "Criar review com satisfação menor que zero")]
        public void CriarReview_ComSatisfacaoMenorQueZero_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Review(1, -2, "Produto ótimo, adorei!", DateTime.UtcNow, DateTime.UtcNow, 12, 57, 4.8m);
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Satisfação inválida, a satisfação deve estar entre 0 e 2.");
        }

        [Fact(DisplayName = "Criar review com satisfação maior que dois")]
        public void CriarReview_ComSatisfacaoMaiorQueDuas_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Review(1, 3, "Produto ótimo, adorei!", DateTime.UtcNow, DateTime.UtcNow, 12, 57, 4.8m);
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Satisfação inválida, a satisfação deve estar entre 0 e 2.");
        }

        #endregion

        #region Testes de mensagem

        [Fact(DisplayName = "Criar review com mensagem muito curta")]
        public void CriarReview_ComMensagemMuitoCurta_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Review(1, 2, "Ok", DateTime.UtcNow, DateTime.UtcNow, 12, 57, 4.8m);
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Mensagem inválida, a mensagem deve ter no mínimo 5 caracteres.");
        }

        [Fact(DisplayName = "Criar review com mensagem muito longa")]
        public void CriarReview_ComMensagemMuitoLonga_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Review(1, 2, "Aenean placerat. In vulputate urna eu arcu. Aliquam erat volutpat. Suspendisse potenti. Morbi mattis felis at nunc. Duis viverra diam non justo. In nisl. Nullam sit amet magna in magna gravida vehicula. Mauris tincidunt sem sed arcu. Nunc posuere. Nullam lectus justo, vulputate eget, mollis sed, tempor sed, magna. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Etiam neque. Curabitur ligula sapien, pulvinar a, vestibulum quis, facilisis vel, sapien. Nullam eget, Nullam lectus justo, vulputate eget, mollis sed, tempor sed, magna. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Etiam neque.", DateTime.UtcNow, DateTime.UtcNow, 12, 57, 4.8m);
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Mensagem inválida, a mensagem pode ter no máximo 500 caracteres.");
        }

        #endregion

        #region Testes de likes

        [Fact(DisplayName = "Criar review com número de likes negativo")]
        public void CriarReview_ComNumeroDeLikesNegativo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Review(1, 2, "Produto ótimo, adorei!", DateTime.UtcNow, DateTime.UtcNow, -12, 57, 4.8m);
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Valor de likes inválido.");
        }

        #endregion

        #region Testes de dislikes

        [Fact(DisplayName = "Criar review com número de dislikes negativos")]
        public void CriarReview_ComNumeroDeDislikesNegativo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Review(1, 2, "Produto ótimo, adorei!", DateTime.UtcNow, DateTime.UtcNow, 12, -57, 4.8m);
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Valor de dislikes inválido.");
        }

        #endregion

        #region Testes de avalição

        [Fact(DisplayName = "Criar review com avaliação menor que zero")]
        public void CriarReview_ComAvalicaoMenorQueZero_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Review(1, 2, "Produto ótimo, adorei!", DateTime.UtcNow, DateTime.UtcNow, 12, 57, -1.2m);
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Avaliação inválida, a avaliação deve estar entre 0 e 5.");
        }

        [Fact(DisplayName = "Criar review com avaliação maior que cinco")]
        public void CriarReview_ComAvalicaoMaiorQueCinco_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Review(1, 2, "Produto ótimo, adorei!", DateTime.UtcNow, DateTime.UtcNow, 12, 57, 6.7m);
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Avaliação inválida, a avaliação deve estar entre 0 e 5.");
        }

        #endregion
    }
}
