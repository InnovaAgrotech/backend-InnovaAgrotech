#region Importações

using InnatAPP.Domain.Validation;

#endregion

namespace InnatAPP.Domain.Entities
{
    public sealed class Produto
    {
        #region Atributos

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Avaliacao { get; set; }
        public string Imagem { get; set; }
        public int TotalReviews { get; set; }
        public int IdCategoria { get; set; }
        public Categoria Categoria { get; set; }
        public int IdEmpresa { get; set; }
        public Empresa Empresa { get; set; }

        #endregion

        #region Coleções

        public ICollection<Review> Reviews { get; set; } = new List<Review>();

        #endregion

        #region Construtores

        public Produto(string nome, string descricao, string imagem, int idCategoria, int idEmpresa)
        {
            ValidateDomain(nome, descricao, imagem);
            Avaliacao = 5.0m;
            TotalReviews = 0;
            IdCategoria = idCategoria;
            IdEmpresa = idEmpresa;
        }

        public Produto(int id, string nome, string descricao, decimal avaliacao, string imagem, int totalReviews, int idCategoria, int idEmpresa)
        {
            DomainExceptionValidation.When(id < 0, "Valor de id inválido.");
            Id = id;
            ValidateDomain(nome, descricao, imagem);
            DomainExceptionValidation.When(avaliacao < 0 || avaliacao > 5, "Valor de avaliação inválido.");
            Avaliacao = avaliacao;
            DomainExceptionValidation.When(totalReviews < 0, "Valor total de reviews inválido.");
            TotalReviews = totalReviews;
            IdCategoria = idCategoria;
            IdEmpresa = idEmpresa;
        }

        #endregion

        #region Métodos

        public void Alterar(string nome, string descricao, string imagem, int idCategoria)
        {
            ValidateDomain(nome, descricao, imagem);
            IdCategoria = idCategoria;
        }

        #endregion

        #region Validações

        private void ValidateDomain(string nome, string descricao, string imagem)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome),
            "Nome inválido, o nome é obrigatório.");

            DomainExceptionValidation.When(nome.Length < 2,
            "Nome inválido, o nome deve ter no mínimo 2 caracteres.");

            DomainExceptionValidation.When(nome.Length > 100,
            "Nome inválido, o nome pode ter no máximo 100 caracteres.");

            DomainExceptionValidation.When(string.IsNullOrEmpty(descricao),
            "Descrição inválida, a descrição é obrigatória.");

            DomainExceptionValidation.When(descricao.Length < 10,
            "Descrição inválida, a descrição deve ter no mínimo 10 caracteres.");

            DomainExceptionValidation.When(descricao.Length > 500,
            "Descrição inválida, a descrição pode ter no máximo 500 caracteres.");

            DomainExceptionValidation.When(imagem?.Length > 250,
            "URL da imagem inválida, a URL pode ter no máximo 250 caracteres.");

            Nome = nome;
            Descricao = descricao;
            Imagem = imagem;
        }

        #endregion
    }
}