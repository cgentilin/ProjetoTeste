using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.Teste.Dominio.Entidades;

namespace Projeto.Teste.Infraestrutura.Data.Mapeamentos
{
    public class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("cliente");

            builder.HasKey(p => p.Id);  // Chave primária da tabela

            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("Id")
                .HasColumnType("long");

            builder.Property(p => p.Nome)
                .HasColumnName("nome")
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(p => p.Email)
                .HasColumnName("email")
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(p => p.RG)
                .HasColumnName("rg")
                .HasColumnType("varchar(8)");

            builder.Property(p => p.Documento)
                .HasColumnName("documento")
                .HasColumnType("varchar(11)")
                .IsRequired();

            builder.Property(p => p.Fone)
                .HasColumnName("fone")
                .HasColumnType("varchar(11)");

            builder.Property(p => p.DataNascimento)
                .HasColumnName("data_nascimento")
                .HasColumnType("datetime");

        }
    }
}
