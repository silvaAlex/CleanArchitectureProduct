using CleanArchitectureProduct.Communication.Request;
using CleanArchitectureProduct.Communication.Response;
using CleanArchitectureProduct.Domain.Models;
using CleanArchitectureProduct.Domain.Repositories;
using CleanArchitectureProduct.Exception;

namespace CleanArchitectureProduct.Application.UseCases.Pedidos
{
    public class CreatePedidoUseCase
    {
        private readonly IPedidoRepository _pedidoRepository;

        public CreatePedidoUseCase(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public async Task<ResponseRegisteredPedidoJSON?> Execute(RequestPedidoJSON request)
        {
           Validate(request);

            Pedido? newPedido = new RequestPedidoJSON().MapTo(request);

            if (newPedido is not null)
            {
                Pedido pedido = await _pedidoRepository.CreatePedidoAsync(newPedido);

                return new ResponseRegisteredPedidoJSON
                {
                    Id = pedido.Id,
                };
            }

            return null;
        }

        private void Validate(RequestPedidoJSON request)
        {
            if (string.IsNullOrWhiteSpace(request.NomeCliente))
            {
                throw new CleanArchitectureProductException("Nome cliente inválido");
            }

            if (string.IsNullOrWhiteSpace(request.EmailCliente))
            {
                throw new CleanArchitectureProductException("Email cliente inválido");
            }

            if(request.Pedidos?.Count <= 0) 
            {
                throw new CleanArchitectureProductException("Pedidos não contém itens válidos");
            }

            if(request.Pedidos is not null)
            {
                RequestItemPedidoJSON.Validate(request.Pedidos);
            }
        }
    }
}
