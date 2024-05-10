using System.Threading;
using System.Threading.Tasks;

namespace ApplianceX.Server.Api.Service;

public interface IBaseParser
{
    Task<T> ParseGet<T>(string url, CancellationToken cancellationToken);
}