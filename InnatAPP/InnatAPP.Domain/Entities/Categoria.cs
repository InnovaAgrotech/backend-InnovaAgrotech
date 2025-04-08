using InnatAPP.Domain.Validation;
using System.Collections.Generic;

namespace InnatAPP.Domain.Entities
{
    public sealed class Categoria 
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public Categoria(string nome) 
        { 
            ValidateDomain(nome);
        }

        public Categoria(int id, string nome)
        {
            DomainExceptionValidation.When(id < 0, "Valor de id inválido.");
            Id = id;
            ValidateDomain(nome);
        }

        public void Update(string nome) 
        {
            ValidateDomain(nome);
        }

        public ICollection<Produto> Produtos { get; set; }

        private void ValidateDomain(string nome)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome),
                "Nome inválido, o nome é obrigatório.");

            DomainExceptionValidation.When(nome.Length < 2,
                "Nome inválido, o nome tem que ter no mínimo 2 caracteres.");

            DomainExceptionValidation.When(nome.Length > 50,
                "Nome inválido, o nome só pode ter no máximo 50 caracteres.");

            Nome = nome;
        }
    }
}
