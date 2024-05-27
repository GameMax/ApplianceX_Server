using Microsoft.Extensions.Logging;

namespace ApplianceX.Server.Database.Rozetka.Product;

public class ProductRepository : AbstractRepository<ProductModel>, IProductRepository
{
    public ProductRepository(PostgreSqlContext context, ILoggerFactory loggerFactory) : base(context, loggerFactory)
    {
    }
}