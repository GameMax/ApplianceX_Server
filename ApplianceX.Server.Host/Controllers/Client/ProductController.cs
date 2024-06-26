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


    [HttpGet]
    public async Task<IActionResult> GetProductsByCategory(string category)
    {
        var collection = await Db.ProductRepository.ListProductByCategory(category);

        return SendOk(collection);
    }


    [HttpGet]
    public async Task<IActionResult> GetProductsByCategoryId(int categoryId)
    {
        var collection = await Db.ProductRepository.ListProductByCategoryId(categoryId);

        return SendOk(collection);
    }
}