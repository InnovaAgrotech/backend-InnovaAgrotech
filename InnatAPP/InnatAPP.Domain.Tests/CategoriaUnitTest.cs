#region Importa��es

using Xunit;
using FluentAssertions;
using InnatAPP.Domain.Entities;

#endregion

namespace InnatAPP.Domain.Tests
{
    public class CategoriaUnitTest
    {
        #region Testes com par�metros v�lidos

        [Fact(DisplayName = "Criar categoria com estado v�lido")]
        public void CriarCategori_ComParametrosValidos_ResultandoEmObjetoComEstadoValido()
        {
            Action action = () => new Categoria(1, "Tratores");
            action.Should()
                .NotThrow<InnatAPP.Domain.Validation.DomainExceptionValidation>();
        }

        #endregion

        #region Testes de id

        [Fact(DisplayName = "Criar categoria com id negativo")]
        public void CriarCategoria_ComIdNegativo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Categoria(-1, "Tratores");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Valor de id inv�lido.");
        }

        #endregion

        #region Testes de nome

        [Fact(DisplayName = "Criar categoria com nome nulo")]
        public void CriarCategoria_ComNomeNulo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Categoria(1, null);
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Nome inv�lido, o nome � obrigat�rio.");
        }

        [Fact(DisplayName = "Criar categoria com nome vazio")]
        public void CriarCategoria_ComNomeVazio_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Categoria(1, "");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Nome inv�lido, o nome � obrigat�rio.");
        }

        [Fact(DisplayName = "Criar categoria com nome muito curto")]
        public void CriarCategoria_ComNomeMuitoCurto_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Categoria(1, "T");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Nome inv�lido, o nome deve ter no m�nimo 2 caracteres.");
        }

        [Fact(DisplayName = "Criar categoria com nome muito longo")]
        public void CriarCategoria_ComNomeMuitoLongo_ResultandoEmExcecaoDeDominio()
        {
            Action action = () => new Categoria(1, "Sensores e monitores de solo para agricultura de precis�o");
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Nome inv�lido, o nome pode ter no m�ximo 50 caracteres.");
        }

        #endregion
    }
}