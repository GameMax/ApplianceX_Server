using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;

namespace ApplianceX.Server.Database.Rozetka.Product;

public interface IProductRepository
{
    Task<bool> CreateBulk(ImmutableArray<ProductModel> collection);

    Task<bool> UpdateBulk(ImmutableArray<ProductModel> collection);

    Task<ImmutableArray<ProductModel>> ListAllProducts(ImmutableArray<string> titles);

    Task<ImmutableArray<ProductModel>> ListAll();
    
    Task<List<ProductModel>> ListPopular();
    
    Task<List<ProductModel>> ListProductByCategory(string category);
    
    Task<List<ProductModel>> ListProductByCategoryId(int categoryId);
}