using System.Data;
using Axa.IntegracaoSistemas.Infraestructure.Repositories;
using Axa.IntegracaoSistemas.Infraestructure.Repositories.Abstract;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Axa.IntegracaoSistemas.Infraestructure.Configurations;

public static class ConfigureDatabase
{
    public static readonly string DefaultConnection = nameof(DefaultConnection);

    public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        // Default DatabaseContext
        services.AddScoped<SqlServerDatabaseContext>();
        services.AddScoped<IDbConnection>(x =>
            new SqlConnection(configuration.GetConnectionString(DefaultConnection)));

        return services;
    }
}