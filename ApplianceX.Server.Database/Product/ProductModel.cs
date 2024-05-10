using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApplianceX.Server.Database.Brand;
using ApplianceX.Server.Database.Category;
using ApplianceX.Server.Database.Product.Statistic;
using ApplianceX.Server.Database.Seller;

namespace ApplianceX.Server.Database.Product;

public class ProductModel : AbstractModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    public int SellerId { get; set; }
    
    [ForeignKey("SellerId")]
    public SellerModel SellerModel { get; set; }
    
    public int CategoryId { get; set; }
    
    [ForeignKey("CategoryId")]
    public CategoryModel Category { get; set; }
    
    public int BrandId { get; set; }
    
    [ForeignKey("BrandId")]
    public BrandModel Brand { get; set; }
    
    public string Title { get; set; }
    
    public string Description { get; set; }

    public string Cover { get; set; }
    
    public int SellPrice { get; set; }
    
    public int? OldSellPrice { get; set; }
    
    public ProductStatisticModel Statistic { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime UpdatedAt { get; set; }
}