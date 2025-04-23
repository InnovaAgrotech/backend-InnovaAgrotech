using InnatAPP.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace InnatAPP.Infra.Data.EntitiesConfiguration
{  
    class EnderecoAvaliadorConfiguration : IEntityTypeConfiguration<EnderecoAvaliador>
    {
        public void Configure(EntityTypeBuilder<EnderecoAvaliador> builder)
        {
                
            builder.HasKey(t => t.Id);

            builder.Property(p => p.Numero)
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(p => p.Rua)
                .HasMaxLength(100)
                 .IsRequired();

            builder.Property(p => p.Bairro)
                .HasMaxLength(60)
                .IsRequired();

            builder.Property(p => p.Cidade)
                .HasMaxLength(80)
                .IsRequired();
                
            builder.Property(p => p.Cidade)
                .HasMaxLength(2)
                .IsRequired();

            builder.Property(p => p.Cep)
                .HasMaxLength(8)
                .IsRequired();

            builder.Property(p => p.Complemento)
                .HasMaxLength(100);

            builder.HasOne(e => e.Avaliador)
                .WithMany(e => e.EnderecosAvaliador)
                .HasForeignKey(e => e.IdAvaliador)
                .IsRequired();
        }
    }
}