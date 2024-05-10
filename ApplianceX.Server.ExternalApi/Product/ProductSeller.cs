using System.Text.Json.Serialization;

namespace ApplianceX.Server.ExternalApi.Product;

public class ProductSeller
{
    public string? Id { get; set; }
    
    public string? Title { get; set; }

    public string? Rank { get; set; }
    
    [JsonPropertyName("count_votes")]
    public int? CountVotes { get; set; }
    
    public string? Logo { get; set; }
}