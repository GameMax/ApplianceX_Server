using ApplianceX.Server.Database.Seller;
using ApplianceX.Server.Database.Seller.Statistic;
using Microsoft.Extensions.Logging;

namespace ApplianceX.Server.Database;

public class DatabaseFacade : IDatabaseFacade
{
    public ISellerRepository SellerRepository { get; }

    public ISellerStatisticRepository SellerStatisticRepository { get; }

    
    
    public DatabaseFacade(PostgreSqlContext context, ILoggerFactory loggerFactory)
    {
        SellerRepository = new SellerRepository(context, loggerFactory);
        SellerStatisticRepository = new SellerStatisticRepository(context, loggerFactory);
    }
}