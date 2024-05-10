using System.Text.Json.Serialization;

namespace ApplianceX.Server.ExternalApi.Product;

public class ProductCategory
{
    public string? Title { get; set; }  

    public string? Href { get; set; }

    [JsonPropertyName("root_category_title")]
    public string? RootCategoryTitle { get; set; }
}