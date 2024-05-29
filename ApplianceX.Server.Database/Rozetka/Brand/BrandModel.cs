using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplianceX.Server.Database.Rozetka.Brand;

public class BrandModel : AbstractModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Title { get; set; }


    public static BrandModel CreateModel(string title)
    {
        return new BrandModel
        {
            Title = title
        };
    }


    public void UpdateModel(string title)
    {
        Title = title;
    }
}
