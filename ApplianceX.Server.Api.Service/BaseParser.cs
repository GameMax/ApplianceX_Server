using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace ApplianceX.Server.Api.Service;

public class BaseParser : IBaseParser
{
    private readonly HttpClient _client;
    private readonly ILogger<BaseParser> _logger;

    public BaseParser(HttpClient client, ILogger<BaseParser> logger)
    {
        _client = client;
        _logger = logger;
    }


    public async Task<T> ParseGet<T>(string url, CancellationToken cancellationToken)
    {
        _client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.3");
        var response = await _client.GetAsync(url, cancellationToken);

        var scriptText = await response.Content.ReadAsStringAsync(cancellationToken);

        var appData = JsonSerializer.Deserialize<T>(scriptText, JsonSerializerOptions);

        return appData;
    }

    private static readonly JsonSerializerOptions JsonSerializerOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };
}