using Microsoft.AspNetCore.Identity;

namespace DataAccess.Data.Entities
{
    public class User : IdentityUser
    {
        public DateTime Birthdate { get; set; }
        public ICollection<Order>? Orders { get; set; }
    }
}
