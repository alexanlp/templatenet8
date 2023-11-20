using System.Data;
using MicroOrm.Dapper.Repositories.DbContext;

namespace Axa.IntegracaoSistemas.Infraestructure.Repositories.Abstract;

public abstract class SqlServerDatabaseContext : DapperDbContext
{
    public SqlServerDatabaseContext(IDbConnection connection, bool useQuotationMarks = false)
        : base(connection)
    {
    }
}