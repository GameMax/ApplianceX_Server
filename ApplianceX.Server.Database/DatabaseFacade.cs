using ApplianceX.Server.Database.Rozetka.Brand;
using ApplianceX.Server.Database.Rozetka.Category;
using ApplianceX.Server.Database.Rozetka.Product;
using ApplianceX.Server.Database.Rozetka.Product.Statistic;
using ApplianceX.Server.Database.Rozetka.Seller;
using ApplianceX.Server.Database.Rozetka.Seller.Statistic;
using Microsoft.Extensions.Logging;

namespace ApplianceX.Server.Database;

public class DatabaseFacade : IDatabaseFacade
{

    #region RozetkaApi

        public IProductRepository ProductRepository { get; }
        public IProductStatisticRepository ProductStatisticRepository { get; }
        public ISellerRepository SellerRepository { get; }
        public ISellerStatisticRepository SellerStatisticRepository { get; }
        public IBrandRepository BrandRepository { get; }
        public ICategoryRepository CategoryRepository { get; }

    #endregion
    

    public DatabaseFacade(PostgreSqlContext context, ILoggerFactory loggerFactory)
    {
        ProductRepository = new ProductRepository(context, loggerFactory);
        ProductStatisticRepository = new ProductStatisticRepository(context, loggerFactory);
        SellerRepository = new SellerRepository(context, loggerFactory);
        SellerStatisticRepository = new SellerStatisticRepository(context, loggerFactory);
        BrandRepository = new BrandRepository(context, loggerFactory);
        CategoryRepository = new CategoryRepository(context, loggerFactory);
    }
}

