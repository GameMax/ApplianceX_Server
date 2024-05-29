using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApplianceX.Server.Database.Rozetka.Brand;
using ApplianceX.Server.Database.Rozetka.Category;
using ApplianceX.Server.Database.Rozetka.Product.Statistic;
using ApplianceX.Server.Database.Rozetka.Seller;

namespace ApplianceX.Server.Database.Rozetka.Product;

public class ProductModel : AbstractModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int SellerId { get; set; }

    [ForeignKey("SellerId")]
    public SellerModel? SellerModel { get; set; }

    public int CategoryId { get; set; }

    [ForeignKey("CategoryId")]
    public CategoryModel? Category { get; set; }

    public int BrandId { get; set; }

    [ForeignKey("BrandId")]
    public BrandModel? Brand { get; set; }

    public int? ProductUid { get; set; }

    public string? Href { get; set; }

    public string? Title { get; set; }

    public string? Cover { get; set; }

    public int? Price { get; set; }

    public int? OldPrice { get; set; }

    public string? SellStatus { get; set; }

    public int? CommentsAmount { get; set; }

    public string? GroupTitle { get; set; }

    public string? GroupName { get; set; }

    public int? Discount { get; set; }

    public ProductType ProductType { get; set; }

    public ProductStatisticModel Statistic { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public static ProductModel CreateModel(ExternalApi.Product.Product apiModel, int sellerId, int categoryId, int brandId, ProductType productType, DateTime createdAt)
    {
        return new ProductModel
        {
            SellerId = sellerId,
            CategoryId = categoryId,
            BrandId = brandId,
            ProductUid = apiModel.Id,
            Href = apiModel.Href,
            Title = apiModel.Title,
            Cover = apiModel.ImageMain,
            Price = apiModel.Price,
            OldPrice = apiModel.OldPrice,
            SellStatus = apiModel.SellStatus,
            CommentsAmount = apiModel.CommentsAmount,
            GroupTitle = apiModel.GroupTitle,
            GroupName = apiModel.GroupName,
            Discount = apiModel.Discount,
            ProductType = productType,
            Statistic = ProductStatisticModel.CreateEmpty(),
            CreatedAt = createdAt
        };
    }


    public void UpdateModel(ExternalApi.Product.Product apiModel, DateTime updatedAt)
    {

        ProductUid = apiModel.Id;
        Href = apiModel.Href;
        Title = apiModel.Title;
        Cover = apiModel.ImageMain;
        Price = apiModel.Price;
        OldPrice = apiModel.OldPrice;
        SellStatus = apiModel.SellStatus;
        CommentsAmount = apiModel.CommentsAmount;
        GroupTitle = apiModel.GroupTitle;
        GroupName = apiModel.GroupName;
        Discount = apiModel.Discount;
        UpdatedAt = updatedAt;
    }


    public static bool IsSame(ProductModel model, ExternalApi.Product.Product apiModel)
    {
       return 
            model.ProductUid == apiModel.Id &&
            model.Href == apiModel.Href &&
            model.Title == apiModel.Title &&
            model.Cover == apiModel.ImageMain &&
            model.Price == apiModel.Price &&
            model.OldPrice == apiModel.OldPrice &&
            model.SellStatus == apiModel.SellStatus &&
            model.CommentsAmount == apiModel.CommentsAmount &&
            model.GroupTitle == apiModel.GroupTitle &&
            model.GroupName == apiModel.GroupName &&
            model.Discount == apiModel.Discount;
    }
}