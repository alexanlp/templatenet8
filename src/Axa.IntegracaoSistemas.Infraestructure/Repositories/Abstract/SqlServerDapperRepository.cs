using Axa.IntegracaoSistemas.Infraestructure.Configurations;
using MicroOrm.Dapper.Repositories;
using MicroOrm.Dapper.Repositories.Core;
using MicroOrm.Dapper.Repositories.SqlGenerator;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace GatewaySeguradora.Infraestructure.Repositories.Abstract;

public abstract class SqlServerDapperRepository<TEntity> : DapperRepository<TEntity> where TEntity : class
{
    public SqlServerDapperRepository(IConfiguration configuration)
        : base(new SqlConnection(configuration.GetConnectionString(ConfigureDatabase.DefaultConnection)), new SqlGenerator<TEntity>(SqlProvider.MSSQL, false))
    {

    }
}
