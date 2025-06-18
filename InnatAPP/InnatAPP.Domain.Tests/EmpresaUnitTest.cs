using Xunit;
using FluentAssertions;
using InnatAPP.Domain.Entities;

namespace InnatAPP.Domain.Tests
{
    public class EmpresaUnitTest
    {
        #region Testes de Parâmetros Válidos

        [Fact(DisplayName = "Criar empresa com estado válido")]
        public void CriarEmpresa_ComParametrosValidos_ResultandoEmObjetoComEstadoValido()
        {
            Action action = () =>
            {
                var empresa = new Empresa(
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

        [Fact(DisplayName = "Criar empresa com id vazio")]
        public void CriarEmpresa_ComIdVazio_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var empresa = new Empresa(
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

        [Fact(DisplayName = "Criar empresa com id de usuário vazio")]
        public void CriarEmpresa_ComIdDeUsuarioVazio_ResultandoEmExcecaoDeDominio()
        {
            Action action = () =>
            {
                var empresa = new Empresa(
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