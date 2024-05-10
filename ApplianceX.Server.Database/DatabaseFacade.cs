using ApplianceX.Server.Database.Product.Statistic;
using ApplianceX.Server.Database.Seller;
using Microsoft.Extensions.Logging;

namespace ApplianceX.Server.Database;

public class DatabaseFacade : IDatabaseFacade
{
    public ISellerRepository SellerRepository { get; }

    
    
    public DatabaseFacade(PostgreSqlContext context, ILoggerFactory loggerFactory)
    {
        SellerRepository = new SellerRepository(context, loggerFactory);
    }
}