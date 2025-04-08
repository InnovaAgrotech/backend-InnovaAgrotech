using FluentAssertions;
using InnatAPP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace InnatAPP.Domain.Tests
{
    public class MensagemUnitTest
    {
        [Fact(DisplayName = "Criar mensagem com estado válido")]
        public void CreateMessage_WithValideParameters_ResultObjectValidState()
        {
            Action action = () => new Mensagem(1, "Roberta", "Roberta.souza.@outlook.com", "Minha experiência com o site foi ótima!");
            action.Should()
                .NotThrow<InnatAPP.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Criar mensagem com id inválido")]
        public void CreateMessage_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Mensagem(-1, "Roberta", "Roberta.souza.@outlook.com", "Minha experiência com o site foi ótima!");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Valor de id inválido.");
        }

        [Fact(DisplayName = "Criar mensagem com nome nulo")]
        public void CreateMessage_WithNullNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Mensagem(1, null, "Roberta.souza.@outlook.com", "Minha experiência com o site foi ótima!");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Nome inválido, o nome é obrigatório.");
        }

        [Fact(DisplayName = "Criar mensagem com nome vazio")]
        public void CreateMessage_MissingNameValue_DomainExceptionRequiredName()
        {
            Action action = () => new Mensagem(1, "", "Roberta.souza.@outlook.com", "Minha experiência com o site foi ótima!");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Nome inválido, o nome é obrigatório.");
        }

        [Fact(DisplayName = "Criar mensagem com nome muito curto")]
        public void CreateMessage_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Mensagem(1, "Ro", "Roberta.souza.@outlook.com", "Minha experiência com o site foi ótima!");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Nome inválido, o nome tem que ter no mínimo 3 caracteres.");
        }

        [Fact(DisplayName = "Criar mensagem com nome muito longo")]
        public void CreateMessage_LongNameValue_DomainExceptionLongName()
        {
            Action action = () => new Mensagem(1, "Morbi leo mi, nonummy eget, tristique non, rhoncus non, leo. Nullam faucibus mi quis velit. Integer in", "Roberta.souza.@outlook.com", "Minha experiência com o site foi ótima!");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Nome inválido, o nome só pode ter no máximo 100 caracteres.");
        }

        [Fact(DisplayName = "Criar mensagem com email nulo")]
        public void CreateMessage_WithNullEmailValue_DomainExceptionInvalidEmail()
        {
            Action action = () => new Mensagem(1, "Roberta", null, "Minha experiência com o site foi ótima!");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Email inválido, o email é obrigatório.");
        }

        [Fact(DisplayName = "Criar mensagem com email vazio")]
        public void CreateMessage_MissingEmailValue_DomainExceptionRequiredEmail()
        {
            Action action = () => new Mensagem(1, "Roberta", "", "Minha experiência com o site foi ótima!");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Email inválido, o email é obrigatório.");
        }

        [Fact(DisplayName = "Criar mensagem com email muito curto")]
        public void CreateMessage_ShortEmail_DomainExceptionShortEmail()
        {
            Action action = () => new Mensagem(1, "Roberta", "r@ol", "Minha experiência com o site foi ótima!");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Email inválido, o email tem que ter no mínimo 5 caracteres.");
        }

        [Fact(DisplayName = "Criar mensagem com email muito longo")]
        public void CreateMessage_LongEmailValue_DomainExceptionLongEmail()
        {
            Action action = () => new Mensagem(1, "Roberta", "In sem justo, commodo ut, suscipit at, pharetra vitae, orci. Duis sapien nunc, commodo et, interdum suscipit, sollicitudin et, dolor. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Aliquam id dolor. Class aptent", "Minha experiência com o site foi ótima!");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Email inválido, o email só pode ter no máximo 255 caracteres.");
        }

        [Fact(DisplayName = "Criar mensagem com texto nulo")]
        public void CreateMessage_WithNullPasswordValue_DomainExceptionInvalidPassword()
        {
            Action action = () => new Mensagem(1, "Roberta", "Roberta.souza.@outlook.com", null);
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Mensagem inválida, a mensagem é obrigatória.");
        }

        [Fact(DisplayName = "Criar mensagem com texto nulo")]
        public void CreateMessage_MissingPasswordValue_DomainExceptionRequiredPassword()
        {
            Action action = () => new Mensagem(1, "Roberta", "Roberta.souza.@outlook.com", "");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Mensagem inválida, a mensagem é obrigatória.");
        }

        [Fact(DisplayName = "Criar mensagem com texto muito curto")]
        public void CreateMessage_ShortPassword_DomainExceptionShortPassword()
        {
            Action action = () => new Mensagem(1, "Roberta", "Roberta.souza.@outlook.com", "Ótimo");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Mensagem inválida, a mensagem tem que ter no mínimo 10 caracteres.");
        }

        [Fact(DisplayName = "Criar mensagem com texto muito longo")]
        public void CreateMessage_LongPasswordValue_DomainExceptionLongPassword()
        {
            Action action = () => new Mensagem(1, "Roberta", "Roberta.souza.@outlook.com", "Etiam posuere quam ac quam. Maecenas aliquet accumsan leo. Nullam dapibus fermentum ipsum. Etiam quis quam. Integer lacinia. Nulla est. Nulla turpis magna, cursus sit amet, suscipit a, interdum id, felis. Integer vulputate sem a nibh rutrum consequat. Maecenas lorem. Pellentesque pretium lectus id turpis. Etiam sapien elit, consequat eget, tristique non, venenatis quis, ante. Fusce wisi. Phasellus faucibus molestie nisl. Fusce eget urna. Curabitur vitae diam non enim vestibulum interdum. Nulla quis diam. Ut tempus purus at lorem. Praesent in mauris eu tortor porttitor accumsan. Mauris suscipit, ligula sit amet pharetra semper, nibh ante cursus purus, vel sagittis velit mauris vel metus. Aenean fermentum risus id tortor. Integer imperdiet lectus quis justo. Integer tempor. Vivamus ac urna vel leo pretium faucibus. Mauris elementum mauris vitae tortor. In dapibus augue non sapien. Aliquam ante. Curabitur bibendum justo non orci.\r\n\r\n Etiam posuere quam ac quam. Maecenas aliquet accumsan leo. Nullam");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Mensagem inválida, a mensagem só pode ter no máximo 1000 caracteres.");
        }
    }
}
