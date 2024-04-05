
using CleanArchitectureProduct.Domain.Models;
using CleanArchitectureProduct.Exception;

namespace CleanArchitectureProduct.Communication.Request
{
    public class RequestItemPedidoJSON
    {
        public int Quantidade { get; set; }
        public RequestProdutoJSON? Produto { get; set; }

        public IList<ItemPedido> MapTo(IList<RequestItemPedidoJSON> data)
        {
            IList<ItemPedido> items = new List<ItemPedido>();

            if (data is not null)
            {
                foreach (var item in data)
                {
                    items.Add(new ItemPedido()
                    {
                        Quantidade = item.Quantidade,
                        Produto = new Produto()
                        {
                            NomeProduto = item.Produto?.NomeProduto ?? string.Empty,
                            Preco = item.Produto?.Preco ?? 0,
                        }
                    });
                }
            }

            return items;
        }

        public static void Validate(IList<RequestItemPedidoJSON> request)
        {
            foreach(var item in request)
            {
                if (item.Quantidade <= 0)
                {
                    throw new CleanArchitectureProductException("Quantidade inválida");
                }

                if (item.Produto == null)
                {
                    throw new CleanArchitectureProductException("Produto inválido");
                }

                if (string.IsNullOrWhiteSpace(item.Produto.NomeProduto))
                {
                    throw new CleanArchitectureProductException("Nome produto inválido");
                }

                if (item.Produto.Preco <= 0)
                {
                    throw new CleanArchitectureProductException("Preço produto inválido");
                }
            }
            
        }
    }
}