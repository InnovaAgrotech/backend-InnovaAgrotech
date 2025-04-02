using FluentAssertions;
using InnatAPP.Domain.Entities;
using System.Runtime.ConstrainedExecution;
using Xunit;

namespace InnatAPP.Domain.Tests
{
    public class ProductUnityTest1
    {
        [Fact(DisplayName = "Create Product With Valid State")]
        public void CreateProduct_WithValideParameters_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Drone 24", "Um drone de modelo simples", 450.00m , 50, "Drone.png");
            action.Should()
                .NotThrow<InnatAPP.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Product With Invalid Id")]
        public void CreateProduct_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Product(-1, "Drone 24", "Um drone de modelo simples", 450.00m, 50, "Drone.png");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Valor de id inválido.");
        }

        [Fact(DisplayName = "Create Product With Name Too Short")]
        public void CreateProduct_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Product(1, "Dr", "Um drone de modelo simples", 450.00m, 50, "Drone.png");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Nome inválido, o nome tem que ter no mínimo 3 caracteres.");
        }

        [Fact(DisplayName = "Create Product With Name Value Empty")]
        public void CreateProduct_MissingNameValue_DomainExceptionRequiredName()
        {
            Action action = () => new Product(1, "", "Um drone de modelo simples", 450.00m, 50, "Drone.png");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Nome inválido, o nome é obrigatório.");
        }

        [Fact(DisplayName = "Create Product With Name Value Null")]
        public void CreateProduct_WithNullNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Product(1, null, "Um drone de modelo simples", 450.00m, 50, "Drone.png");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Nome inválido, o nome é obrigatório.");
        }

        [Fact(DisplayName = "Create Product With Description Too Short")]
        public void CreateProduct_ShortDescriptionValue_DomainExceptionShortDescription()
        {
            Action action = () => new Product(1, "Drone 24", "dron", 450.00m, 50, "Drone.png");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Descrição inválida, a descrição tem que ter no mínimo 5 caracteres.");
        }

        [Fact(DisplayName = "Create Product With Description Value Empty")]
        public void CreateProduct_MissingDescriptionValue_DomainExceptionRequiredDescription()
        {
            Action action = () => new Product(1, "Drone 24", "", 450.00m, 50, "Drone.png");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Descrição inválida, a descrição é obrigatória.");
        }

        [Fact(DisplayName = "Create Product With Description Value Null")]
        public void CreateProduct_WithNullDescriptionValue_DomainExceptionInvalidDescription()
        {
            Action action = () => new Product(1, "Drone 24", null, 450.00m, 50, "Drone.png");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Descrição inválida, a descrição é obrigatória.");
        }

        [Fact(DisplayName = "Create Product With Invalid Price Value")]
        public void CreateProduct_WithInvalidPriceValue_DomainExceptionInvalidPrice()
        {
            Action action = () => new Product(1, "Drone 24", "Um drone de modelo simples", -450.00m, 50, "Drone.png");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Valor de preço inválido.");
        }
        [Theory(DisplayName = "Create Product With Invalid Stock Value")]
        [InlineData(-50)]
        public void CreateProduct_WithInvalidStockValue_DomainExceptionNegativeValue(int value)
        {
            Action action = () => new Product(1, "Drone 24", "Um drone de modelo simples", 450.00m, value, "Drone.png");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Valor de estoque inválido.");
        }

        [Fact(DisplayName = "Create Product With Image Name Too Long")]
        public void CreateProduct_LongImageName_DomainExceptionLongImageName()
        {
            Action action = () => new Product(1, "Drone 24", "Um drone de modelo simples", 450.00m, 50, "Aenean placerat In vulputate urna eu arcu Aliquam erat volutpa Suspendisse potenti Morbi mattis felis at nunc Duis viverra diam non justo In nisl Nullam sit amet magna in magna gravida vehicula Mauris tincidunt sem sed arcu Nunc posuere Nullam lectus justo");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Nome de imagem inválida, o nome tem que ter no máximo 250 caracteres.");
        }

        [Fact(DisplayName = "Create Product With Image Name Empty")]
        public void CreateProduct_WithEmptyImageName_DomainExceptionRequiredImage()
        {
            Action action = () => new Product(1, "Drone 24", "Um drone de modelo simples", 450.00m, 50, "");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Imagem inválida, a imagem é obrigatória.");
        }

        [Fact(DisplayName = "Create Product With Image Name Null")]
        public void CreateProduct_WithNullImageName_DomainExceptionInvalidImage()
        {
            Action action = () => new Product(1, "Drone 24", "Um drone de modelo simples", 450.00m, 50, null);
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Imagem inválida, a imagem é obrigatória.");
        }

    }
}
