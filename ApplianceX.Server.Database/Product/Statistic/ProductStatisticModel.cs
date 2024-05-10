using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplianceX.Server.Database.Product.Statistic;

public class ProductStatisticModel : AbstractModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int ProductId { get; set; }
    
    [ForeignKey("ProductId")]
    public ProductModel ProductModel { get; set; }

    public int Service { get; set; }

    public int Delivery { get; set; }

    public int Relevance { get; set; }


    public static ProductStatisticModel CreateModel(int productId, int service, int delivery, int relevance)
    {
        return new ProductStatisticModel
        {
            ProductId = productId,
            Service = service,
            Delivery = delivery,
            Relevance = relevance
        };
    }


    public static ProductStatisticModel CreateEmpty()
    {
        return new ProductStatisticModel
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