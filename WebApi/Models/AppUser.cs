
using Microsoft.AspNetCore.Identity;
using WebApi.Helpers;
namespace WebApi.Models
{
    public class AppUser:IdentityUser
    {
        public List<Portfolio> Portfolios { get; set; } = new List<Portfolio>();
        
    }
}
