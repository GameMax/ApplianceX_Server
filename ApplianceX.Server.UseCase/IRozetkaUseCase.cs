using System.Threading;
using System.Threading.Tasks;
using ApplianceX.Server.Database.Rozetka.Brand;
using ApplianceX.Server.Database.Rozetka.Category;
using ApplianceX.Server.Database.Rozetka.Product;
using ApplianceX.Server.Database.Rozetka.Product.Statistic;
using ApplianceX.Server.Database.Rozetka.Seller;
using ApplianceX.Server.Database.Rozetka.Seller.Statistic;

namespace ApplianceX.Server.UseCase;

public interface IRozetkaUseCase
{
    Task<bool> ParseProducts(
        IProductRepository productRepository,
        IProductStatisticRepository productStatisticRepository,
        IBrandRepository brandRepository,
        ICategoryRepository categoryRepository,
        ISellerRepository sellerRepository,
        ISellerStatisticRepository sellerStatisticRepository,
        CancellationToken cancellationToken
    );
}