using ApplianceX.Server.Database.Rozetka.Brand;
using ApplianceX.Server.Database.Rozetka.Category;
using ApplianceX.Server.Database.Rozetka.Product;
using ApplianceX.Server.Database.Rozetka.Product.Statistic;
using ApplianceX.Server.Database.Rozetka.Seller;
using ApplianceX.Server.Database.Rozetka.Seller.Statistic;

namespace ApplianceX.Server.Database;

public interface IDatabaseFacade
{
    #region RozetkaApi
    
    IProductRepository ProductRepository { get; }
    IProductStatisticRepository ProductStatisticRepository { get; }
    ISellerRepository SellerRepository { get; }
    ISellerStatisticRepository SellerStatisticRepository { get; }
    IBrandRepository BrandRepository { get; }
    ICategoryRepository CategoryRepository { get; }
    
    #endregion
}

