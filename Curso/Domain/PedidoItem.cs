namespace CursoEFCore.Domain
{
    public class PedidoItem
    {
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; }
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public int Quatidade { get; set; }
        public decimal Valor { get; set; }
        public Decimal Desconto { get; set; }

    }
}