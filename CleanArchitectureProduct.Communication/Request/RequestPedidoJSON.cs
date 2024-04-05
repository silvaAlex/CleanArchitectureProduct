

using CleanArchitectureProduct.Domain.Models;

namespace CleanArchitectureProduct.Communication.Request
{
    public class RequestPedidoJSON
    {
        public string NomeCliente { get; set; } = string.Empty;
        public string EmailCliente { get; set; } = string.Empty;
        public bool Pago { get; set; } = false;
        public IList<RequestItemPedidoJSON>? Pedidos { get; set; }

        public Pedido? MapTo(RequestPedidoJSON data)
        {
            if (data is not null) {

                if (data.Pedidos is not null)
                {
                    IList<ItemPedido> pedidos = new RequestItemPedidoJSON().MapTo(data.Pedidos);

                    return new Pedido()
                    {
                        NomeCliente = data.NomeCliente,
                        EmailCliente = data.EmailCliente,
                        Pago = data.Pago,
                        Pedidos = pedidos,
                    };
                }
            }

            return null;
        }
    }
}
