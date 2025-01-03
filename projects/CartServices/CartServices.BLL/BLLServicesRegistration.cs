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

        public static void AddMediator(this IServiceCollection services)
        {
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });
        }

        public static void AddBusinessLogicLayerServices(this IServiceCollection services)
        {
            services.AddAutomapperService();
            services.AddMediator();
        }
    }
}
