using Microsoft.Extensions.Logging;

namespace ApplianceX.Server.Database.Rozetka.Seller.Statistic;

public class SellerStatisticRepository : AbstractRepository<SellerStatisticModel>, ISellerStatisticRepository
{
    public SellerStatisticRepository(PostgreSqlContext context, ILoggerFactory loggerFactory) : base(context, loggerFactory)
    {
    }

    
    public void Update(SellerStatisticModel model, int service, int delivery, int relevance)
    {
        model.UpdateModel(service, delivery, relevance);
        UpdateModelAsync(model);
    }
}