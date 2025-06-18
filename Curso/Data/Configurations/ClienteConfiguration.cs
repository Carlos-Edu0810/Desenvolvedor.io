using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CursoEFCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CursoEFCore.Data.Configurations
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes"); //Define o nome da table dentro do banco de dados
            builder.HasKey(p => p.Id); //Define qual das propriedades da entidade vai ser a Primary Key
            builder.Property(p => p.Nome).HasColumnType("VARCHAR(80)").IsRequired(); //Cria uma propriedade na tabela definindo o tipo de dados. "IsRequired() define que o campo é obrigatorio"
            builder.Property(p => p.Telefone).HasColumnType("CHAR(11)");
            builder.Property(p => p.CEP).HasColumnType("CHAR(8)").IsRequired();
            builder.Property(p => p.Estado).HasColumnType("CHAR(2)").IsRequired();
            builder.Property(p => p.Cidade).HasMaxLength(60).IsRequired();

            builder.HasIndex(i => i.Telefone).HasDatabaseName("idx_cliente_telefone"); //Configura um índice de Telefone no banco de dados.
        }
    }
}