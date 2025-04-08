using InnatAPP.Domain.Validation;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace InnatAPP.Domain.Entities
{
    public sealed class Produto 
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Avaliacao { get; set; }
        public string Imagem { get; set; }
        public int TotalReviews { get; set; }

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

        public void Update(string nome, string descricao, decimal avaliacao, string imagem, int totalreviews, int idCategoria)
        {
            ValidateDomain(nome, descricao, avaliacao, imagem, totalreviews);
            IdCategoria = idCategoria;
        }

        private void ValidateDomain(string nome, string descricao, decimal avaliacao, string imagem, int totalreviews)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome),
               "Nome inválido, o nome é obrigatório.");

            DomainExceptionValidation.When(nome.Length < 3,
               "Nome inválido, o nome tem que ter no mínimo 3 caracteres.");

            DomainExceptionValidation.When(nome.Length > 100,
                "Nome inválido, o nome só pode ter no máximo 100 caracteres.");

            DomainExceptionValidation.When(string.IsNullOrEmpty(descricao),
              "Descrição inválida, a descrição é obrigatória.");

            DomainExceptionValidation.When(descricao.Length < 10,
              "Descrição inválida, a descrição tem que ter no mínimo 10 caracteres.");

            DomainExceptionValidation.When(descricao.Length > 500,
              "Descrição inválida, a descrição só pode ter no máximo 500 caracteres.");

            DomainExceptionValidation.When(avaliacao < 0 || avaliacao > 5,
              "Avaliação inválida, o valor de avaliação tem ser entre 0 e 5.");

            DomainExceptionValidation.When(imagem.Length > 250,
            "URL da imagem inválida, a URL tem que ter no máximo 250 caracteres.");

            DomainExceptionValidation.When(totalreviews < 0,
             "Valor de total de reviews inválido.");

            Nome = nome;
            Descricao = descricao;
            Avaliacao = avaliacao;
            Imagem = imagem;
            TotalReviews = totalreviews;
        }
        public int IdCategoria { get; set; }
        public Categoria Categoria { get; set; }

        public int IdEmpresa { get; set; }
        public Empresa Empresa { get; set; }

        public ICollection<Review> Reviews { get; set; }

    }
}
