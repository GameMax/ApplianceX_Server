using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace ApplianceX.Server.Database.Seller;

public class SellerRepository : AbstractRepository<SellerModel>, ISellerRepository
{
    public SellerRepository(PostgreSqlContext context, ILoggerFactory loggerFactory) : base(context, loggerFactory)
    {
    }

    
    public async Task<SellerModel> Create(string name)
    {
        var model = SellerModel.CreateModel(name);

        var result = await CreateModelAsync(model);
        if (result == null)
        {
            throw new Exception("Seller model is not created");
        }

        return result;
    }
}