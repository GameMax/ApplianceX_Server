using System;
using System.Collections.Immutable;
using System.Threading.Tasks;

namespace ApplianceX.Server.Database.Rozetka.Category;

public interface ICategoryRepository
{
   Task<CategoryModel> CreateModel(string title, string? cover, string? categoryUid, DateTime createdAt);

   Task<ImmutableArray<string>> ListAllCategoryUIds();

   Task<CategoryModel?> FindOne(string title);
}