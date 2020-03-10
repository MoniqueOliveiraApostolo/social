using System;
using Social.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Social.Infra.Data.Mapping
{
    public class ContatoMap : IEntityTypeConfiguration<Contato>
    {
        public void Configure(EntityTypeBuilder<Contato> builder)
        {
            builder.ToTable("G_TB_CONTATO");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.DataCadastro)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(c => c.NomeContato)
                .IsRequired()
                .HasColumnType("varchar(120)");

            builder.Property(c => c.DataNascimento)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(c => c.Sexo)
                .IsRequired()
                .HasColumnType("varchar(1)");
        }
    }
}
