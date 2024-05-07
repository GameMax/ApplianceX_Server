namespace ApplianceX.Server.Database.Seller.Statistic;

public interface ISellerStatisticRepository
{
    void Update(SellerStatisticModel model, int service, int delivery, int relevance);
}