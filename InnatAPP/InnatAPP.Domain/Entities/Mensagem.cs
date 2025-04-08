using InnatAPP.Domain.Validation;


namespace InnatAPP.Domain.Entities
{
    public sealed class Mensagem
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Texto { get; set; }

        public Mensagem(string nome, string email, string texto)
        {
            ValidateDomain(nome, email, texto);
        }

        public Mensagem(int id, string nome, string email, string texto)
        {
            DomainExceptionValidation.When(id < 0, "Valor de id inválido.");
            Id = id;
            ValidateDomain(nome, email, texto);
        }

        public void Update(string nome, string email, string texto)
        {
            ValidateDomain(nome, email, texto);
        }

        private void ValidateDomain(string nome, string email, string texto)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome),
               "Nome inválido, o nome é obrigatório.");

            DomainExceptionValidation.When(nome.Length < 3,
               "Nome inválido, o nome tem que ter no mínimo 3 caracteres.");

            DomainExceptionValidation.When(nome.Length > 100,
                "Nome inválido, o nome só pode ter no máximo 100 caracteres.");

            DomainExceptionValidation.When(string.IsNullOrEmpty(email),
              "Email inválido, o email é obrigatório.");

            DomainExceptionValidation.When(email.Length < 5,
              "Email inválido, o email tem que ter no mínimo 5 caracteres.");

            DomainExceptionValidation.When(email.Length > 255,
              "Email inválido, o email só pode ter no máximo 255 caracteres.");

            DomainExceptionValidation.When(string.IsNullOrEmpty(texto),
              "Mensagem inválida, a mensagem é obrigatória.");

            DomainExceptionValidation.When(texto.Length < 10,
              "Mensagem inválida, a mensagem tem que ter no mínimo 10 caracteres.");

            DomainExceptionValidation.When(texto.Length > 1000,
              "Mensagem inválida, a mensagem só pode ter no máximo 1000 caracteres.");

            Nome = nome;
            Email = email;
            Texto = texto;
        }
    }
}
