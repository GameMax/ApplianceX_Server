using System.Text.Json.Serialization;

namespace ApplianceX.Server.ExternalApi.Product;

public class Docket
{
    [JsonPropertyName("option_id")]
    public int? OptionId { get; set; }

    [JsonPropertyName("option_name")]
    public string? OptionName { get; set; }

    [JsonPropertyName("option_title")]
    public string? OptionTitle { get; set; }

    [JsonPropertyName("value_title")]
    public string? ValueTitle { get; set; }
}