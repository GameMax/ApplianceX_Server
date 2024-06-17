using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ApplianceX.Server.Database.Rozetka.Product;

public class ProductRepository : AbstractRepository<ProductModel>, IProductRepository
{
    public ProductRepository(PostgreSqlContext context, ILoggerFactory loggerFactory) : base(context, loggerFactory)
    {
    }

    public async Task<bool> CreateBulk(ImmutableArray<ProductModel> collection)
    {
        var result = await CreateBulkModelsAsync(collection);
        if (result == null)
        {
            throw new Exception("Products are not created. Create Bulk error");
        }

        return true;
    }


    public async Task<bool> UpdateBulk(ImmutableArray<ProductModel> collection)
    {
        var result = await UpdateBulkModelsAsync(collection);
        if (result == null)
        {
            throw new Exception("Products are not updated. Update Bulk error");
        }

        return true;
    }


    public async Task<ImmutableArray<ProductModel>> ListAllProducts(ImmutableArray<string> titles)
    {
        var collection = await DbModel.Where(x => titles.Contains(x.Title!)).ToListAsync();

        return collection.ToImmutableArray();
    }


    public async Task<ImmutableArray<ProductModel>> ListAll()
    {
        var collection = await DbModel.
            OrderBy(x => x.CreatedAt).
            Include(x => x.Category).
            Include(x => x.Brand).
            Include(x=> x.SellerModel).
            ToListAsync();
        
        return [..collection];
    }
    
    
    public async Task<List<ProductModel>> ListPopular()
    {
       return await DbModel
            .OrderByDescending(x => x.CommentsAmount)
            .Skip(0)
            .Take(15)
            .Include(x => x.Category)
            .Include(x => x.Brand)
            .Include(x => x.SellerModel)
            .AsSplitQuery()
            .ToListAsync();
    }
}