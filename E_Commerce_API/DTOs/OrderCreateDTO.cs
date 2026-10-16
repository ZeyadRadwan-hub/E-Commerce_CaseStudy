using System.ComponentModel.DataAnnotations;

namespace E_Commerce_API.DTOs
{
    public class OrderCreateDTO
    {
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public string OrderStatus { get; set; }
        [Required]
        public decimal ToatalAmount { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
