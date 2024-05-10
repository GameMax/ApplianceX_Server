using ApplianceX.Server.Database.Product.Statistic;
using ApplianceX.Server.Database.Seller;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ApplianceX.Server.Database;

public class PostgreSqlContext : DbContext
{
    public readonly DatabaseFacade Db;
    
    
    public DbSet<SellerModel> Seller { get; set; }
    

    public PostgreSqlContext(DbContextOptions<PostgreSqlContext> options, ILoggerFactory loggerFactory) : base(options)
    {
        Db = new DatabaseFacade(this, loggerFactory);
    }
}