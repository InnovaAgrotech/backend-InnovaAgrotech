using FluentAssertions;
using InnatAPP.Domain.Entities;
using Xunit;

namespace InnatAPP.Domain.Tests
{
    public class CategoriaUnitTest
    {
        [Fact(DisplayName = "Criar categoria com estado válido")]
        public void CreateCategory_WithValideParameters_ResultObjectValidState()
        {
            Action action = () => new Categoria(1, "Tratores");
            action.Should()
                .NotThrow<InnatAPP.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Criar categoria com id inválido")]
        public void CreateCategory_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Categoria(-1, "Tratores");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Valor de id inválido.");
        }

        [Fact(DisplayName = "Criar categoria com nome nulo")]
        public void CreateCategory_WithNullNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Categoria(1, null);
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Nome inválido, o nome é obrigatório.");
        }

        [Fact(DisplayName = "Criar categoria com nome vazio")]
        public void CreateCategory_MissingNameValue_DomainExceptionRequiredName()
        {
            Action action = () => new Categoria(1, "");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Nome inválido, o nome é obrigatório.");
        }

        [Fact(DisplayName = "Criar categoria com nome muito curto")]
        public void CreateCategory_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Categoria(1, "D");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Nome inválido, o nome tem que ter no mínimo 2 caracteres.");
        }

        [Fact(DisplayName = "Criar categoria com nome muito longo")]
        public void CreateCategory_LongNameValue_DomainExceptionLongName()
        {
            Action action = () => new Categoria(1, "Etiam posuere quam ac quam. Maecenas aliquet accumsan");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Nome inválido, o nome só pode ter no máximo 50 caracteres.");
        }
    }
}