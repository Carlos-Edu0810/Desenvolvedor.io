using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CursoEFCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CursoEFCore.Data.Configurations
{
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedidos");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.IniciadoEm).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd(); //"HasDefaultValueSql" define que a propridade vai ter um valor padrão usando comando sql. "ValueGeneratedOnAdd" define que esse valor padrão vai ser execultado quando um dado for inserido
            builder.Property(p => p.Status).HasConversion<string>();
            builder.Property(p => p.TipoFrete).HasConversion<int>();
            builder.Property(p => p.observacao).HasColumnType("VARCHAR(512)");

            builder.HasMany(p => p.Itens) // Diz que a entidade Pedido tem muitos Itens (ou seja, muitos PedidoItem). |  Isso representa a parte "1 → N" da relação.
                .WithOne(p => p.Pedido) // Diz que cada PedidoItem pertence a exatamente um Pedido. | Essa é a navegação inversa (do item para o pedido).
                .OnDelete(DeleteBehavior.Cascade); // Define o comportamento ao deletar um Pedido. "DeleteBehavior.Cascade" significa: Se você deletar um Pedido todos os PedidoItem associados também serão deletados automaticamente.
        }
    }
}