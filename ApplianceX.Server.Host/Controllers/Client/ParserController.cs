using System.Threading;
using System.Threading.Tasks;
using ApplianceX.Server.Api.Service;
using ApplianceX.Server.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApplianceX.Server.Host.Controllers.Client;

public class ParserController : AbstractClientController<ParserController>
{
    private readonly IBaseParser _parser;

    public ParserController(PostgreSqlContext context, ILoggerFactory loggerFactory, IBaseParser parser) : base(context, loggerFactory)
    {
        _parser = parser;
    }

    // [HttpGet]
    // public async Task<IActionResult> GetItemIdsByCategoryId(string categoryId = "80125", string page = "1")
    // {
    //     var preparedLink = $"https://xl-catalog-api.rozetka.com.ua/v4/goods/get?front-type=xl&country=UA&lang=ua&page={page}&category_id={categoryId}&abt=1";
    //     var data = await _parser.ParseGet<object>(preparedLink, new CancellationToken());
    //
    //     return SendOk(data);
    // }
    //
    //
    // [HttpGet]
    // public async Task<IActionResult> GetFullItemInfoById(string id)
    // {
    //     // var preparedIdsString = string.Join(",", ids);
    //     var preparedLink = $"https://xl-catalog-api.rozetka.com.ua/v4/goods/getDetails?country=UA&lang=ua&with_groups=1&with_docket=1&with_extra_info=1&goods_group_href=1&product_ids={id}";
    //     var data = await _parser.ParseGet<object>(preparedLink, new CancellationToken());
    //
    //     return SendOk(data);
    // }
}