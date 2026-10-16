using System.ComponentModel.DataAnnotations;

namespace E_Commerce_API.DTOs
{
    public class ProductPatchDTO
    {
        [MaxLength(100), MinLength(2)]
        public string? Name { get; set; }
        [MaxLength(500)]
        public string? Description { get; set; }
        [Range(0.01, 1000000)]
        public decimal? Price { get; set; }
        [Range(0, 1000000)]
        public int? StockQuantity { get; set; }
    }
}
