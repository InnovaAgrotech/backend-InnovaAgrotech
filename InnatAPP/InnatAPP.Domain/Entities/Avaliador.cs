using Google.Cloud.Firestore;
using InnatAPP.Domain.Validation;

namespace InnatAPP.Domain.Entities
{
    public class Avaliador
    {
        #region Propriedades

        public Guid Id { get; set; }

        #endregion

        #region Chaves Estrangeiras

        public Guid IdUsuario { get; set; }

        #endregion

        #region Propriedades de Navegação

        public Usuario Usuario { get; set; } = null!;

        #endregion

        #region Coleções

        public ICollection<Review> Reviews { get; private set; } = new List<Review>();

        #endregion

        #region Construtores

        public Avaliador() { }

        public Avaliador(Guid idUsuario)
        {
            #region Validações de Entrada

            DomainExceptionValidation.When(idUsuario == Guid.Empty, "O id de usuário é obrigatório.");

            #endregion

            #region Inicialização das Propriedades

            Id = idUsuario;
            IdUsuario = idUsuario;

            #endregion
        }

        public Avaliador(Guid id, Guid idUsuario)
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