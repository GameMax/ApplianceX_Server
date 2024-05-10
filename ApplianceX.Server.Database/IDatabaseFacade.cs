using ApplianceX.Server.Database.Product.Statistic;
using ApplianceX.Server.Database.Seller;

namespace ApplianceX.Server.Database;

public interface IDatabaseFacade
{
    ISellerRepository SellerRepository { get; }
}