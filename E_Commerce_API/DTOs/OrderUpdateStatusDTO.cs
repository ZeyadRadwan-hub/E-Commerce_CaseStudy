using System.ComponentModel.DataAnnotations;

namespace E_Commerce_API.DTOs
{
    public class OrderUpdateStatusDTO
    {
        [Required]
        public string OrderStatus { get; set; }
    }
}
