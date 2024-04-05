using CleanArchitectureProduct.Domain.Models;

namespace CleanArchitectureProduct.Domain.Repositories
{
    public interface IPedidoRepository
    {
        Task<Pedido?> GetPedidoByIdAsync(int id);
        Task<Pedido> CreatePedidoAsync(Pedido pedido);
        Task UpdatePedidoAsync(Pedido pedido);
        Task DeletePedidoAsync(Pedido pedido);
    }
}
