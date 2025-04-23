using InnatAPP.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace InnatAPP.Infra.Data.EntitiesConfiguration
{
    class EmailAlternativoAvaliadorConfiguration : IEntityTypeConfiguration<EmailAlternativoAvaliador>
    {
        public void Configure(EntityTypeBuilder<EmailAlternativoAvaliador> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(p => p.EnderecoEmail)
                .HasMaxLength(255)
                .IsRequired();

            builder.HasOne(e => e.Avaliador)
                .WithMany(e => e.EmailsAlternativosAvaliador)
                .HasForeignKey(e => e.IdAvaliador)
                .IsRequired();
        }
    }
}