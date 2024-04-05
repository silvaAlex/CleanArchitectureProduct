using CleanArchitectureProduct.Domain.Models;
using CleanArchitectureProduct.Domain.Repositories;

namespace CleanArchitectureProduct.Application.UseCases.Pedidos
{
    public class UpdatePedidoUseCase
    {
        private readonly IPedidoRepository _pedidoRepository;

        public UpdatePedidoUseCase(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public async Task<bool> ExecuteAsync(int pedidoId, bool paid)
        {
            Pedido? pedidoExist = await _pedidoRepository.GetPedidoByIdAsync(pedidoId);

            if (pedidoExist == null)
            {
                return false;
            }

            pedidoExist.Pago = paid;

            await _pedidoRepository.UpdatePedidoAsync(pedidoExist);
            return true;
        }
    }
}
