using CartServices.BLL.Features.ExternalServices.BooksApi;
using CartServices.BLL.Features.ExternalServices.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CartServices.BLL
{
    public static class BLLServicesRegistration
    {
        private static void AddAutomapperService(this IServiceCollection services)
        {
            // services.AddAutoMapper(Assembly.GetAssembly(typeof(BooksMappingProfle)));
        }

        private static void AddMediator(this IServiceCollection services)
        {
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });
        }

        private static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IBookExternalServices, BookExternalServices>();
        }

        private static void AddHttpClientConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient("BooksApi", c =>
            {
                c.BaseAddress = new Uri(configuration["Services:Books"]!);
            });

            services.AddHttpClient("AutorsApi", c =>
            {
                c.BaseAddress = new Uri(configuration["Services:Autors"]!);
            });
        }

        public static void AddBusinessLogicLayerServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClientConfig(configuration);
            services.AddAutomapperService();
            services.AddMediator();
            services.AddServices();
        }
    }
}
