#region Importações

using System.Collections.Generic;
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

        public Produto(string nome, string descricao, decimal avaliacao, string imagem, int totalreviews)
        {
            ValidateDomain(nome, descricao, avaliacao, imagem, totalreviews);
        }

        public Produto(int id, string nome, string descricao, decimal avaliacao, string imagem, int totalreviews)
        {
            DomainExceptionValidation.When(id < 0, "Valor de id inválido.");
            Id = id;
            ValidateDomain(nome, descricao, avaliacao, imagem, totalreviews);
        }

        #endregion

        #region Métodos

        public void Atualizar(string nome, string descricao, decimal avaliacao, string imagem, int totalreviews, int idcategoria)
        {
            ValidateDomain(nome, descricao, avaliacao, imagem, totalreviews);
            IdCategoria = idcategoria;
        }

        #endregion

        #region Validações

        private void ValidateDomain(string nome, string descricao, decimal avaliacao, string imagem, int totalreviews)
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

            DomainExceptionValidation.When(avaliacao < 0 || avaliacao > 5,
            "Avaliação inválida, o valor de avaliação tem ser entre 0 e 5.");

            DomainExceptionValidation.When(imagem?.Length > 250,
            "URL da imagem inválida, a URL pode ter no máximo 250 caracteres.");

            DomainExceptionValidation.When(totalreviews < 0,
             "Valor de total de reviews inválido.");

            Nome = nome;
            Descricao = descricao;
            Avaliacao = avaliacao;
            Imagem = imagem;
            TotalReviews = totalreviews;
        }

        #endregion
    }
}