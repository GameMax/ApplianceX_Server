using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplianceX.Server.Database.Rozetka.Category;

public class CategoryModel : AbstractModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Title { get; set; }
    
    public string? Cover { get; set; }
    
    public string? CategoryUid { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime UpdatedAt { get; set; }


    public static CategoryModel CreateModel(string title, string? cover, string? categoryUid, DateTime createdAt)
    {
        return new CategoryModel
        {
            Title = title,
            Cover = cover,
            CategoryUid = categoryUid,
            CreatedAt = createdAt
        };
    }


    public void UpdateModel(string title, string? cover, string? categoryUid, DateTime updatedAt)
    {
        Title = title;
        Cover = cover;
        CategoryUid = categoryUid;
        UpdatedAt = updatedAt;
    }
}

