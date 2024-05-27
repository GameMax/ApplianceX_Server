using Microsoft.Extensions.Logging;

namespace ApplianceX.Server.Database.Rozetka.Category;

public class CategoryRepository : AbstractRepository<CategoryModel>, ICategoryRepository
{

    public CategoryRepository(PostgreSqlContext context, ILoggerFactory loggerFactory) : base(context, loggerFactory)
    {
    }
}