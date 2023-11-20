using Axa.IntegracaoSistemas.Infraestructure.Configurations;
using BuildingBlocks.Middeware.Extensions;
using BuildingBlocks.Middleware.CorrelationID;
using Serilog;

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Configuração do Serilog
    ConfigureLoggingExtension.Configure(builder);
    Log.Information("Starting web host");

    // Configurações dos serviços da Aplicação
    builder.ConfigureServices();


    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    // Configuração do Serilog usar a interface ILogger
    app.UseSerilogRequestLogging();

    app.UseExceptionMiddleware()
        .UseCorrelationIdMiddleware();

    // Configurações gerais da aplicação
    app.Configure();

    Log.Information("Application running");

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
    throw;
}
finally
{
    Log.CloseAndFlush();
}
