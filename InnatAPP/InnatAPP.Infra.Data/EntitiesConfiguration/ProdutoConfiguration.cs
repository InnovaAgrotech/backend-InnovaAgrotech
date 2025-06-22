using InnatAPP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InnatAPP.Infra.Data.EntitiesConfiguration
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder) 
        {
            builder.ToTable("Produtos");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.Descricao)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(p => p.Foto)
                .HasMaxLength(250);

            builder.Property(p => p.Nota)
                .HasPrecision(3,2)
                .IsRequired()
                .HasDefaultValue(5.0);

            builder.Property(p => p.TotalReviews)
                .IsRequired()
                .HasDefaultValue(0);

            builder.HasOne(p => p.Categoria)
                .WithMany(p => p.Produtos)
                .HasForeignKey(p => p.IdCategoria)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.Empresa)
                .WithMany(p => p.Produtos)
                .HasForeignKey(p => p.IdEmpresa)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}