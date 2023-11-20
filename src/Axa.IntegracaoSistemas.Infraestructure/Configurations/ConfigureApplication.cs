using Axa.IntegracaoSistemas.Application.Features.NovoCliente;
using BuildingBlocks.Notification.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Axa.IntegracaoSistemas.Infraestructure.Configurations;

public static class ConfigureApplication
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Infraestrutura
        services.AddNotificationContext();

        // Serviços de Aplicação
        // Exemnplo: 
        services.AddScoped<INovoClienteAppService, NovoClienteAppService>();
        
        return services;
    }
}
