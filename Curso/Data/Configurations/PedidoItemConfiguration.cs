using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CursoEFCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CursoEFCore.Data.Configurations
{
    public class PedidoItemConfiguration : IEntityTypeConfiguration<PedidoItem>
    {
        public void Configure(EntityTypeBuilder<PedidoItem> builder)
        {
            builder.ToTable("PedidoItens");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Quatidade).HasDefaultValue(1).IsRequired(); //"HasDefaultValue" define que a propridade vai ter um valor padrão caso não seja informado nenhum valor ao receber um insert.
            builder.Property(p => p.Valor).HasPrecision(18, 4).IsRequired(); //HasPrecision(18, 4) informa qual a precisão e escala do "Decimal", pode ser usando "HasPrecision(18, 4)" ou HasColumnType("decimal(18,4)")
            builder.Property(p => p.Desconto).HasPrecision(18, 4).IsRequired();
        }
    }
}