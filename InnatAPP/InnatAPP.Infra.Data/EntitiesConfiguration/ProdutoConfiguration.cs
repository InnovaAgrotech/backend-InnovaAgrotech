using InnatAPP.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace InnatAPP.Infra.Data.EntitiesConfiguration
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder) 
        {
            builder.HasKey(t => t.Id);

            builder.Property(p => p.Nome)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.Descricao)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(p => p.Avaliacao)
                .HasPrecision(3,2)
                .IsRequired()
                .HasDefaultValue(5.0);

            builder.Property(p => p.Imagem)
                .HasMaxLength(250);

            builder.Property(p => p.TotalReviews)
                .IsRequired()
                .HasDefaultValue(0);

            builder.HasOne(e => e.Categoria)
                .WithMany(e => e.Produtos)
                .HasForeignKey(e => e.IdCategoria)
                .IsRequired();

            builder.HasOne(e => e.Empresa)
                .WithMany(e => e.Produtos)
                .HasForeignKey(e => e.IdEmpresa)
                .IsRequired();
        }
    }
}