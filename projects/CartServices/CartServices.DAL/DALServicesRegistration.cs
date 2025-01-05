using CartServices.DAL.Context;
using CartServices.DAL.Core.Interfaces;
using CartServices.DAL.Core.Repository;
using CartServices.DAL.Core.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CartServices.DAL
{
    public static class DALServicesRegistration
    {
        private static void AddDbContextService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ShoppingCartDbContext>(op =>
            {
                var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING")
                                       ?? configuration.GetConnectionString("MainDB");
                op.UseSqlServer(connectionString);
            });
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            // services.AddScoped<IBooksRepository, BooksRepository>();
            services.AddScoped<IShoppingCartDetailsRepository, ShoppingCartDetailsRepository>();
            services.AddScoped<IShoppingCartRepository, ShoppingCartRepository>();
        }

        private static void AddUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static void AddDataAccessLayerServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextService(configuration);
            services.AddRepositories();
            services.AddUnitOfWork();
        }

    }
}
