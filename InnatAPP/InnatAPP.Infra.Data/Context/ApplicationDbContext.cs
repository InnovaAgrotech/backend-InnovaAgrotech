using InnatAPP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnatAPP.Infra.Data.Context
{
    internal class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options) 
        { }

        public DbSet<Avaliador> Avaliadores { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<EmailAlternativo> EmailsAlternativos { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Mensagem> Mensagens { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Telefone> Telefones { get; set; }
        public DbSet<UsuarioBase> UsuariosBases { get; set; }

        protected override void OnModelCreating(ModelBuilder Builder)
        {
            base.OnModelCreating(Builder);
            Builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

    }
}
