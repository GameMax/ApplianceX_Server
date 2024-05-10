using System.Text.Json.Serialization;

namespace ApplianceX.Server.ExternalApi.Product;

public class Product
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public int? Price { get; set; }

    [JsonPropertyName("old_price")]
    public int? OldPrice { get; set; }

    public string? Href { get; set; } // да. Можешь до 12:00 спать потом посмотришь   иди спать  потом скачаешь ок и внутри рар там оставить текст или тг шо хоч  сек
    
    [JsonPropertyName("status")]
    public string? Status { get; set; }
    
    [JsonPropertyName("sell_status")]
    public string? SellStatus { get; set; }

    [JsonPropertyName("category_id")]
    public int? CategoryId { get; set; }

    [JsonPropertyName("seller_id")]
    public int? SellerId { get; set; }

    public string? Brand { get; set; }

    [JsonPropertyName("group_name")]
    public string? GroupName { get; set; }
    
    [JsonPropertyName("group_title")]
    public string? GroupTitle { get; set; }
    
    public Docket[]? Docket { get; set; }

    [JsonPropertyName("comments_amount")]
    public int? CommentsAmount { get; set; }

    [JsonPropertyName("image_main")]
    public string? ImageMain { get; set; }
    
    public ProductSeller? Seller { get; set; }
    
    public ProductCategory? Category { get; set; }

    public int? Discount { get; set; }
}