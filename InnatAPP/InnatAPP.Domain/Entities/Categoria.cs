using InnatAPP.Domain.Shared;
using InnatAPP.Domain.Validation;

namespace InnatAPP.Domain.Entities
{
    public class Categoria
    {
        #region Propriedades

        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;

        #endregion

        #region Coleções

        public ICollection<Produto> Produtos { get; private set; } = new List<Produto>();

        #endregion

        #region Construtores

        public Categoria() { }

        public Categoria(string nome)
        {
            #region Validações de Entrada

            ValidateDomain(nome);

            #endregion

            #region Inicialização das Propriedades

            Id = Guid.NewGuid();

            #endregion
        }

        public Categoria(Guid id, string nome)
        {
            #region Validações de Entrada

            DomainExceptionValidation.When(id == Guid.Empty, "O id é obrigatório.");

            ValidateDomain(nome);

            #endregion

            #region Inicialização das Propriedades

            Id = id;

            #endregion
        }

        #endregion

        #region Métodos Públicos

        public void Alterar(string nome)
        {
            ValidateDomain(nome);
        }

        #endregion

        #region Validações de Domínio

        private void ValidateDomain(string nome)
        {
            #region Validações de Nome

            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(nome),
            "O nome é obrigatório.");

            DomainExceptionValidation.When(nome.Length < 2,
            "O nome deve ter no mínimo 2 caracteres.");

            DomainExceptionValidation.When(nome.Length > 50,
            "O nome pode ter no máximo 50 caracteres.");

            DomainExceptionValidation.When(nome.StartsWith(' '),
            "O nome não pode começar com espaço (\" \").");

            DomainExceptionValidation.When(nome.EndsWith(' '),
            "O nome não pode terminar com espaço (\" \").");

            DomainExceptionValidation.When(ConstantesValidacao.EspacosConsecutivos.IsMatch(nome),
            "O nome não pode ter espaços consecutivos (\"  \", \"   \", \"    \" e etc).");

            #endregion

            #region Inicialização das Propriedades

            Nome = nome;

            #endregion
        }

        #endregion
    }
}