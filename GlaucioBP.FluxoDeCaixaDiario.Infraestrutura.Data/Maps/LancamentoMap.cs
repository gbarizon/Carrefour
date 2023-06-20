using GlaucioBP.FluxoDeCaixaDiario.Dominio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlaucioBP.FluxoDeCaixaDiario.Infraestrutura.Data.Maps
{
    public class LancamentoMap : IEntityTypeConfiguration<Lancamento>
    {
        public void Configure(EntityTypeBuilder<Lancamento> builder)
        {
            builder.ToTable("Lancamento");

            builder
                .HasKey(c => c.Id);

            builder
                .Property(c => c.Valor).IsRequired(true);

            builder
               .Property(c => c.Valor)
               .HasColumnName("Valor")
               .HasColumnType("decimal")
               .IsRequired(true);

            builder
                .Property(c => c.Tipo)
                .HasColumnName("Tipo")
                .HasColumnType("text")
                .IsRequired(true);

            builder
               .Property(c => c.Data)
               .HasColumnName("Data")
               .HasColumnType("datetime")
               .IsRequired(true);            
        }
    }
}
