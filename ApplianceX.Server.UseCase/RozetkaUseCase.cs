using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ApplianceX.Server.Database.Rozetka.Brand;
using ApplianceX.Server.Database.Rozetka.Category;
using ApplianceX.Server.Database.Rozetka.Product;
using ApplianceX.Server.Database.Rozetka.Product.Statistic;
using ApplianceX.Server.Database.Rozetka.Seller;
using ApplianceX.Server.Database.Rozetka.Seller.Statistic;
using ApplianceX.Server.Parsers;
using Microsoft.Extensions.Logging;

namespace ApplianceX.Server.UseCase;

public class RozetkaUseCase : IRozetkaUseCase
{
    private readonly ILogger<RozetkaUseCase> _logger;
    private readonly IRozetkaParser _rozetkaParser;


    public RozetkaUseCase(ILogger<RozetkaUseCase> logger, IRozetkaParser rozetkaParser)
    {
        _logger = logger;
        _rozetkaParser = rozetkaParser;
    }



    public async Task<bool> ParseProducts(
        IProductRepository productRepository,
        IProductStatisticRepository productStatisticRepository,
        IBrandRepository brandRepository,
        ICategoryRepository categoryRepository,
        ISellerRepository sellerRepository,
        ISellerStatisticRepository sellerStatisticRepository,
        CancellationToken cancellationToken
    )
    {
        var preparedNewModels = new List<ProductModel>();
        var preparedUpdateModels = new List<ProductModel>();

        var dbCategoryUIds = await categoryRepository.ListAllCategoryUIds();

        const string page = "1";
        foreach (var categoryUid in dbCategoryUIds)
        {
            var collectionIds = await _rozetkaParser.GetByCategoryProductIds(categoryUid, page, cancellationToken);

            for (int i = 1; i <= collectionIds.Data.TotalPages; i++)
            {
                collectionIds = await _rozetkaParser.GetByCategoryProductIds(categoryUid, i.ToString(), cancellationToken);
                await Task.Delay(2_000, cancellationToken);

                var collectionDataInfo = await _rozetkaParser.GetFullProductInfoByIds(collectionIds.Data.Ids, cancellationToken);
                var apiProductTitles = collectionDataInfo.Data.Select(x => x.Title).ToImmutableArray();

                var existingModels = await productRepository.ListAllProducts(apiProductTitles);

                foreach (var apiProduct in collectionDataInfo.Data)
                {
                    var searchedModel = existingModels.FirstOrDefault(_ => _.Title == apiProduct.Title);

                    var searchedSeller = await sellerRepository.FindOne(apiProduct.Seller.Title);
                    var searchedCategory = await categoryRepository.FindOne(apiProduct.Category.Title);
                    var searchedBrand = await brandRepository.FindOne(apiProduct.Brand);

                    if (searchedSeller == null)
                    {
                        searchedSeller = await sellerRepository.CreateModel(apiProduct.Seller!, DateTime.UtcNow);
                    }

                    if (searchedCategory == null)
                    {
                        searchedCategory = await categoryRepository.CreateModel(
                            apiProduct.Category.Title,
                            apiProduct.Category.Href,
                            apiProduct.CategoryId.ToString(),
                            DateTime.UtcNow
                        );
                    }

                    if (searchedBrand == null)
                    {
                        searchedBrand = await brandRepository.CreateModel(apiProduct.Brand ?? "");
                    }

                    if (searchedModel == null)
                    {
                        var newModel = ProductModel.CreateModel(
                            apiProduct,
                            searchedSeller.Id,
                            searchedCategory.Id,
                            searchedBrand.Id,
                            ProductType.Appliance,
                            DateTime.UtcNow
                        );
                        preparedNewModels.Add(newModel);

                        continue;
                    }

                    if (ProductModel.IsSame(searchedModel, apiProduct) == false)
                    {
                        searchedModel.UpdateModel(apiProduct, DateTime.UtcNow);

                        _logger.LogInformation($"Model {searchedModel.Title} is not same");

                        preparedUpdateModels.Add(searchedModel);
                    }
                }
            }


        }

        if (preparedNewModels.Any())
        {
            await productRepository.CreateBulk(preparedNewModels.ToImmutableArray());
            _logger.LogInformation("\n\t Bulk Create products success! Count: {Count}", preparedNewModels.Count);
        }

        if (preparedUpdateModels.Any())
        {
            await productRepository.UpdateBulk(preparedNewModels.ToImmutableArray());
            _logger.LogInformation("\n\t Bulk Update products success! Count: {Count}", preparedUpdateModels.Count);
        }

        return true;
    }
}