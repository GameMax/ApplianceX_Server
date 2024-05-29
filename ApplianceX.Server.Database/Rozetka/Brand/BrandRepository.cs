using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ApplianceX.Server.Database.Rozetka.Brand;

public class BrandRepository : AbstractRepository<BrandModel>, IBrandRepository
{
    public BrandRepository(PostgreSqlContext context, ILoggerFactory loggerFactory) : base(context, loggerFactory)
    {
    }

    public async Task<BrandModel> CreateModel(string title)
    {
        var model = BrandModel.CreateModel(title);
        
        var result = await CreateModelAsync(model);
        if (result == null)
        {
            throw new Exception("Brand model is not created");
        }
        
        return result;
    }


    public async Task<BrandModel?> FindOne(string title)
    {
        var model = await DbModel.FirstOrDefaultAsync(x => x.Title == title);
        return model;
    }
}