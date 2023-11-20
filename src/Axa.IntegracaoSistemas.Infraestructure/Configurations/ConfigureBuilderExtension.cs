using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using BuildingBlocks.Middleware.CorrelationID;
using BuildingBlocks.Middeware.Extensions;
using BuildingBlocks.Notification.Extensions;
using BuildingBlocks.Notification.Filters;
using Axa.IntegracaoSistemas.Infraestructure.Resolvers;
using Axa.IntegracaoSistemas.Infraestructure.Configurations.HttpClientConfiguration;
using Axa.IntegracaoSistemas.Application.Core.Extensions;

namespace Axa.IntegracaoSistemas.Infraestructure.Configurations;

public static class ConfigureBuilderExtension
{
    public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddNotificationContext();

        builder.Services.AddControllers(options =>
        {
            options.ModelValidatorProviders.Clear();
            options.Filters.Add(typeof(NotificationFilter));
        }).AddJsonOptions(o =>
        {
            o.JsonSerializerOptions.PropertyNamingPolicy = new LowercaseContractResolver();
            o.JsonSerializerOptions.Encoder = System.Text.Encodings.Web.JavaScriptEncoder.Create(System.Text.Unicode.UnicodeRanges.All);
        });

        builder.Services.AddMemoryCache();

        // Configurações genéricas de infraestrutura da aplicação
        builder.Services
            .AddExceptionMiddleware()
            .AddCorrelationIdMiddleware();

        // Configurações de HttpClient
        builder.Services.AddHttpClientConfiguration(builder.Configuration);

        // Gurada as configurações de cache da aplicação            
        builder.Services.AddCacheConfiguration(builder.Configuration, CacheKeysExtension.CONFIG_CACHE_SeguradoraXPTO_API); 

        // Dependencias da aplicação
        builder.Services
            .AddDbContext(builder.Configuration)
            .AddApplication()
            .AddRepositories()
            .AddDomainServices();

        return builder;
    }
}