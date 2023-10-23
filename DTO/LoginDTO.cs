
using System.ComponentModel.DataAnnotations;

namespace FirstProductsAPI.DTO
{
    public class LoginDTO
    {
        [Required]
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;


    }
}