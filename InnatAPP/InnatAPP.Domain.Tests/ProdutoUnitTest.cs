using FluentAssertions;
using InnatAPP.Domain.Entities;
using Xunit;

namespace InnatAPP.Domain.Tests
{
    public class ProdutoUnitTest
    {
        [Fact(DisplayName = "Criar produto com estado válido")]
        public void CreateProduct_WithValideParameters_ResultObjectValidState()
        {
            Action action = () => new Produto(1, "Drone 24", "Um drone de modelo simples", 3.6m, "Drone.png", 78);
            action.Should()
                .NotThrow<InnatAPP.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Criar produto com id inválido")]
        public void CreateProduct_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Produto(-1, "Drone 24", "Um drone de modelo simples", 3.6m, "Drone.png", 78);
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Valor de id inválido.");
        }

        [Fact(DisplayName = "Criar produto com nome nulo")]
        public void CreateProduct_WithNullNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Produto(1, null, "Um drone de modelo simples", 3.6m, "Drone.png", 78);
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Nome inválido, o nome é obrigatório.");
        }

        [Fact(DisplayName = "Criar produto com nome vazio")]
        public void CreateProduct_MissingNameValue_DomainExceptionRequiredName()
        {
            Action action = () => new Produto(1, "", "Um drone de modelo simples", 3.6m, "Drone.png", 78);
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Nome inválido, o nome é obrigatório.");
        }

        [Fact(DisplayName = "Criar produto com nome muito curto")]
        public void CreateProduct_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Produto(1, "Dr", "Um drone de modelo simples", 3.6m, "Drone.png", 78);
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Nome inválido, o nome tem que ter no mínimo 3 caracteres.");
        }

        [Fact(DisplayName = "Criar produto com nome muito longo")]
        public void CreateProduct_LongNameValue_DomainExceptionLongName()
        {
            Action action = () => new Produto(1, "Nam quis nulla. Integer malesuada. In in enim a arcu imperdiet malesuada. Sed vel lectus. Donec odio urna,", "Um drone de modelo simples", 3.6m, "Drone.png", 78);
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Nome inválido, o nome só pode ter no máximo 100 caracteres.");
        }

        [Fact(DisplayName = "Criar produto com descrição nula")]
        public void CreateProduct_WithNullDescriptionValue_DomainExceptionInvalidDescription()
        {
            Action action = () => new Produto(1, "Drone 24", null, 3.6m, "Drone.png", 78);
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Descrição inválida, a descrição é obrigatória.");
        }

        [Fact(DisplayName = "Criar produto com descrição vazia")]
        public void CreateProduct_MissingDescriptionValue_DomainExceptionRequiredDescription()
        {
            Action action = () => new Produto(1, "Drone 24", "", 3.6m, "Drone.png", 78);
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Descrição inválida, a descrição é obrigatória.");
        }

        [Fact(DisplayName = "Criar produto com descrição muito curta")]
        public void CreateProduct_ShortDescription_DomainExceptionShortDescription()
        {
            Action action = () => new Produto(1, "Drone 24", "Um drone", 3.6m, "Drone.png", 78);
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Descrição inválida, a descrição tem que ter no mínimo 10 caracteres.");
        }

        [Fact(DisplayName = "Criar produto com descrição muito longa")]
        public void CreateProduct_LongDescriptionValue_DomainExceptionLongDescription()
        {
            Action action = () => new Produto(1, "Drone 24", "Aenean placerat. In vulputate urna eu arcu. Aliquam erat volutpat. Suspendisse potenti. Morbi mattis felis at nunc. Duis viverra diam non justo. In nisl. Nullam sit amet magna in magna gravida vehicula. Mauris tincidunt sem sed arcu. Nunc posuere. Nullam lectus justo, vulputate eget, mollis sed, tempor sed, magna. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Etiam neque. Curabitur ligula sapien, pulvinar a, vestibulum quis, facilisis vel, sapien. Nullam eget", 3.6m, "Drone.png", 78);
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Descrição inválida, a descrição só pode ter no máximo 500 caracteres.");
        }

        [Fact(DisplayName = "Criar produto com valor de avaliação menor que zero")]
        public void CreateProduct_WithBellowZeroRatingValue_DomainExceptionInvalidRating()
        {
            Action action = () => new Produto(1, "Drone 24", "Um drone de modelo simples", -4.7m, "Drone.png", 78);
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Avaliação inválida, o valor de avaliação tem ser entre 0 e 5.");
        }

        [Fact(DisplayName = "Criar produto com valor de avaliação maior que cinco")]
        public void CreateProduct_WithAboveFiveRatingValue_DomainExceptionInvalidRating()
        {
            Action action = () => new Produto(1, "Drone 24", "Um drone de modelo simples", 6.2m, "Drone.png", 78);
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Avaliação inválida, o valor de avaliação tem ser entre 0 e 5.");
        }

        [Fact(DisplayName = "Criar produto com URL de imagem muito longa")]
        public void CreateProduct_LongImageURL_DomainExceptionLongImageURL()
        {
            Action action = () => new Produto(1, "Drone 24", "Um drone de modelo simples", 3.6m, "Aenean placerat. In vulputate urna eu arcu. Aliquam erat volutpat. Suspendisse potenti. Morbi mattis felis at nunc. Duis viverra diam non justo. In nisl. Nullam sit amet magna in magna gravida vehicula. Mauris tincidunt sem sed arcu. Nunc posuere. Nullam", 78);
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("URL da imagem inválida, a URL tem que ter no máximo 250 caracteres.");
        }

        [Fact(DisplayName = "Criar produto com total de reviews inválida")]
        public void CreateProduct_NegativeTotalReviewsValue_DomainExceptionInvalidTotalReviews()
        {
            Action action = () => new Produto(1, "Drone 24", "Um drone de modelo simples", 3.6m, "Drone.png", -20);
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Valor de total de reviews inválido.");
        }
    }
}
