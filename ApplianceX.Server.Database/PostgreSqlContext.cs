using ApplianceX.Server.Database.Rozetka.Brand;
using ApplianceX.Server.Database.Rozetka.Category;
using ApplianceX.Server.Database.Rozetka.Product;
using ApplianceX.Server.Database.Rozetka.Product.Statistic;
using ApplianceX.Server.Database.Rozetka.Seller;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ApplianceX.Server.Database;

public class PostgreSqlContext : DbContext
{
    public readonly IDatabaseFacade Db;
    
    public DbSet<SellerModel> Seller { get; set; }
    public DbSet<ProductModel> Product { get; set; }
    public DbSet<CategoryModel> ProductCategory { get; set; }
    public DbSet<BrandModel> ProductBrand { get; set; }
    public DbSet<ProductStatisticModel> ProductStatistic { get; set; }
    

    public PostgreSqlContext(DbContextOptions<PostgreSqlContext> options, ILoggerFactory loggerFactory) : base(options)
    {
        Db = new DatabaseFacade(this, loggerFactory);
    }
}
