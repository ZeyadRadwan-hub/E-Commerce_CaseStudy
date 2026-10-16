using System.ComponentModel.DataAnnotations;

namespace E_Commerce_API.DTOs
{
    public class AuthRegisterDTO
    {
        [Required, MaxLength(100), MinLength(3)]
        public string Name { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
