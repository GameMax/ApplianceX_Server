using ApplianceX.Server.Database.Rozetka.Seller;

namespace ApplianceX.Server.Database;

public interface IDatabaseFacade
{
    ISellerRepository SellerRepository { get; }
}