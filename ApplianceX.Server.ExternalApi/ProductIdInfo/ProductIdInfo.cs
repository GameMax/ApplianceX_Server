using System.Text.Json.Serialization;

namespace ApplianceX.Server.ExternalApi.ProductIdInfo;

public class ProductIdInfo
{
    public int[] Ids { get; set; }

    [JsonPropertyName("total_pages")]
    public int TotalPages { get; set; }
}