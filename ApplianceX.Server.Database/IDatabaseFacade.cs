using ApplianceX.Server.Database.Seller;
using ApplianceX.Server.Database.Seller.Statistic;

namespace ApplianceX.Server.Database;

public interface IDatabaseFacade
{
    ISellerRepository SellerRepository { get; }
    ISellerStatisticRepository SellerStatisticRepository { get; }
}