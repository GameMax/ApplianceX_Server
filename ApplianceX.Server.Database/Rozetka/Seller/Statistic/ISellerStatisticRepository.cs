namespace ApplianceX.Server.Database.Rozetka.Seller.Statistic;

public interface ISellerStatisticRepository
{
    void Update(SellerStatisticModel model, int service, int delivery, int relevance);
}