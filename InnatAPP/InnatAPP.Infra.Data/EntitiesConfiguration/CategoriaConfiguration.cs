using InnatAPP.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace InnatAPP.Infra.Data.EntitiesConfiguration
{
    class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(p => p.Nome)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasData(
                new Categoria (1, "Drones"),
                new Categoria(2, "Tratores"),
                new Categoria(3, "Semeadeiras"),
                new Categoria(4, "Colheitadeiras"),
                new Categoria(5, "Pulverizadores"),
                new Categoria(6, "Arados"),
                new Categoria(7, "Grades"),
                new Categoria(8, "Subsoladores"),
                new Categoria(9, "Enxadas Rotativas"),
                new Categoria(10, "Escarificadores"),
                new Categoria(11, "Adubadoras"),
                new Categoria(12, "Enfardadoras")
                );
        }
    }
}