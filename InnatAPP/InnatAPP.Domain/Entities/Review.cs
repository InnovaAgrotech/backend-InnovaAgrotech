#region Importações

using InnatAPP.Domain.Validation;

#endregion

namespace InnatAPP.Domain.Entities
{
    public sealed class Review
    {
        #region Atributos

        public int Id { get; set; }
        public decimal Avaliacao { get; set; }
        public string Mensagem { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime AtualizadoEm { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public int IdAvaliador { get; set; }
        public Avaliador Avaliador { get; set; }
        public int IdProduto { get; set; }
        public Produto Produto { get; set; }

        #endregion

        #region Construtores

        public Review(decimal avaliacao, string mensagem, int idAvaliador, int idProduto)
        {
            ValidateDomain(avaliacao, mensagem);
            CriadoEm = DateTime.UtcNow;
            AtualizadoEm = DateTime.UtcNow;
            Likes = 0;
            Dislikes = 0;
            IdAvaliador = idAvaliador;
            IdProduto = idProduto;
        }

        public Review(int id, decimal avaliacao, string mensagem, DateTime criadoEm, DateTime atualizadoEm, int likes, int dislikes, int idAvaliador, int idProduto)
        {
            DomainExceptionValidation.When(id < 0, "Valor de id inválido.");
            Id = id;
            ValidateDomain(avaliacao, mensagem);
            CriadoEm = criadoEm;
            AtualizadoEm = atualizadoEm;
            DomainExceptionValidation.When(likes < 0, "Valor de likes inválido.");
            Likes = likes;
            DomainExceptionValidation.When(dislikes < 0, "Valor de dislikes inválido.");
            Dislikes = dislikes;
            IdAvaliador = idAvaliador;
            IdProduto = idProduto;
        }

        #endregion

        #region Métodos

        public void Alterar(decimal avaliacao, string mensagem)
        {
            ValidateDomain(avaliacao, mensagem);
            AtualizadoEm = DateTime.UtcNow;
        }

        #endregion

        #region Validações

        private void ValidateDomain(decimal avaliacao, string mensagem)
        {
            DomainExceptionValidation.When(avaliacao < 0 || avaliacao > 5,
            "Avaliação inválida, a avaliação deve estar entre 0 e 5.");

            DomainExceptionValidation.When(!string.IsNullOrEmpty(mensagem) && mensagem.Length < 5,
            "Mensagem inválida, a mensagem deve ter no mínimo 5 caracteres.");

            DomainExceptionValidation.When(mensagem.Length > 500,
            "Mensagem inválida, a mensagem pode ter no máximo 500 caracteres.");

            Mensagem = mensagem;
            Avaliacao = avaliacao;
        }

        #endregion
    }
}