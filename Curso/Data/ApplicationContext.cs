using CursoEFCore.Data.Configurations;
using CursoEFCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CursoEFCore.Data
{
    public class ApplicationContext : DbContext
    {
        private static ILoggerFactory _logger = LoggerFactory.Create(p => p.AddConsole());


        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLoggerFactory(_logger)
                .EnableSensitiveDataLogging()
                .UseSqlServer("Server=localhost\\sqlexpress; Initial Catalog=CursoEFCore; Integrated Security=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
            // modelBuilder.ApplyConfiguration(new ClienteConfiguration());
            // modelBuilder.ApplyConfiguration(new PedidoConfiguration());
            // modelBuilder.ApplyConfiguration(new ProdutoConfiguration());
            // modelBuilder.ApplyConfiguration(new PedidoItemConfiguration());


            // Foi implantado em Configuration
            // modelBuilder.Entity<Cliente>(p =>
            // {
            //     p.ToTable("Clientes"); //Define o nome da table dentro do banco de dados
            //     p.HasKey(p => p.Id); //Define qual das propriedades da entidade vai ser a Primary Key
            //     p.Property(p => p.Nome).HasColumnType("VARCHAR(80)").IsRequired(); //Cria uma propriedade na tabela definindo o tipo de dados. "IsRequired() define que o campo é obrigatorio"
            //     p.Property(p => p.Telefone).HasColumnType("CHAR(11)");
            //     p.Property(p => p.CEP).HasColumnType("CHAR(8)").IsRequired();
            //     p.Property(p => p.Estado).HasColumnType("CHAR(2)").IsRequired();
            //     p.Property(p => p.Cidade).HasMaxLength(60).IsRequired();

            //     p.HasIndex(i => i.Telefone).HasDatabaseName("idx_cliente_telefone"); //Configura um índice de Telefone no banco de dados.
            // });

            // modelBuilder.Entity<Produto>(p =>
            // {
            //     p.ToTable("Produtos");
            //     p.HasKey(p => p.Id);
            //     p.Property(p => p.CodigoBarras).HasColumnType("VARCHAR(14)").IsRequired();
            //     p.Property(p => p.Descricao).HasColumnType("VARCHAR(60)");
            //     p.Property(p => p.Valor).IsRequired(); //Quando não infomado o HasColumnType o EntityFramework assume o tipo padrão da propridade, considerando que valor é um decimal ele vai assumir "decimal(18,2)"
            //     p.Property(p => p.TipoProduto).HasConversion<string>(); //TipoProduto é um "Enum" com "HasConversion" posso informar que desejo salvar a informação em string ou em int
            // });

            // modelBuilder.Entity<Pedido>(p =>
            // {
            //     p.ToTable("Pedidos");
            //     p.HasKey(p => p.Id);
            //     p.Property(p => p.IniciadoEm).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd(); //"HasDefaultValueSql" define que a propridade vai ter um valor padrão usando comando sql. "ValueGeneratedOnAdd" define que esse valor padrão vai ser execultado quando um dado for inserido
            //     p.Property(p => p.Status).HasConversion<string>();
            //     p.Property(p => p.TipoFrete).HasConversion<int>();
            //     p.Property(p => p.observacao).HasColumnType("VARCHAR(512)");

            //     p.HasMany(p => p.Itens) // Diz que a entidade Pedido tem muitos Itens (ou seja, muitos PedidoItem). |  Isso representa a parte "1 → N" da relação.
            //         .WithOne(p => p.Pedido) // Diz que cada PedidoItem pertence a exatamente um Pedido. | Essa é a navegação inversa (do item para o pedido).
            //         .OnDelete(DeleteBehavior.Cascade); // Define o comportamento ao deletar um Pedido. "DeleteBehavior.Cascade" significa: Se você deletar um Pedido todos os PedidoItem associados também serão deletados automaticamente.
            // });

            // modelBuilder.Entity<PedidoItem>(p =>
            // {
            //     p.ToTable("PedidoItens");
            //     p.HasKey(p => p.Id);
            //     p.Property(p => p.Quatidade).HasDefaultValue(1).IsRequired(); //"HasDefaultValue" define que a propridade vai ter um valor padrão caso não seja informado nenhum valor ao receber um insert.
            //     p.Property(p => p.Valor).IsRequired();
            //     p.Property(p => p.Desconto).IsRequired();
            // });
        }
    }
}