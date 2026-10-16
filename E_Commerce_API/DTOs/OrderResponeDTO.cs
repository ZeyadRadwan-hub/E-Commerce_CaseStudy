using System.ComponentModel.DataAnnotations;

namespace E_Commerce_API.DTOs
{
    public class OrderResponeDTO
    {
        public int Id { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public string OrderStatus { get; set; }
        [Required]
        public decimal ToatalAmount { get; set; }
        public int UserId { get; set; }
    }
}
