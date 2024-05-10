using System.Text.Json.Serialization;

namespace ApplianceX.Server.ExternalApi.Fridge;

public class Fridge
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public int? Price { get; set; }

    [JsonPropertyName("old_price")]
    public int? OldPrice { get; set; }

    public string? Href { get; set; }

    [JsonPropertyName("category_id")]
    public int? CategoryId { get; set; }

    public string? Brand { get; set; }

    [JsonPropertyName("group_title")]
    public string? GroupTitle { get; set; }

    [JsonPropertyName("comments_amount")]
    public int? CommentsCount { get; set; }

    [JsonPropertyName("image_main")]
    public string? ImageMain { get; set; }

    public FridgeSeller? Seller { get; set; }

    public FridgeCategory? Category { get; set; }

    public int? Discount { get; set; }
}