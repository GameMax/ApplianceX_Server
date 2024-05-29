using System.Threading.Tasks;

namespace ApplianceX.Server.Database.Rozetka.Brand;

public interface IBrandRepository
{
    Task<BrandModel> CreateModel(string title);

    Task<BrandModel?> FindOne(string title);
}