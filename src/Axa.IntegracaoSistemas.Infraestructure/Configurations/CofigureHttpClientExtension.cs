using Axa.IntegracaoSistemas.Application.Core.Interfaces;
using Axa.IntegracaoSistemas.Application.Features.NovoCliente;
using Axa.IntegracaoSistemas.Infraestructure.ClientApi;
using Axa.IntegracaoSistemas.Infraestructure.ClientApi.NovoCliente;
using Axa.IntegracaoSistemas.Infraestructure.ClientApi.NumeroApolice;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Axa.IntegracaoSistemas.Infraestructure.Configurations.HttpClientConfiguration;

public static class CofigureHttpClientExtension
{
    public static IServiceCollection AddHttpClientConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        var seguradoraxptoClient = nameof(ApplicationOptions.SeguradoraXPTOClient);
        services
            .AddHttpClient<IRequestClient<NovoClienteDTORequest, NovoClienteDTOResponse>, NovoClienteClient, NovoClienteClientOptions>(configuration,
                seguradoraxptoClient);
            
        return services;
    }
}
