#region Importações

using InnatAPP.Domain.Validation;
using System;

#endregion

namespace InnatAPP.Domain.Entities
{
    public sealed class Review

    {
        #region Atributos

        public int Id { get; set; }
        public int Satisfacao { get; set; }
        public string Mensagem { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime AtualizadoEm { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public decimal Avaliacao { get; set; }
        public int IdAvaliador { get; set; }
        public Avaliador Avaliador { get; set; }

        #endregion

        #region Construtores

        public Review(int satisfacao, string mensagem, int likes, int dislikes, decimal avaliacao)
        {
            ValidateDomain(satisfacao, mensagem, likes, dislikes, avaliacao);
            CriadoEm = DateTime.UtcNow;
            AtualizadoEm = DateTime.UtcNow;
        }

        public Review(int id, int satisfacao, string mensagem, DateTime criadoem, DateTime atualizadoem, int likes, int dislikes, decimal avaliacao)
        {
            DomainExceptionValidation.When(id < 0, "Valor de id inválido.");
            Id = id;
            ValidateDomain(satisfacao, mensagem, likes, dislikes, avaliacao);
            CriadoEm = criadoem;
            AtualizadoEm = atualizadoem;    
        }

        #endregion

        #region Métodos

        public void Atualizar(int satisfacao, string mensagem, int likes, int dislikes, decimal avaliacao)
        {
            ValidateDomain(satisfacao, mensagem, likes, dislikes, avaliacao);
            AtualizadoEm = DateTime.UtcNow;
        }

        #endregion

        #region Validações

        private void ValidateDomain(int satisfacao, string mensagem, int likes, int dislikes, decimal avaliacao)
        {
            DomainExceptionValidation.When(satisfacao < 0 || satisfacao > 2,
            "Satisfação inválida, a satisfação deve estar entre 0 e 2.");

            DomainExceptionValidation.When(!string.IsNullOrEmpty(mensagem) && mensagem.Length < 5,
            "Mensagem inválida, a mensagem deve ter no mínimo 5 caracteres.");

            DomainExceptionValidation.When(mensagem.Length > 500,
            "Mensagem inválida, a mensagem pode ter no máximo 500 caracteres.");

            DomainExceptionValidation.When(likes < 0,
            "Valor de likes inválido.");

            DomainExceptionValidation.When(dislikes < 0,
            "Valor de dislikes inválido.");

            DomainExceptionValidation.When(avaliacao < 0 || avaliacao > 5,
            "Avaliação inválida, a avaliação deve estar entre 0 e 5.");

            Satisfacao = satisfacao;
            Mensagem = mensagem;
            Likes = likes;
            Dislikes = dislikes;
            Avaliacao = avaliacao;
        }

        #endregion
    }
}
