using FluentAssertions;
using InnatAPP.Domain.Entities;
using Xunit;

namespace InnatAPP.Domain.Tests
{
    public class AvaliadorUnitTest
    {
        [Fact(DisplayName = "Criar avaliador com estado válido")]
        public void CreateReviewer_WithValideParameters_ResultObjectValidState()
        {
            Action action = () => new Avaliador(1, "Carlos", "Carlos.rodrigues@gmail.com", "Carlos123!", "Minhafoto.png", "Sou da área de agricultura");
            action.Should()
                .NotThrow<InnatAPP.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Criar avaliador com id inválido")]
        public void CreateReviewer_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Avaliador(-1, "Carlos", "Carlos.rodrigues@gmail.com", "Carlos123!", "Minhafoto.png", "Sou da área de agricultura");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Valor de id inválido.");
        }

        [Fact(DisplayName = "Criar avaliador com nome nulo")]
        public void CreateReviewer_WithNullNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Avaliador(1, null, "Carlos.rodrigues@gmail.com", "Carlos123!", "Minhafoto.png", "Sou da área de agricultura");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Nome inválido, o nome é obrigatório.");
        }

        [Fact(DisplayName = "Criar avaliador com nome vazio")]
        public void CreateReviewer_MissingNameValue_DomainExceptionRequiredName()
        {
            Action action = () => new Avaliador(1, "", "Carlos.rodrigues@gmail.com", "Carlos123!", "Minhafoto.png", "Sou da área de agricultura");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Nome inválido, o nome é obrigatório.");
        }

        [Fact(DisplayName = "Criar avaliador com nome muito curto")]
        public void CreateReviewer_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Avaliador(1, "C", "Carlos.rodrigues@gmail.com", "Carlos123!", "Minhafoto.png", "Sou da área de agricultura");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Nome inválido, o nome tem que ter no mínimo 2 caracteres.");
        }

        [Fact(DisplayName = "Criar avaliador com nome muito longo")]
        public void CreateReviewer_LongNameValue_DomainExceptionLongName()
        {
            Action action = () => new Avaliador(1, "Morbi leo mi, nonummy eget, tristique non, rhoncus non, leo. Nullam faucibus mi quis velit. Integer in", "Carlos.rodrigues@gmail.com", "Carlos123!", "Minhafoto.png", "Sou da área de agricultura");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Nome inválido, o nome só pode ter no máximo 100 caracteres.");
        }

        [Fact(DisplayName = "Criar avaliador com email nulo")]
        public void CreateReviewer_WithNullEmailValue_DomainExceptionInvalidEmail()
        {
            Action action = () => new Avaliador(1, "Carlos", null, "Carlos123!", "Minhafoto.png", "Sou da área de agricultura");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Email inválido, o email é obrigatório.");
        }

        [Fact(DisplayName = "Criar avaliador com email vazio")]
        public void CreateReviewer_MissingEmailValue_DomainExceptionRequiredEmail()
        {
            Action action = () => new Avaliador(1, "Carlos", "", "Carlos123!", "Minhafoto.png", "Sou da área de agricultura");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Email inválido, o email é obrigatório.");
        }

        [Fact(DisplayName = "Criar avaliador com email muito curto")]
        public void CreateReviewer_ShortEmail_DomainExceptionShortEmail()
        {
            Action action = () => new Avaliador(1, "Carlos", "C@gm", "Carlos123!", "Minhafoto.png", "Sou da área de agricultura");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Email inválido, o email tem que ter no mínimo 5 caracteres.");
        }

        [Fact(DisplayName = "Criar avaliador com email muito longo")]
        public void CreateReviewer_LongEmailValue_DomainExceptionLongEmail()
        {
            Action action = () => new Avaliador(1, "Carlos", "In sem justo, commodo ut, suscipit at, pharetra vitae, orci. Duis sapien nunc, commodo et, interdum suscipit, sollicitudin et, dolor. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Aliquam id dolor. Class aptent", "Carlos123!", "Minhafoto.png", "Sou da área de agricultura");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Email inválido, o email só pode ter no máximo 255 caracteres.");
        }

        [Fact(DisplayName = "Criar avaliador com senha nula")]
        public void CreateReviewer_WithNullPasswordValue_DomainExceptionInvalidPassword()
        {
            Action action = () => new Avaliador(1, "Carlos", "Carlos.rodrigues@gmail.com", null, "Minhafoto.png", "Sou da área de agricultura");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Senha inválida, a senha é obrigatória.");
        }

        [Fact(DisplayName = "Criar avaliador com senha vazia")]
        public void CreateReviewer_MissingPasswordValue_DomainExceptionRequiredPassword()
        {
            Action action = () => new Avaliador(1, "Carlos", "Carlos.rodrigues@gmail.com", "", "Minhafoto.png", "Sou da área de agricultura");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Senha inválida, a senha é obrigatória.");
        }

        [Fact(DisplayName = "Criar avaliador com senha muito curta")]
        public void CreateReviewer_ShortPassword_DomainExceptionShortPassword()
        {
            Action action = () => new Avaliador(1, "Carlos", "Carlos.rodrigues@gmail.com", "Senha1!", "Minhafoto.png", "Sou da área de agricultura");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Senha inválida, a senha tem que ter no mínimo 8 caracteres.");
        }

        [Fact(DisplayName = "Criar avaliador com senha muito longa")]
        public void CreateReviewer_LongPasswordValue_DomainExceptionLongPassword()
        {
            Action action = () => new Avaliador(1, "Carlos", "Carlos.rodrigues@gmail.com", "NamquisnullaIntegermalesuadaIninenimaarcuimperdietmalesuada1234!*", "Minhafoto.png", "Sou da área de agricultura");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Senha inválida, a senha só pode ter no máximo 64 caracteres.");
        }

        [Fact(DisplayName = "Criar avaliador com URL de foto muito longa")]
        public void CreateReviewer_LongImageURL_DomainExceptionLongImageURL()
        {
            Action action = () => new Avaliador(1, "Carlos", "Carlos.rodrigues@gmail.com", "Carlos123!", "Praesent in mauris eu tortor porttitor accumsan. Mauris suscipit, ligula sit amet pharetra semper, nibh ante cursus purus, vel sagittis velit mauris vel metus. Aenean fermentum risus id tortor. Integer imperdiet lectus quis justo. Integer tempor. Vivamus ac", "Sou da área de agricultura");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("URL da imagem inválida, a URL tem que ter no máximo 250 caracteres.");
        }

        [Fact(DisplayName = "Criar avaliador com bio muito longa")]
        public void CreateReviewer_LongBioValue_DomainExceptionLongBio()
        {
            Action action = () => new Avaliador(1, "Carlos", "Carlos.rodrigues@gmail.com", "Carlos123!", "Minhafoto.png", "Etiam posuere quam ac quam. Maecenas aliquet accumsan leo. Nullam dapibus fermentum ipsum. Etiam quis quam. Integer lacinia. Nulla est. Nulla turpis magna, cursus sit amet, suscipit a, interdum id, felis. Integer vulputate sem a nibh rutrum consequat. Maecenas lorem. Pellentesque pretium lectus id turpis. Etiam sapien elit, consequat eget, tristique non, venenatis quis, ante. Fusce wisi. Phasellus faucibus molestie nisl. Fusce eget urna. Curabitur vitae diam non enim vestibulum interdum. Nulla quis");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Bio inválida, a bio só pode ter no máximo 500 caracteres.");
        }
    }
}
