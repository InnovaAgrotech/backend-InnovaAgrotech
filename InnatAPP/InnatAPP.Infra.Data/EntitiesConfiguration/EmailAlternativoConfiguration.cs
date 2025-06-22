using InnatAPP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InnatAPP.Infra.Data.EntitiesConfiguration
{
    public class EmailAlternativoConfiguration : IEntityTypeConfiguration<EmailAlternativo>
    {
        public void Configure(EntityTypeBuilder<EmailAlternativo> builder)
        {
            builder.ToTable("EmailsAlternativos");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.EnderecoEmail)
                .HasMaxLength(254)
                .IsRequired();

            builder.HasOne(e => e.Usuario)
                .WithMany(e => e.EmailsAlternativos)
                .HasForeignKey(e => e.IdUsuario)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}