using Microsoft.AspNetCore.Identity;

namespace OnlineStore.Core.Entities.Users
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string PhoneNo2 { get; set; } = string.Empty;
        public Address Address { get; set; }
    }
}
