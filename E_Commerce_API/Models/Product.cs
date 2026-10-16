using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce_API.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required,MaxLength(100),MinLength(2)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string? Description { get; set; }
        [Required,Range( 0.01,1000000)]
        public decimal Price { get; set; }
        [Required,Range(0,1000000)]
        public int StockQuantity { get; set; }
        [Required,ForeignKey(nameof(CategoryId))]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

       public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
