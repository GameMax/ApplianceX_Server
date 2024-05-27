using Microsoft.Extensions.Logging;

namespace ApplianceX.Server.Database.Rozetka.Brand;

public class BrandRepository : AbstractRepository<BrandModel>, IBrandRepository
{
    public BrandRepository(PostgreSqlContext context, ILoggerFactory loggerFactory) : base(context, loggerFactory)
    {
    }
}