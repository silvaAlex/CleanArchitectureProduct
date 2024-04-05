using CleanArchitectureProduct.Domain.Models;

namespace CleanArchitectureProduct.Communication.Response
{
    public partial class PedidoResponse
    {
        public int Id { get; private set; }
        public string? NomeCliente { get; private set; }
        public string? EmailClient { get; private set; }
        public bool? Pago { get; set; }
        public decimal ValorTotal { get; private set; } = 0;
        public List<ItemPedidoResponse>? ItensPedido { get; private set; }

        public PedidoResponse GetPedidoResponse(Pedido pedido)
        {
            var itemPedidos = new List<ItemPedidoResponse>();

            if (pedido.Pedidos is not null)
            {
                foreach (ItemPedido item in pedido.Pedidos)
                {
                    itemPedidos.Add(new ItemPedidoResponse()
                    {
                        Id = item.Id,
                        IdProduto = item.ProdutoId,
                        NomeProduto = item.Produto?.NomeProduto,
                        ValorUnitario = item.Produto?.Preco,
                        Quantidade = item.Quantidade,
                    });
                }
            }

            PedidoResponse response = new()
            {
                Id = pedido.Id,
                NomeCliente = pedido.NomeCliente,
                EmailClient = pedido.EmailCliente,
                ValorTotal = CalcularSomaItemPedido(itemPedidos),
                Pago = pedido.Pago,
                ItensPedido = itemPedidos,
            };

            return response;
        }

        private static decimal CalcularSomaItemPedido(List<ItemPedidoResponse> pedidos)
        {
            return pedidos.Sum(x => x.Quantidade * x.ValorUnitario) ?? 0;
        }
    }
}