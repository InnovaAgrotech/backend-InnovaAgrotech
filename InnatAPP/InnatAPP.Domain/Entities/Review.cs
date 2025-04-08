using InnatAPP.Domain.Validation;
using System;

namespace InnatAPP.Domain.Entities
{
    public sealed class Review

    {
        public int Id { get; set; }
        public int Satisfacao { get; set; }
        public string Mensagem { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime AtualizadoEm { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public decimal Avaliacao { get; set; }

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

        public void Update(int satisfacao, string mensagem, int likes, int dislikes, decimal avaliacao)
        {
            ValidateDomain(satisfacao, mensagem, likes, dislikes, avaliacao);
            AtualizadoEm = DateTime.UtcNow;
        }

        private void ValidateDomain(int satisfacao, string mensagem, int likes, int dislikes, decimal avaliacao)
        {
            DomainExceptionValidation.When(satisfacao < 0 || satisfacao > 2,
               "Satisfação inválida, o valor de satisfação tem que ser entre 0 e 2.");

            DomainExceptionValidation.When(mensagem.Length > 500,
               "mensagem inválida, a mensagem só pode ter no máximo 500 caracteres.");

            DomainExceptionValidation.When(likes < 0,
               "Valor de likes inválido.");

            DomainExceptionValidation.When(dislikes < 0,
              "Valor de dislikes inválido.");

            DomainExceptionValidation.When(avaliacao < 0 || avaliacao > 5,
              "Avaliação inválida, o valor de avaliação tem ser entre 0 e 5.");

            Satisfacao = satisfacao;
            Mensagem = mensagem;
            Likes = likes;
            Dislikes = dislikes;
            Avaliacao = avaliacao;
        }
        public int IdAvaliador { get; set; }
        public Avaliador Avaliador { get; set; }
    }
}
