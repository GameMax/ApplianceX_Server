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
}


