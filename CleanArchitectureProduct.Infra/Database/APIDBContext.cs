using CleanArchitectureProduct.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureProduct.Infra.Database
{
    public class APIDBContext : DbContext
    {
        public DbSet<Pedido>? Pedidos { get; set; }
        public DbSet<ItemPedido>? Items { get; set; }
        public DbSet<Produto>? Produtos { get; set; }

        public APIDBContext(DbContextOptions<APIDBContext> options) : base(options) { }
    }
}
