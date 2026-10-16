using System.ComponentModel.DataAnnotations;

namespace E_Commerce_API.DTOs
{
    public class CategoryDTO
    {
        [Required, MaxLength(100), MinLength(2)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
    }
}
