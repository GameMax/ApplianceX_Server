using System;
using System.Threading.Tasks;
using ApplianceX.Server.ExternalApi.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ApplianceX.Server.Database.Rozetka.Seller;

public class SellerRepository : AbstractRepository<SellerModel>, ISellerRepository
{
    public SellerRepository(PostgreSqlContext context, ILoggerFactory loggerFactory) : base(context, loggerFactory)
    {
    }


    public async  Task<SellerModel> CreateModel(ProductSeller apiModel, DateTime createdAt)
    {
        var model = SellerModel.CreateModel(apiModel, createdAt);
        
        var result = await CreateModelAsync(model);
        if (result == null)
        {
            throw new Exception("Seller model is not created");
        }
        
        return result;
    }

    
    public async Task<SellerModel?> FindOne(string seller)
    {
        var model = await DbModel.FirstOrDefaultAsync(x => x.Seller == seller);
        return model;
    }
}