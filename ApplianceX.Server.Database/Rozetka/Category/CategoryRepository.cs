using System;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ApplianceX.Server.Database.Rozetka.Category;

public class CategoryRepository : AbstractRepository<CategoryModel>, ICategoryRepository
{
    public CategoryRepository(PostgreSqlContext context, ILoggerFactory loggerFactory) : base(context, loggerFactory)
    {
    }


    public async Task<CategoryModel> CreateModel(string title, string cover, string categoryUid, DateTime createdAt)
    {
        var model = CategoryModel.CreateModel(title, cover, categoryUid, createdAt);

        var result = await CreateModelAsync(model);
        if (result == null)
        {
            throw new Exception("Category model is not created");
        }

        return result;
    }



    public async Task<ImmutableArray<string>> ListAllCategoryUIds()
    {
        var collection = await DbModel.Select(x => x.CategoryUid!).ToListAsync();
        return collection.ToImmutableArray();
    }



    public async Task<CategoryModel> FindOne(string title)
    {
        var model = await DbModel.FirstOrDefaultAsync(x => x.Title == title);
        return model;
    }
}