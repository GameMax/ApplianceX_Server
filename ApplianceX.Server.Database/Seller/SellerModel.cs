using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApplianceX.Server.Database.Seller.Review;
using ApplianceX.Server.Database.Seller.Statistic;

namespace ApplianceX.Server.Database.Seller;

public class SellerModel : AbstractModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    public string Name { get; set; }

    public SellerStatisticModel SellerStatistic { get; set; }
    //
    // public List<ReviewModel> Reviews { get; set; }


    public static SellerModel CreateModel(string name)
    {
        return new SellerModel
        {
            Name = name,
            SellerStatistic = SellerStatisticModel.CreateEmpty()
        };
    }
}


