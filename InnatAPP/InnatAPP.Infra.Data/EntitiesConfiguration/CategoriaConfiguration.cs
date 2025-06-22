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
                new Categoria(new Guid("e6e97a8f-dc2f-4a75-a5ff-6f2d2f6a9d02"), "Drones"),
                new Categoria(new Guid("ae32fc1f-14e2-470c-aecf-cf52a79d4e4f"), "Tratores"),
                new Categoria(new Guid("b1b4d98c-2cc1-4a08-b7d9-baf8403c2a23"), "Semeadeiras"),
                new Categoria(new Guid("8c0fc7a1-63d2-40d6-b31c-1c0a741d42b7"), "Colheitadeiras"),
                new Categoria(new Guid("9ed18ed4-17ef-4a6a-9e0b-6cbb7eeb88c2"), "Pulverizadores"),
                new Categoria(new Guid("03b6e5d5-b98e-4436-9115-2db0220c7381"), "Arados"),
                new Categoria(new Guid("72476c3f-2a83-4686-94bc-d3b3c9d33c2e"), "Grades"),
                new Categoria(new Guid("d19c882e-19c0-4395-a2c6-f6a80f5dbb0e"), "Subsoladores"),
                new Categoria(new Guid("cad2a5a7-77a6-4b1b-85f0-b643b2489fd3"), "Enxadas Rotativas"),
                new Categoria(new Guid("a9dcadad-dde9-4d8f-b91a-0e6eb396f582"), "Escarificadores"),
                new Categoria(new Guid("3c80cbd3-df45-476b-9bfb-e50d7e89940e"), "Adubadoras"),
                new Categoria(new Guid("d86c580e-88e5-42cf-882c-175848229dbf"), "Enfardadoras")
            );
        }
    }
}