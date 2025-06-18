using Xunit;
using FluentAssertions;
using InnatAPP.Domain.Entities;

namespace InnatAPP.Domain.Tests
{
    public class AvaliadorUnitTest
    {
        #region Testes de Parâmetros Válidos

        [Fact(DisplayName = "Criar avaliador com estado válido")]
        public void CriarAvaliador_ComParametrosValidos_ResultandoEmObjetoComEstadoValido()
        {
            Action action = () =>
            {
                var avaliador = new Avaliador(
                    Guid.NewGuid(),
                    Guid.NewGuid()
                );
            };

            action.Should()
                .NotThrow<InnatAPP.Domain.Validation.DomainExceptionValidation>();
        }

        #endregion

        #region Testes de Parâmetros Inválidos

        #region Testes de Id

        [Fact(DisplayName = "Criar avaliador com id vazio")]
        public void CriarAvaliador_ComIdVazio_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var avaliador = new Avaliador(
                    Guid.Empty,
                    Guid.NewGuid()
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O id é obrigatório.");
        }

        #endregion

        #region Testes de Id de Usuario

        [Fact(DisplayName = "Criar avaliador com id de usuário vazio")]
        public void CriarAvaliador_ComIdDeUsuarioVazio_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var avaliador = new Avaliador(
                    Guid.NewGuid(),
                    Guid.Empty
                );
            };
            action.Should()
                .Throw<InnatAPP.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O id de usuário é obrigatório.");
        }

        #endregion

        #endregion
    }
}