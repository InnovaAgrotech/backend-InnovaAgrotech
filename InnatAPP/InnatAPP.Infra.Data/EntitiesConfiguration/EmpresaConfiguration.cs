using InnatAPP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InnatAPP.Infra.Data.EntitiesConfiguration
{
    public class EmpresaConfiguration : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.ToTable("Empresas");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.IdUsuario)
                .IsRequired();

            builder.HasIndex(e => e.IdUsuario)
                .IsUnique();

            builder.HasOne(e => e.Usuario)
                .WithOne()
                .HasForeignKey<Empresa>(e => e.IdUsuario)
                .IsRequired();
        }
    }
}