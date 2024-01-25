using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nscartao = Projeto.Teste.Cartao.Dominio.Entidades;

namespace Projeto.Teste.Cartao.Infraestrutura.Data.Mapeamentos
{
    public class CartaoMapping : IEntityTypeConfiguration<nscartao.Cartao>
    {
        public void Configure(EntityTypeBuilder<nscartao.Cartao> builder)
        {
            builder.ToTable("cartao");

            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id")
                .HasColumnType("long");

            builder.Property(p => p.NumeroCartao)
                .HasColumnName("numero")
                .HasColumnType("varchar(10)")
                .IsRequired();

            builder.Property(p => p.DocumentoTitular)
                .HasColumnName("documento_titular")
                .HasColumnType("varchar(11)")
                .IsRequired();

            builder.Property(p => p.DataValidade)
                .HasColumnName("data_validade")
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(p => p.DataEmissao)
                .HasColumnName("data_emissao")
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(p => p.Situacao)
                .HasColumnName("situacao")
                .HasColumnType("int")
                .IsRequired();

        }

    }
}
