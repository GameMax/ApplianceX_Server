using System.Threading.Tasks;

namespace ApplianceX.Server.Database.Seller;

public interface ISellerRepository
{
    Task<SellerModel> Create(string name);
}