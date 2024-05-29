using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApplianceX.Server.ExternalApi.Product;

namespace ApplianceX.Server.Database.Rozetka.Seller;

public class SellerModel : AbstractModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Seller { get; set; }
    
    public int? CountVotes { get; set; }
    
    public string? Rank { get; set; }

    public string? Logo { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime UpdatedAt { get; set; }


    public static SellerModel CreateModel(ProductSeller apiModel, DateTime createdAt)
    {
        return new SellerModel
        {
            Seller = apiModel.Title!,
            CountVotes = apiModel.CountVotes,
            Rank = apiModel.Rank,
            Logo = apiModel.Logo,
            CreatedAt = createdAt
        };
    }
}


