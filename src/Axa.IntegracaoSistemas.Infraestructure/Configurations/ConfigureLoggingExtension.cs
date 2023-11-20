using GatewayAxa.IntegracaoSistemasSeguradora.Application.Core.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace Axa.IntegracaoSistemas.Infraestructure.Configurations;

public static class ConfigureLoggingExtension
{
    public static void Configure(this WebApplicationBuilder builder)
    {
        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(builder.Configuration)
            .Enrich.WithCorrelationIdHeader(HeaderNamesExtension.GTI_CORRELATION_ID)
            .MinimumLevel.Information()
            .WriteTo.Console()
            .CreateLogger();

        // Permitir o uso da interface ILogger                
        builder.Host.UseSerilog(Log.Logger);

        // Manter o correlationId em todas as linhas de log do contexto
        builder.Services.AddHttpContextAccessor();
    }
}