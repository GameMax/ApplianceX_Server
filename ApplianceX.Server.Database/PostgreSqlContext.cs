using ApplianceX.Server.Database.Fridge;
using ApplianceX.Server.Database.Seller;
using ApplianceX.Server.Database.Seller.Statistic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ApplianceX.Server.Database;

public class PostgreSqlContext : DbContext
{
    public readonly DatabaseFacade Db;
    
    
    public DbSet<SellerModel> Seller { get; set; }
    public DbSet<SellerStatisticModel> SellerStatistic { get; set; }
    // public DbSet<FridgeModel> Fridge { get; set; }
    
    

    public PostgreSqlContext(DbContextOptions<PostgreSqlContext> options, ILoggerFactory loggerFactory) : base(options)
    {
        Db = new DatabaseFacade(this, loggerFactory);
    }
}