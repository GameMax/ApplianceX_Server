using System;
using System.Threading.Tasks;
using ApplianceX.Server.ExternalApi.Product;

namespace ApplianceX.Server.Database.Rozetka.Seller;

public interface ISellerRepository
{
    Task<SellerModel> CreateModel(ProductSeller apiModel, DateTime createdAt);

    Task<SellerModel?> FindOne(string seller);
}