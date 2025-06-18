using Xunit;
using FluentAssertions;
using InnatAPP.Domain.Entities;

namespace InnatAPP.Domain.Tests
{
    public class CategoriaUnitTest
    {
        #region Testes de Parâmetros Válidos

        [Fact(DisplayName = "Criar categoria com estado válido")]
        public void CriarCategoria_ComParametrosValidos_ResultandoEmObjetoComEstadoValido()
        {
            Action action = () =>
            {
                var categoria = new Categoria(
                    Guid.NewGuid(),
                    "Drone"
                );
            };

            action.Should()
                .NotThrow<InnatAPP.Domain.Validation.DomainExceptionValidation>();
        }

        #endregion

        #region Testes de Parâmetros Inválidos

        #region Testes de Id

        [Fact(DisplayName = "Criar categoria com id vazio")]
        public void CriarCategoria_ComIdVazio_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var categoria = new Categoria(
                    Guid.Empty,
                    "Drone"
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O id é obrigatório.");
        }

        #endregion

        #region Testes de Nome

        [Fact(DisplayName = "Criar categoria com nome nulo")]
        public void CriarCategoria_ComNomeNulo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var categoria = new Categoria(
                    Guid.NewGuid(),
                    null
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O nome é obrigatório.");
        }

        [Fact(DisplayName = "Criar categoria com nome vazio")]
        public void CriarCategoria_ComNomeVazio_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var categoria = new Categoria(
                    Guid.NewGuid(),
                    ""
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O nome é obrigatório.");
        }

        [Fact(DisplayName = "Criar categoria com nome em branco")]
        public void CriarCategoria_ComNomeEmBranco_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var categoria = new Categoria(
                    Guid.NewGuid(),
                    "   "
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O nome é obrigatório.");
        }

        [Fact(DisplayName = "Criar categoria com espaço no início do nome")]
        public void CriarCategoria_ComEspacoNoInícioDoNome_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var categoria = new Categoria(
                    Guid.NewGuid(),
                    " Drone"
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O nome não pode começar com espaço (\" \").");
        }

        [Fact(DisplayName = "Criar categoria com espaço no final do nome")]
        public void CriarCategoria_ComEspacoNoFinalDoNome_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var categoria = new Categoria(
                    Guid.NewGuid(),
                    "Drone "
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O nome não pode terminar com espaço (\" \").");
        }

        [Fact(DisplayName = "Criar categoria com espaços consecutivos no nome")]
        public void CriarCategoria_ComEspacosConsecutivosNoNome_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var categoria = new Categoria(
                    Guid.NewGuid(),
                    "Dr  one"
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O nome não pode ter espaços consecutivos (\"  \", \"   \", \"    \" e etc).");
        }

        [Fact(DisplayName = "Criar categoria com nome muito curto")]
        public void CriarCategoria_ComNomeMuitoCurto_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var categoria = new Categoria(
                    Guid.NewGuid(),
                    "D"
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O nome deve ter no mínimo 2 caracteres.");
        }

        [Fact(DisplayName = "Criar categoria com nome muito longo")]
        public void CriarCategoria_ComNomeMuitoLongo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var categoria = new Categoria(
                    Guid.NewGuid(),
                    "Sensores e monitores de solo para agricultura de precisão"
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O nome pode ter no máximo 50 caracteres.");
        }

        #endregion

        #endregion
    }
}