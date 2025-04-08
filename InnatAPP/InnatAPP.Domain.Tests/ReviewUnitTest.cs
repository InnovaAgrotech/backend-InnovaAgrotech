using FluentAssertions;
using InnatAPP.Domain.Entities;
using Xunit;

namespace InnatAPP.Domain.Tests
{
    public class ReviewUnitTest
    {
        [Fact(DisplayName = "Criar review com estado válido")]
        public void CreateReview_WithValideParameters_ResultObjectValidState()
        {
            Action action = () => new Review(1, 2, "Produto ótimo, adorei!", DateTime.UtcNow, DateTime.UtcNow, 12, 57, 4.8m);
            action.Should()
                .NotThrow<InnatAPP.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Criar review com id inválido")]
        public void CreateReview_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Review(-1, 2, "Produto ótimo, adorei!", DateTime.UtcNow, DateTime.UtcNow, 12, 57, 4.8m);
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Valor de id inválido.");
        }

        [Fact(DisplayName = "Criar review com valor de satisfação menor que zero")]
        public void CreateReview_WithBellowZeroSatisfactionValue_DomainExceptionInvalidSatisfaction()
        {
            Action action = () => new Review(1, -2, "Produto ótimo, adorei!", DateTime.UtcNow, DateTime.UtcNow, 12, 57, 4.8m);
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Satisfação inválida, o valor de satisfação tem que ser entre 0 e 2.");
        }

        [Fact(DisplayName = "Criar review com valor de satisfação maior que dois")]
        public void CreateReview_WithAboveTwoSatisfactionValue_DomainExceptionInvalidSatisfaction()
        {
            Action action = () => new Review(1, 3, "Produto ótimo, adorei!", DateTime.UtcNow, DateTime.UtcNow, 12, 57, 4.8m);
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Satisfação inválida, o valor de satisfação tem que ser entre 0 e 2.");
        }

        [Fact(DisplayName = "Criar Review com mensagem muito longa")]
        public void CreateReview_LongMessageValue_DomainExceptionLongMessage()
        {
            Action action = () => new Review(1, 2, "Aenean placerat. In vulputate urna eu arcu. Aliquam erat volutpat. Suspendisse potenti. Morbi mattis felis at nunc. Duis viverra diam non justo. In nisl. Nullam sit amet magna in magna gravida vehicula. Mauris tincidunt sem sed arcu. Nunc posuere. Nullam lectus justo, vulputate eget, mollis sed, tempor sed, magna. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Etiam neque. Curabitur ligula sapien, pulvinar a, vestibulum quis, facilisis vel, sapien. Nullam eget, Nullam lectus justo, vulputate eget, mollis sed, tempor sed, magna. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Etiam neque.", DateTime.UtcNow, DateTime.UtcNow, 12, 57, 4.8m);
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("mensagem inválida, a mensagem só pode ter no máximo 500 caracteres.");
        }

        [Fact(DisplayName = "Criar review com número de likes inválido")]
        public void CreateReview_NegativeLikesValue_DomainExceptionInvalidLikes()
        {
            Action action = () => new Review(1, 2, "Produto ótimo, adorei!", DateTime.UtcNow, DateTime.UtcNow, -12, 57, 4.8m);
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Valor de likes inválido.");
        }

        [Fact(DisplayName = "Criar review com número de dislikes inválido")]
        public void CreateReview_NegativeDislikesValue_DomainExceptionInvalidDislikes()
        {
            Action action = () => new Review(1, 2, "Produto ótimo, adorei!", DateTime.UtcNow, DateTime.UtcNow, 12, -57, 4.8m);
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Valor de dislikes inválido.");
        }

        [Fact(DisplayName = "Criar review com valor de avaliação menor que zero")]
        public void CreateReview_WithBellowZeroRatingValue_DomainExceptionInvalidRating()
        {
            Action action = () => new Review(1, 2, "Produto ótimo, adorei!", DateTime.UtcNow, DateTime.UtcNow, 12, 57, -1.2m);
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Avaliação inválida, o valor de avaliação tem ser entre 0 e 5.");
        }

        [Fact(DisplayName = "Criar review com valor de avaliação maior que cinco")]
        public void CreateReview_WithAboveFiveRatingValue_DomainExceptionInvalidRating()
        {
            Action action = () => new Review(1, 2, "Produto ótimo, adorei!", DateTime.UtcNow, DateTime.UtcNow, 12, 57, 6.7m);
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Avaliação inválida, o valor de avaliação tem ser entre 0 e 5.");
        }
    }
}
