using Microsoft.AspNetCore.Identity;

namespace FirstProductsAPI.Model
{
    public class AppUser : IdentityUser<int>
    {
        public string FullName { get; set; } = null!;
        public DateTime DateAdded { get; set; }
    }
}
