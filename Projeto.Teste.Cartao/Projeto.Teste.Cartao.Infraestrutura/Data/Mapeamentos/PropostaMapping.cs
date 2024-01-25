using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.Teste.Cartao.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Teste.Cartao.Infraestrutura.Data.Mapeamentos
{
    public class PropostaMapping : IEntityTypeConfiguration<Proposta>
    {
        public void Configure(EntityTypeBuilder<Proposta> builder)
        {
            builder.ToTable("proposta");

            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id")
                .HasColumnType("long");

            builder.Property(p => p.NomeProponente)
                .HasColumnName("nome_proponente")
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(p => p.DocumentoProponente)
                .HasColumnName("documento_proponente")
                .HasColumnType("varchar(11)")
                .IsRequired();

            builder.Property(p => p.DataProposta)
                .HasColumnName("data_proposta")
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(p => p.ValorProposta)
                .HasColumnName("valor_proposta")
                .HasColumnType("decimal")
                .IsRequired();

            builder.Property(p => p.ValorRendaProponente)
                .HasColumnName("valor_renda_proponente")
                .HasColumnType("decimal")
                .IsRequired();

            builder.Property(p => p.SituacaoProposta)
                .HasColumnName("situacao_proposta")
                .HasColumnType("int")
                .IsRequired();
        }
    }
}
