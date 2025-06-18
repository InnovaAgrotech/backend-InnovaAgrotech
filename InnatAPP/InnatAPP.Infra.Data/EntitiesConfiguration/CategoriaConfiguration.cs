using InnatAPP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InnatAPP.Infra.Data.EntitiesConfiguration
{
    public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("Categorias");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasData(
                new Categoria(Guid.NewGuid(), "Drones"),
                new Categoria(Guid.NewGuid(), "Tratores"),
                new Categoria(Guid.NewGuid(), "Semeadeiras"),
                new Categoria(Guid.NewGuid(), "Colheitadeiras"),
                new Categoria(Guid.NewGuid(), "Pulverizadores"),
                new Categoria(Guid.NewGuid(), "Arados"),
                new Categoria(Guid.NewGuid(), "Grades"),
                new Categoria(Guid.NewGuid(), "Subsoladores"),
                new Categoria(Guid.NewGuid(), "Enxadas Rotativas"),
                new Categoria(Guid.NewGuid(), "Escarificadores"),
                new Categoria(Guid.NewGuid(), "Adubadoras"),
                new Categoria(Guid.NewGuid(), "Enfardadoras")
            );
        }
    }
}