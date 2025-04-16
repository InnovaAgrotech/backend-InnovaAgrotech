using InnatAPP.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnatAPP.Infra.Data.EntitiesConfiguration
{  
    class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
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

            builder.HasOne(e => e.UsuarioBase)
                .WithMany(e => e.Enderecos)
                .HasForeignKey(e => e.UsuarioBaseId)
                .IsRequired();
        }
    }
}
