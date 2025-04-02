﻿using InnatAPP.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnatAPP.Domain.Entities
{
    public sealed class Category : Entity
    {
        public string Name { get; private set; }

        public Category(string name) 
        { 
            ValidateDomain(name);
        }

        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Valor de id inválido.");
            Id = id;
            ValidateDomain(name);
        }

        public void Update(string name) 
        {
            ValidateDomain(name);
        }

        public ICollection<Product> Products { get; set; }

        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Nome inválido, o nome é obrigatório.");

            DomainExceptionValidation.When(name.Length < 3,
                "Nome inválido, o nome tem que ter no mínimo 3 caracteres.");

            Name = name;
        }
    }
}
