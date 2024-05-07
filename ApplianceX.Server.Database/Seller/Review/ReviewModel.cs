using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplianceX.Server.Database.Seller.Review;

public class ReviewModel : AbstractModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int SellerId { get; set; }
    
    [ForeignKey("SellerId")]
    public SellerModel Seller { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Surname { get; set; }

    public string Message { get; set; }
}