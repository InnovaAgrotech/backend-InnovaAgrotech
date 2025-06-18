using InnatAPP.Domain.Validation;

namespace InnatAPP.Domain.Entities
{
    public class Empresa
    {
        #region Propriedades

        public Guid Id { get; private set; }

        #endregion

        #region Chaves Estrangeiras

        public Guid IdUsuario { get; private set; }

        #endregion

        #region Propriedades de Navegação

        public Usuario Usuario { get; private set; } = null!;

        #endregion

        #region Coleções

        public ICollection<Produto> Produtos { get; private set; } = new List<Produto>();

        #endregion

        #region Construtores

        public Empresa() { }

        public Empresa(Guid idUsuario)
        {
            #region Validações de Entrada

            DomainExceptionValidation.When(idUsuario == Guid.Empty, "O id de usuário é obrigatório.");

            #endregion

            #region Inicialização das Propriedades

            Id = Guid.NewGuid();
            IdUsuario = idUsuario;

            #endregion
        }

        public Empresa(Guid id, Guid idUsuario)
        {
            #region Validações de Entrada

            DomainExceptionValidation.When(id == Guid.Empty, "O id é obrigatório.");

            DomainExceptionValidation.When(idUsuario == Guid.Empty, "O id de usuário é obrigatório.");

            #endregion

            #region Inicialização das Propriedades

            Id = id;
            IdUsuario = idUsuario;

            #endregion
        }

        #endregion
    }
}