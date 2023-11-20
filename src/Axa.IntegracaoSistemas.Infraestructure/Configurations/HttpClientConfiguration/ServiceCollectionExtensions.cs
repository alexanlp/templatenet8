using Axa.IntegracaoSistemas.Application.Options.Application.Core.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Axa.IntegracaoSistemas.Infraestructure.Configurations.HttpClientConfiguration;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddHttpClient<TClient, TImplementation, TClientOptions>(
        this IServiceCollection services,
        IConfiguration configuration,
        string configurationSectionName)
        where TClient : class
        where TImplementation : class, TClient
        where TClientOptions : HttpClientOptions, new() =>
        services
            .Configure<TClientOptions>(configuration.GetSection(configurationSectionName))
            .AddHttpClient<TClient, TImplementation>()
            .ConfigureHttpClient(
                    (serviceProvider, httpClient) =>
                    {
                        var httpClientOptions = serviceProvider
                            .GetRequiredService<IOptions<TClientOptions>>()
                            .Value;
                        httpClient.BaseAddress = httpClientOptions.BaseAddress;
                        httpClient.Timeout = httpClientOptions.Timeout;
                    })
            .ConfigurePrimaryHttpMessageHandler(x => new DefaultHttpClientHandler())
            .Services;

    public static IServiceCollection AddCacheConfiguration(this IServiceCollection services,
        IConfiguration configuration,
        string configurationSectionName)
    {
        services.Configure<List<CacheConfigurationOptions>>(configuration.GetSection(configurationSectionName));
        return services;
    }
}
