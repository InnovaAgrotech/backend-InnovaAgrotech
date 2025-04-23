#region Importações

using InnatAPP.Domain.Validation;
using System.Collections.Generic;

#endregion

namespace InnatAPP.Domain.Entities
{
    public class Categoria 
    {
        #region Atributos

        public int Id { get; set; }
        public string Nome { get; set; }

        #endregion

        #region Coleções

        public ICollection<Produto> Produtos { get; set; } = new List<Produto>();

        #endregion

        #region Construtores

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

        #endregion

        #region Métodos

        public void Alterar(string nome) 
        {
            ValidateDomain(nome);
        }

        #endregion

        #region Validações

        private void ValidateDomain(string nome)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome),
                "Nome inválido, o nome é obrigatório.");

            DomainExceptionValidation.When(nome.Length < 2,
                "Nome inválido, o nome deve ter no mínimo 2 caracteres.");

            DomainExceptionValidation.When(nome.Length > 50,
                "Nome inválido, o nome pode ter no máximo 50 caracteres.");

            Nome = nome;
        }

        #endregion
    }
}
