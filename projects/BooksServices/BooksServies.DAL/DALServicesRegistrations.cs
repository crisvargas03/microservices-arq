using BooksServies.DAL.Context;
using BooksServies.DAL.Core.Interfaces.Books;
using BooksServies.DAL.Core.Repository.Books;
using BooksServies.DAL.Core.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BooksServies.DAL
{
    public static class DALServicesRegistrations
    {
        private static void AddDbContextService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BookDbContext>(op =>
            {
                var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING")
                                       ?? configuration.GetConnectionString("MainDB");
                op.UseSqlServer(connectionString);
            });
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBooksRepository, BooksRepository>();
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
