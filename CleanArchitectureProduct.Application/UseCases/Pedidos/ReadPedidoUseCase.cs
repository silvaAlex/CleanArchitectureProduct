using CleanArchitectureProduct.Domain.Models;
using CleanArchitectureProduct.Domain.Repositories;

namespace CleanArchitectureProduct.Application.UseCases.Pedidos
{
    public class ReadPedidoUseCase
    {
        private readonly IPedidoRepository _pedidoRepository;

        public ReadPedidoUseCase(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public async Task<Pedido?> ExecuteAsync(int pedidoId)
        {
            return await _pedidoRepository.GetPedidoByIdAsync(pedidoId);
        }
    }
}
