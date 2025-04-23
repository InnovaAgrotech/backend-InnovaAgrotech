using InnatAPP.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace InnatAPP.Infra.Data.EntitiesConfiguration
{
    class EmailAlternativoEmpresaConfiguration : IEntityTypeConfiguration<EmailAlternativoEmpresa>
    {
        public void Configure(EntityTypeBuilder<EmailAlternativoEmpresa> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(p => p.EnderecoEmail)
                .HasMaxLength(255)
                .IsRequired();

            builder.HasOne(e => e.Empresa)
                .WithMany(e => e.EmailsAlternativosEmpresa)
                .HasForeignKey(e => e.IdEmpresa)
                .IsRequired();
        }
    }
}