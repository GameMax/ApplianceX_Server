using Microsoft.Extensions.Logging;

namespace ApplianceX.Server.Database.Product.Statistic;

public class ProductStatisticRepository : AbstractRepository<ProductStatisticModel>, IProductStatisticRepository
{
    public ProductStatisticRepository(PostgreSqlContext context, ILoggerFactory loggerFactory) : base(context, loggerFactory)
    {
    }
    
    
}