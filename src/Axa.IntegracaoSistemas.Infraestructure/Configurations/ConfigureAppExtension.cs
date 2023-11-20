using CorrelationId;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

namespace Axa.IntegracaoSistemas.Infraestructure.Configurations;

public static class ConfigureAppExtension
{
    public static WebApplication Configure(this WebApplication app)
    {
        app.UseHttpsRedirection();

        app.MapControllers();

        return app;
    }
}