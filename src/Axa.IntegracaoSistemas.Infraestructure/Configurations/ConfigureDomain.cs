using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Axa.IntegracaoSistemas.Domain.CustomRepositories.Interfaces;
using Axa.IntegracaoSistemas.Domain.Entities;
using Axa.IntegracaoSistemas.Infraestructure.Repositories;
using GatewaySeguradora.Infraestructure.Repositories;
using GatewaySeguradora.Infraestructure.Repositories.Abstract;
using MicroOrm.Dapper.Repositories.Core;
using Microsoft.Extensions.DependencyInjection;

namespace Axa.IntegracaoSistemas.Infraestructure.Configurations;

public static class ConfigureRepositories
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        // Custom Queries
        // Exemplo retorno de classe customizada (que gerelmente representam joins de tabelas do banco de dados):  
        services.AddScoped<IClienteCustomRepository, ClienteCustomRepository>();

        // DapperRepositories        
        // Exemplo retorno de classes Entitiy (que geralmente representam tabelas do banco de dados)): 
        services.AddScoped<IDapperRepository<LogMonitor>, SqlServerDapperRepository<LogMonitor>>();

        return services;
    }

    public static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        // Domain Services

        return services;
    }
}
