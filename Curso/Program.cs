using CursoEFCore.Data;
using CursoEFCore.Domain;
using CursoEFCore.ValueObjects;
using Microsoft.EntityFrameworkCore;

class Program
{
    static void Main(string[] args)
    {
        // using var db = new CursoEFCore.Data.ApplicationContext();
        // //db.Database.Migrate();

        // var MigrationPendente = db.Database.GetPendingMigrations().Any();
        // if (MigrationPendente)
        // {
        //     // regra de negocio...
        // }

        //InserirDados();
        InserirDadosEmMassa();
    }

    private static void ConsultarDados()
    {
        using var db = new CursoEFCore.Data.ApplicationContext();
        var consultaPorSintaxe = (from c in db.Clientes where c.Id > 0 select c).ToList();
        var consultaPorMetodo = db.Clientes
            .Where(p => p.Id > 0)
            .OrderBy(p => p.Id)
            .ToList();

        foreach (var cliente in consultaPorMetodo)
        {
            Console.WriteLine($"Consultando Cliente: {cliente.Id}");
            //db.Clientes.Find(cliente.Id)
            db.Clientes.FirstOrDefault(p => p.Id == cliente.Id);
        }


    }

    private static void InserirDadosEmMassa()
    {
        Cliente cliente = new()
        {
            Nome = "Carlos Ramos",
            CEP = "14020680",
            Cidade = "Barrinha",
            Estado = "SP",
            Telefone = "16994176064"
        };

        Produto produto = new()
        {
            Descricao = "Maçã",
            Ativo = true,
            CodigoBarras = "98765432112",
            TipoProduto = TipoProduto.MercadoriaParaVenda,
            Valor = 9.50m
        };

        // using var db = new ApplicationContext();
        // db.AddRange(cliente, produto);

        var ListaDeClientes = new[]
        {
            new Cliente
            {
                Nome = "Beatriz Basto",
                CEP = "14020680",
                Cidade = "Ribeirão Preto",
                Estado = "SP",
                Telefone = "16998624585"
            },

            new Cliente
            {
                Nome = "Rafael Silva",
                CEP = "14860000",
                Cidade = "Barrinha",
                Estado = "SP",
                Telefone = "16954512385"
            }
        };

        var ListaDeProdutos = new[]
        {
            new Produto
            {
                Descricao = "Banana",
                Ativo = true,
                CodigoBarras = "98765435632",
                TipoProduto = TipoProduto.MercadoriaParaVenda,
                Valor = 2.50m
            },

            new Produto
            {
                Descricao = "Laranja",
                Ativo = true,
                CodigoBarras = "89652569874",
                TipoProduto = TipoProduto.MercadoriaParaVenda,
                Valor = 5m
            }
        };

        using var db = new ApplicationContext();
        // db.AddRange(ListaDeClientes);
        // db.AddRange(ListaDeProdutos);

        var ListaDeObjetos = new List<object>();
        // {
        //     ListaDeClientes,
        //     ListaDeProdutos
        // };
        ListaDeObjetos.AddRange(ListaDeClientes);
        ListaDeObjetos.AddRange(ListaDeProdutos);

        db.AddRange(ListaDeObjetos);

        var registros = db.SaveChanges();
        Console.WriteLine("Total registro(s): " + registros);
    }

    private static void InserirDados()
    {
        Produto produto = new()
        {
            Descricao = "Produto Teste",
            CodigoBarras = "1234567891231",
            Valor = 10m,
            TipoProduto = TipoProduto.MercadoriaParaVenda,
            Ativo = true
        };

        using var db = new CursoEFCore.Data.ApplicationContext();
        // |------------------------------------|-------------------------------------------------------------------------------------|----------------------------------------------------------------------------------|
        // | Método                             | Diferença Principal                                                                 | Quando Usar                                                                      |
        // |------------------------------------|-------------------------------------------------------------------------------------|----------------------------------------------------------------------------------|
        // | db.Produtos.Add(produto);          | Mais comum e tipada, usa o DbSet<TEntity> específico definido no DbContext.         | Para operações padrão de adição quando você tem um DbSet<TEntity> definido.      |
        // |------------------------------------|-------------------------------------------------------------------------------------|----------------------------------------------------------------------------------|
        // | db.Set<Produto>().Add(produto);    | Genérica, obtém o DbSet<TEntity> para o tipo em tempo de execução.                  | Cenários genéricos ou quando o DbSet<TEntity> não está diretamente               |
        // |                                    |                                                                                     | exposto como uma propriedade no DbContext (ex: trabalhando com tipos genéricos). |
        // |------------------------------------|-------------------------------------------------------------------------------------|----------------------------------------------------------------------------------|
        // | db.Entry(produto).State = EntityState.Added; | Mais explícita, define o estado de rastreamento da entidade diretamente.  | Para controle preciso do ciclo de vida da entidade, como "re-anexar"             |
        // |                                    |                                                                                     | uma entidade existente para ser tratada como nova.                               |
        // |------------------------------------|-------------------------------------------------------------------------------------|----------------------------------------------------------------------------------|
        // | db.Add(produto);                   | Conveniente e genérica (EF Core), infere o tipo da entidade a ser adicionada.       | Para uma adição simples e concisa onde o tipo pode ser inferido pelo EF.         |
        // |------------------------------------|-------------------------------------------------------------------------------------|----------------------------------------------------------------------------------|

        db.Produtos.Add(produto);
        // db.Set<Produto>().Add(produto);
        // db.Entry(produto).State = EntityState.Added;
        // db.Add(produto);

        var registros = db.SaveChanges();
        Console.WriteLine("Total Registro(s): " + registros);
    }
}


















