using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApplication1.entities;

[Table("CATEGORIES")]
public class Category
{
    [Key] public int CategoryID { get; set; }
    [Required] public string NameCategory { get; set; }

    [JsonIgnore]
    public virtual ICollection<Product> Products { get; set; }
}