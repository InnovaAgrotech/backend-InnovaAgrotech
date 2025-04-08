using InnatAPP.Domain.Validation;
using System.Collections.Generic;

namespace InnatAPP.Domain.Entities
{
    public sealed class Avaliador
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Foto { get; set; }
        public string Bio { get; set; }

        public Avaliador(string nome, string email, string senha, string foto, string bio)
        {
            ValidateDomain(nome, email, senha, foto, bio);
        }

        public Avaliador(int id, string nome, string email, string senha, string foto, string bio)
        {
            DomainExceptionValidation.When(id < 0, "Valor de id inválido.");
            Id = id;
            ValidateDomain(nome, email, senha, foto, bio);
        }

        public void Update(string nome, string email, string senha, string foto, string bio)
        {
            ValidateDomain(nome, email, senha, foto, bio);
        }

        private void ValidateDomain(string nome, string email, string senha, string foto, string bio)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome),
               "Nome inválido, o nome é obrigatório.");

            DomainExceptionValidation.When(nome.Length < 2,
               "Nome inválido, o nome tem que ter no mínimo 2 caracteres.");

            DomainExceptionValidation.When(nome.Length > 100,
                "Nome inválido, o nome só pode ter no máximo 100 caracteres.");

            DomainExceptionValidation.When(string.IsNullOrEmpty(email),
              "Email inválido, o email é obrigatório.");

            DomainExceptionValidation.When(email.Length < 5,
              "Email inválido, o email tem que ter no mínimo 5 caracteres.");

            DomainExceptionValidation.When(email.Length > 255,
              "Email inválido, o email só pode ter no máximo 255 caracteres.");

            DomainExceptionValidation.When(string.IsNullOrEmpty(senha),
              "Senha inválida, a senha é obrigatória.");

            DomainExceptionValidation.When(senha.Length < 8,
              "Senha inválida, a senha tem que ter no mínimo 8 caracteres.");

            DomainExceptionValidation.When(senha.Length > 64,
              "Senha inválida, a senha só pode ter no máximo 64 caracteres.");

            DomainExceptionValidation.When(foto.Length > 250,
            "URL da imagem inválida, a URL tem que ter no máximo 250 caracteres.");

            DomainExceptionValidation.When(bio.Length > 500,
              "Bio inválida, a bio só pode ter no máximo 500 caracteres.");

            Nome = nome;
            Email = email;
            Senha = senha;
            Foto = foto;
            Bio = bio;
        }

        public ICollection<Review> Reviews { get; set; }

    }
}

