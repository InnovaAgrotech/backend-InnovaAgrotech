using InnatAPP.Domain.Shared;
using InnatAPP.Domain.Validation;

namespace InnatAPP.Domain.Entities
{
    public class Produto
    {
        #region Propriedades

        public Guid Id { get; private set; }
        public string Nome { get; private set; } = string.Empty;
        public string Descricao { get; private set; } = string.Empty;
        public string Foto { get; private set; } = string.Empty;
        public decimal Nota { get; private set; }
        public int TotalReviews { get; private set; }

        #endregion

        #region Chaves Estrangeiras

        public Guid IdCategoria { get; private set; }
        public Guid IdEmpresa { get; private set; }

        #endregion

        #region Propriedades de Navegação

        public Categoria Categoria { get; private set; } = default!;
        public Empresa Empresa { get; private set; } = default!;

        #endregion

        #region Coleções

        public ICollection<Review> Reviews { get; private set; } = new List<Review>();

        #endregion

        #region Construtores

        public Produto() { }

        public Produto(string nome, string descricao, string foto, Guid idCategoria, Guid idEmpresa)
        {
            #region Validações de Entrada

            ValidateDomain(nome, descricao, foto);

            DomainExceptionValidation.When(idCategoria == Guid.Empty, "O id de categoria é obrigatório.");

            DomainExceptionValidation.When(idEmpresa == Guid.Empty, "O id de empresa é obrigatório.");

            #endregion

            #region Inicialização das Propriedades

            Id = Guid.NewGuid();
            Nota = 5.0m;
            TotalReviews = 0;
            IdCategoria = idCategoria;
            IdEmpresa = idEmpresa;

            #endregion
        }

        public Produto(Guid id, string nome, string descricao, string foto, decimal nota, int totalReviews, Guid idCategoria, Guid idEmpresa)
        {
            #region Validações de Entrada

            DomainExceptionValidation.When(id == Guid.Empty, "O id é obrigatório.");

            ValidateDomain(nome, descricao, foto);

            DomainExceptionValidation.When(nota < 0, "A nota não pode ser menor que zero (0).");

            DomainExceptionValidation.When(nota > 5, "A nota não pode ser maior que cinco (5).");

            DomainExceptionValidation.When(totalReviews < 0, "O valor total de reviews não pode ser menor que zero (0).");

            DomainExceptionValidation.When(idCategoria == Guid.Empty, "O id de categoria é obrigatório.");

            DomainExceptionValidation.When(idEmpresa == Guid.Empty, "O id de empresa é obrigatório.");

            #endregion

            #region Inicialização das Propriedades


            Id = id;
            Nota = nota;
            TotalReviews = totalReviews;
            IdCategoria = idCategoria;
            IdEmpresa = idEmpresa;

            #endregion
        }

        #endregion

        #region Métodos Públicos

        public void Alterar(string nome, string descricao, string foto, Guid idCategoria)
        {
            #region Validações de Entrada

            ValidateDomain(nome, descricao, foto);

            DomainExceptionValidation.When(idCategoria == Guid.Empty, "O id de categoria é obrigatório.");

            #endregion

            #region Inicialização das Propriedades

            IdCategoria = idCategoria;

            #endregion
        }

        #endregion

        #region Validações de Domínio

        private void ValidateDomain(string nome, string descricao, string foto)
        {
            #region Validações de Nome

            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(nome),
            "O nome é obrigatório.");

            DomainExceptionValidation.When(nome.StartsWith(' '),
            "O nome não pode começar com espaço (\" \").");

            DomainExceptionValidation.When(nome.EndsWith(' '),
            "O nome não pode terminar com espaço (\" \").");

            DomainExceptionValidation.When(ConstantesValidacao.EspacosConsecutivos.IsMatch(nome),
            "O nome não pode ter espaços consecutivos (\"  \", \"   \", \"    \" e etc).");

            DomainExceptionValidation.When(nome.Length < 2,
            "O nome deve ter no mínimo 2 caracteres.");

            DomainExceptionValidation.When(nome.Length > 100,
            "O nome pode ter no máximo 100 caracteres.");

            #endregion

            #region Validações de descrição

            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(descricao),
            "A descrição é obrigatória.");

            DomainExceptionValidation.When(descricao.Length < 10,
            "A descrição deve ter no mínimo 10 caracteres.");

            DomainExceptionValidation.When(descricao.Length > 500,
            "A descrição pode ter no máximo 500 caracteres.");

            #endregion

            #region Validações de Foto

            DomainExceptionValidation.When(foto?.Length > 250,
            "A URL da foto pode ter no máximo 250 caracteres.");

            #endregion

            #region Inicialização das Propriedades

            Nome = nome;
            Descricao = descricao;
            Foto = foto ?? string.Empty;

            #endregion
        }

        #endregion
    }
}