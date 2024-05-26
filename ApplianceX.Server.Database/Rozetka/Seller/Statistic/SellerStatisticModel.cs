using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplianceX.Server.Database.Rozetka.Seller.Statistic;

public class SellerStatisticModel : AbstractModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int SellerId { get; set; }
    
    [ForeignKey("SellerId")]
    public SellerModel SellerModel { get; set; }

    public int Service { get; set; }

    public int Delivery { get; set; }

    public int Relevance { get; set; }


    public static SellerStatisticModel CreateModel(int sellerId, int service, int delivery, int relevance)
    {
        return new SellerStatisticModel()
        {
            SellerId = sellerId,
            Service = service,
            Delivery = delivery,
            Relevance = relevance
        };
    }


    public static SellerStatisticModel CreateEmpty()
    {
        return new SellerStatisticModel()
        {
            Service = 0,
            Delivery = 0,
            Relevance = 0
        };
    }


    public void UpdateModel(int service, int delivery, int relevance)
    {
        Service = service;
        Delivery = delivery;
        Relevance = relevance;
    }
}