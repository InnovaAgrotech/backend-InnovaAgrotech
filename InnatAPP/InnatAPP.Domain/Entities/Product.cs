using InnatAPP.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnatAPP.Domain.Entities
{
    public sealed class Product : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }

        public Product(string name, string description, decimal price, int stock, string image) 
        { 
            ValidateDomain(name, description, price, stock, image);
        }

        public Product(int id,string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(id < 0, "Valor de id inválido.");
            Id = id;
            ValidateDomain(name, description, price, stock, image);
        }

        public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
        {
            ValidateDomain(name, description, price, stock, image);
            CategoryId = categoryId;
        }

        private void ValidateDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
               "Nome inválido, o nome é obrigatório.");

            DomainExceptionValidation.When(name.Length < 3,
               "Nome inválido, o nome tem que ter no mínimo 3 caracteres.");

            DomainExceptionValidation.When(string.IsNullOrEmpty(description),
              "Descrição inválida, a descrição é obrigatória.");

            DomainExceptionValidation.When(description.Length < 5,
              "Descrição inválida, a descrição tem que ter no mínimo 5 caracteres.");

            DomainExceptionValidation.When(price < 0,
              "Valor de preço inválido.");

            DomainExceptionValidation.When(stock < 0,
             "Valor de estoque inválido.");

            DomainExceptionValidation.When(image == null,
            "Imagem inválida, a imagem é obrigatória.");

            DomainExceptionValidation.When(image == "",
             "Imagem inválida, a imagem é obrigatória.");

            DomainExceptionValidation.When(image != null|image != "" && image.Length > 250,
             "Nome de imagem inválida, o nome tem que ter no máximo 250 caracteres.");



            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
        }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
