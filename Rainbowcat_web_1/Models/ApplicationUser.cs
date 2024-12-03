using Microsoft.AspNetCore.Identity;

namespace Rainbowcat_web_1.Models
{
    public class ApplicationUser :IdentityUser
    {
        public ICollection<Order>? orders { get; set; }
    }
}
