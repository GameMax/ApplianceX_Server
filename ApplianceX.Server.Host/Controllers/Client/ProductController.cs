using System.Threading.Tasks;
using ApplianceX.Server.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApplianceX.Server.Host.Controllers.Client;

public class ProductController : AbstractClientController<ProductController>
{
    public ProductController(PostgreSqlContext context, ILoggerFactory loggerFactory) : base(context, loggerFactory)
    {
    }


    [HttpGet]
    public async Task<IActionResult> GetPopularProducts()
    {
        var collection = await Db.ProductRepository.ListPopular();

        return SendOk(collection);
    }
}