using FluentAssertions;
using InnatAPP.Domain.Entities;
using Xunit;

namespace InnatAPP.Domain.Tests
{
    public class EmpresaUnitTest
    {
        [Fact(DisplayName = "Criar empresa com estado válido")]
        public void CreateEnterprise_WithValideParameters_ResultObjectValidState()
        {
            Action action = () => new Empresa(1, "Empresa x", "Empresa.x@gmail.com", "Empresax123!", "EmpresaX.png", "Nossa empresa vende tratores");
            action.Should()
                .NotThrow<InnatAPP.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Criar empresa com id inválido")]
        public void CreateEnterprise_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Empresa(-1, "Empresa x", "Empresa.x@gmail.com", "Empresax123!", "EmpresaX.png", "Nossa empresa vende tratores");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Valor de id inválido.");
        }

        [Fact(DisplayName = "Criar empresa com nome nulo")]
        public void CreateEnterprise_WithNullNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Empresa(1, null, "Empresa.x@gmail.com", "Empresax123!", "EmpresaX.png", "Nossa empresa vende tratores");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Nome inválido, o nome é obrigatório.");
        }

        [Fact(DisplayName = "Criar empresa com nome vazio")]
        public void CreateEnterprise_MissingNameValue_DomainExceptionRequiredName()
        {
            Action action = () => new Empresa(1, "", "Empresa.x@gmail.com", "Empresax123!", "EmpresaX.png", "Nossa empresa vende tratores");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Nome inválido, o nome é obrigatório.");
        }

        [Fact(DisplayName = "Criar empresa com nome muito curto")]
        public void CreateEnterprise_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Empresa(1, "X", "Empresa.x@gmail.com", "Empresax123!", "EmpresaX.png", "Nossa empresa vende tratores");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Nome inválido, o nome tem que ter no mínimo 2 caracteres.");
        }

        [Fact(DisplayName = "Criar empresa com nome muito longo")]
        public void CreateEnterprise_LongNameValue_DomainExceptionLongName()
        {
            Action action = () => new Empresa(1, "Morbi leo mi, nonummy eget, tristique non, rhoncus non, leo. Nullam faucibus mi quis velit. Integer in", "Empresa.x@gmail.com", "Empresax123!", "EmpresaX.png", "Nossa empresa vende tratores");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Nome inválido, o nome só pode ter no máximo 100 caracteres.");
        }

        [Fact(DisplayName = "Criar empresa com email nulo")]
        public void CreateEnterprise_WithNullEmailValue_DomainExceptionInvalidEmail()
        {
            Action action = () => new Empresa(1, "Empresa x", null, "Empresax123!", "EmpresaX.png", "Nossa empresa vende tratores");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Email inválido, o email é obrigatório.");
        }

        [Fact(DisplayName = "Criar empresa com email vazio")]
        public void CreateEnterprise_MissingEmailValue_DomainExceptionRequiredEmail()
        {
            Action action = () => new Empresa(1, "Empresa x", "", "Empresax123!", "EmpresaX.png", "Nossa empresa vende tratores");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Email inválido, o email é obrigatório.");
        }

        [Fact(DisplayName = "Criar empresa com email muito curto")]
        public void CreateEnterprise_ShortEmail_DomainExceptionShortEmail()
        {
            Action action = () => new Empresa(1, "Empresa x", "x@gm", "Empresax123!", "EmpresaX.png", "Nossa empresa vende tratores");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Email inválido, o email tem que ter no mínimo 5 caracteres.");
        }

        [Fact(DisplayName = "Criar empresa com email muito longo")]
        public void CreateEnterprise_LongEmailValue_DomainExceptionLongEmail()
        {
            Action action = () => new Empresa(1, "Empresa x", "In sem justo, commodo ut, suscipit at, pharetra vitae, orci. Duis sapien nunc, commodo et, interdum suscipit, sollicitudin et, dolor. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Aliquam id dolor. Class aptent", "Empresax123!", "EmpresaX.png", "Nossa empresa vende tratores");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Email inválido, o email só pode ter no máximo 255 caracteres.");
        }

        [Fact(DisplayName = "Criar empresa com senha nula")]
        public void CreateEnterprise_WithNullPasswordValue_DomainExceptionInvalidPassword()
        {
            Action action = () => new Empresa(1, "Empresa x", "Empresa.x@gmail.com", null, "EmpresaX.png", "Nossa empresa vende tratores");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Senha inválida, a senha é obrigatória.");
        }

        [Fact(DisplayName = "Criar empresa com senha vazia")]
        public void CreateEnterprise_MissingPasswordValue_DomainExceptionRequiredPassword()
        {
            Action action = () => new Empresa(1, "Empresa x", "Empresa.x@gmail.com", "", "EmpresaX.png", "Nossa empresa vende tratores");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Senha inválida, a senha é obrigatória.");
        }

        [Fact(DisplayName = "Criar empresa com senha muito curta")]
        public void CreateEnterprise_ShortPassword_DomainExceptionShortPassword()
        {
            Action action = () => new Empresa(1, "Empresa x", "Empresa.x@gmail.com", "Emprx3!", "EmpresaX.png", "Nossa empresa vende tratores");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Senha inválida, a senha tem que ter no mínimo 8 caracteres.");
        }

        [Fact(DisplayName = "Criar empresa com senha muito longa")]
        public void CreateEnterprise_LongPasswordValue_DomainExceptionLongPassword()
        {
            Action action = () => new Empresa(1, "Empresa x", "Empresa.x@gmail.com", "NamquisnullaIntegermalesuadaIninenimaarcuimperdietmalesuada1234!*", "EmpresaX.png", "Nossa empresa vende tratores");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Senha inválida, a senha só pode ter no máximo 64 caracteres.");
        }

        [Fact(DisplayName = "Criar empresa com URL de foto muito longa")]
        public void CreateEnterprise_LongImageURL_DomainExceptionLongImageURL()
        {
            Action action = () => new Empresa(1, "Empresa x", "Empresa.x@gmail.com", "Empresax123!", "Praesent in mauris eu tortor porttitor accumsan. Mauris suscipit, ligula sit amet pharetra semper, nibh ante cursus purus, vel sagittis velit mauris vel metus. Aenean fermentum risus id tortor. Integer imperdiet lectus quis justo. Integer tempor. Vivamus ac", "Nossa empresa vende tratores");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("URL da imagem inválida, a URL tem que ter no máximo 250 caracteres.");
        }

        [Fact(DisplayName = "Criar empresa com bio muito longa")]
        public void CreateEnterprise_LongBioValue_DomainExceptionLongBio()
        {
            Action action = () => new Empresa(1, "Empresa x", "Empresa.x@gmail.com", "Empresax123!", "EmpresaX.png", "Etiam posuere quam ac quam. Maecenas aliquet accumsan leo. Nullam dapibus fermentum ipsum. Etiam quis quam. Integer lacinia. Nulla est. Nulla turpis magna, cursus sit amet, suscipit a, interdum id, felis. Integer vulputate sem a nibh rutrum consequat. Maecenas lorem. Pellentesque pretium lectus id turpis. Etiam sapien elit, consequat eget, tristique non, venenatis quis, ante. Fusce wisi. Phasellus faucibus molestie nisl. Fusce eget urna. Curabitur vitae diam non enim vestibulum interdum. Nulla quis");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Bio inválida, a bio só pode ter no máximo 500 caracteres.");
        }

    }
}
