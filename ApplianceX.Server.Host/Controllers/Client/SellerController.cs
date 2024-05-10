using System.Threading.Tasks;
using ApplianceX.Server.Client.Codec;
using ApplianceX.Server.Client.Seller;
using ApplianceX.Server.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApplianceX.Server.Host.Controllers.Client;

public class SellerController : AbstractClientController<SellerController>
{
    public SellerController(PostgreSqlContext context, ILoggerFactory loggerFactory) : base(context, loggerFactory)
    {
    }


    [HttpPost]
    public async Task<IActionResult> CreateSeller([FromBody] CreateSeller request)
    {
        return SendOk();
        /*
        var model = await Db.SellerRepository.Create(request.Name);
        
        return SendOk(SellerCodec.EncodeSeller(model));
        */
    }
}