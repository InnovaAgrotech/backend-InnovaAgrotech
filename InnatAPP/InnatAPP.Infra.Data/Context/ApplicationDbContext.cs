using InnatAPP.Domain.Entities;
using InnatAPP.Infra.Data.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InnatAPP.Infra.Data.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Avaliador> Avaliadores { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<EmailAlternativoAvaliador> EmailsAlternativosAvaliador { get; set; }
        public DbSet<EmailAlternativoEmpresa> EmailsAlternativosEmpresa { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<EnderecoAvaliador> EnderecosAvaliador { get; set; }
        public DbSet<EnderecoEmpresa> EnderecosEmpresa { get; set; }
        public DbSet<Mensagem> Mensagens { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<TelefoneAvaliador> TelefonesAvaliador { get; set; }
        public DbSet<TelefoneEmpresa> TelefonesEmpresa { get; set; }

        protected override void OnModelCreating(ModelBuilder Builder)
        {
            base.OnModelCreating(Builder);
            Builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

    }
}
