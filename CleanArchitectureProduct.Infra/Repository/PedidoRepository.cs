using CleanArchitectureProduct.Domain.Models;
using CleanArchitectureProduct.Domain.Repositories;
using CleanArchitectureProduct.Infra.Database;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureProduct.Infra.Repository
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly APIDBContext _dbContext;

        public PedidoRepository(APIDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Pedido> CreatePedidoAsync(Pedido pedido)
        {
            _dbContext.Pedidos?.Add(pedido);
            await _dbContext.SaveChangesAsync();
            return pedido;
        }

        public async Task DeletePedidoAsync(Pedido pedido)
        {
            _dbContext.Pedidos?.Remove(pedido);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Pedido?> GetPedidoByIdAsync(int id)
        {
            if (_dbContext.Items is not null && _dbContext.Produtos is not null && _dbContext.Pedidos is not null)
            {
                var pedidos =
                    from items in _dbContext.Items
                    join product in _dbContext.Produtos on items.ProdutoId equals product.Id
                    join pedido in _dbContext.Pedidos on items.PedidoId equals pedido.Id
                    where pedido.Id == id
                    select pedido;

                return await pedidos.FirstOrDefaultAsync();
            }

            return null;
        }

        public async Task UpdatePedidoAsync(Pedido pedido)
        {
            _dbContext.Entry(pedido).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
