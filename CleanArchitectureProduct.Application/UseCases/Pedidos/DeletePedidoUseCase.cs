using CleanArchitectureProduct.Domain.Models;
using CleanArchitectureProduct.Domain.Repositories;

namespace CleanArchitectureProduct.Application.UseCases.Pedidos
{
    public class DeletePedidoUseCase
    {
        private readonly IPedidoRepository _pedidoRepository;

        public DeletePedidoUseCase(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public async Task<bool> ExecuteAsync(int pedidoId)
        {
            Pedido? pedidoExist = await _pedidoRepository.GetPedidoByIdAsync(pedidoId);

            if (pedidoExist == null)
            {
                return false;
            }

            await _pedidoRepository.DeletePedidoAsync(pedidoExist);

            return true;
        }
    }
}
