using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce_API.Models
{
    [Index(nameof(Name),IsUnique =true)]
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required,MaxLength(100),MinLength(2)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
