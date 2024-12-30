using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AutorsServices.BLL
{
    public static class ConfigurateBLLServices
    {
        public static void ConfigurateMediator(this IServiceCollection services)
        {
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });
        }

        public static void ConfigurateValidator(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
