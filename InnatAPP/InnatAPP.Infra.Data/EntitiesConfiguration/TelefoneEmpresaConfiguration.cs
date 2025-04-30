using InnatAPP.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace InnatAPP.Infra.Data.EntitiesConfiguration
{
    class TelefoneEmpresaConfiguration : IEntityTypeConfiguration<TelefoneEmpresa>
    {
        public void Configure(EntityTypeBuilder<TelefoneEmpresa> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(p => p.Ddd)
                .HasMaxLength(2)
                .IsRequired();

            builder.Property(p => p.Numero)
                .HasMaxLength(9)
                .IsRequired();

            builder.HasOne(e => e.Empresa)
                .WithMany(e => e.TelefonesEmpresa)
                .HasForeignKey(e => e.IdEmpresa)
                .IsRequired();
        }
    }
}
