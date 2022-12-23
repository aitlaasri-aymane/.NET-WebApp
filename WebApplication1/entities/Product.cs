using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.entities;

[Table("PRODUCTS")]
public class Product
{
    [Key] [Display(Name = "Product ID")] public int ProductId { get; set; }

    [Required]
    public string Designation { get; set; }

    [Required] public double Price { get; set; }
    
    public int CategoryID {get; set;}
    
    [ForeignKey("CategoryID")]
    public virtual Category Category{get; set;}
}