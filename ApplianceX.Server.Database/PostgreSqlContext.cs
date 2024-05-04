using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ApplianceX.Server.Database;

public class PostgreSqlContext : DbContext
{
    public PostgreSqlContext(DbContextOptions<PostgreSqlContext> options, ILoggerFactory loggerFactory) : base(options)
    { 
    }
}