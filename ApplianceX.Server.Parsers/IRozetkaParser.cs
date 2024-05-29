using ApplianceX.Server.ExternalApi.Product;
using ApplianceX.Server.ExternalApi.ProductIdInfo;

namespace ApplianceX.Server.Parsers;

public interface IRozetkaParser
{
    Task<ProductIdInfoData> GetByCategoryProductIds(string categoryId, string page, CancellationToken cancellationToken);
    
    Task<ProductData> GetFullProductInfoByIds(IEnumerable<int> ids, CancellationToken cancellationToken);
}