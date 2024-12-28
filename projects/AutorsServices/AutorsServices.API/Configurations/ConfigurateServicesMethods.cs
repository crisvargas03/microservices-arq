using AutorsServices.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace AutorsServices.API.Configurations;

public static class ConfigurateServicesMethods
{
    private static void ConfigurateDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AutorDbContext>(op =>
        {
            var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING")
                                   ?? configuration.GetConnectionString("MainDB");

            op.UseNpgsql(connectionString);
        });
    }

    private static void ConfigurateCors(this IServiceCollection services)
    {
        services.AddCors(p =>
            p.AddPolicy("cors", builder => { builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader(); }));
    }

    private static void ConfigurateServices(this IServiceCollection services)
    {
        // services.AddScoped<IUserService, UserServices>();
        // services.AddScoped<IJwtService, JwtServices>();
    }

    private static void ConfigurateUnitOfWork(this IServiceCollection services)
    {
        // services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
    
    private static void ConfigurateAutomapper(this IServiceCollection services) 
    {
        // services.AddAutoMapper(typeof(MapperConfigurations));
    }

    public static void ApplyServicesConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.ConfigurateDbContext(configuration);
        services.ConfigurateUnitOfWork();
        services.ConfigurateAutomapper();
        services.ConfigurateServices();
        services.ConfigurateCors();
    }
}