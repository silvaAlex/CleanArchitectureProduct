using CleanArchitectureProduct.Domain.Repositories;
using CleanArchitectureProduct.Infra.Database;
using CleanArchitectureProduct.Infra.Repository;
using Microsoft.EntityFrameworkCore;

namespace ProductManagementStefanini.API.Extensions
{
    public static class BuilderExtensions
    {
        public static void AddRegiterServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
         
            services.AddDbContext<APIDBContext>(opts => opts.UseSqlServer(connectionString));

            services.AddScoped<IPedidoRepository,PedidoRepository>();
           
        }

        public static void UseMigrations(this WebApplication app)
        {
            using var serviceScope = app.Services.CreateScope();
            var context = serviceScope.ServiceProvider.GetRequiredService<APIDBContext>();
            context?.Database.EnsureCreated();
        }
    }
}
