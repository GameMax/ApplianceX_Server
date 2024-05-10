using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplianceX.Server.Database.Seller;

public class SellerModel : AbstractModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string SellerName { get; set; }

    public string Email { get; set; }
    
    public string Phone { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime UpdatedAt { get; set; }
    

    // public static SellerModel CreateModel(string name)
    // {
    //     return new SellerModel
    //     {
    //         Name = name
    //     };
    // }
}


