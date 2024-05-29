using ApplianceX.Server.Api.Service;
using ApplianceX.Server.ExternalApi.Product;
using ApplianceX.Server.ExternalApi.ProductIdInfo;
using Microsoft.Extensions.Logging;

namespace ApplianceX.Server.Parsers;

public class RozetkaParser : IRozetkaParser
{
    private const string BaseUrl = "https://xl-catalog-api.rozetka.com.ua/v4/goods";

    private readonly ILogger<RozetkaParser> _logger;
    private readonly IBaseParser _baseParser;


    public RozetkaParser(ILogger<RozetkaParser> logger, IBaseParser baseParser)
    {
        _logger = logger;
        _baseParser = baseParser;
    }



    public async Task<ProductIdInfoData> GetByCategoryProductIds(string categoryId, string page, CancellationToken cancellationToken)
    {
        var url = BaseUrl + $"/get?front-type=xl&country=UA&lang=ua&page={page}&category_id={categoryId}&abt=1";

        var data = await _baseParser.ParseGet<ProductIdInfoData>(url, cancellationToken);

        return data;
    }
    
    
    
    public async Task<ProductData> GetFullProductInfoByIds(IEnumerable<int> ids, CancellationToken cancellationToken)
    {
        var preparedIds = string.Join(",", ids);
        
        var url = BaseUrl + $"/getDetails?country=UA&lang=ua&with_groups=1&with_docket=1&with_extra_info=1&goods_group_href=1&product_ids={preparedIds}";

        var data = await _baseParser.ParseGet<ProductData>(url, cancellationToken);

        return data;
    }
}