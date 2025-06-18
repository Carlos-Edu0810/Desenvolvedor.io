using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CursoEFCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CursoEFCore.Data.Configurations
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produtos");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.CodigoBarras).HasColumnType("VARCHAR(14)").IsRequired();
            builder.Property(p => p.Descricao).HasColumnType("VARCHAR(60)");
            builder.Property(p => p.Valor).HasPrecision(18, 4).IsRequired(); //Quando não infomado o HasColumnType o EntityFramework assume o tipo padrão da propridade, considerando que valor é um decimal ele vai assumir "decimal(18,2)"
            builder.Property(p => p.TipoProduto).HasConversion<string>(); //TipoProduto é um "Enum" com "HasConversion" posso informar que desejo salvar a informação em string ou em int
        }
    }
}