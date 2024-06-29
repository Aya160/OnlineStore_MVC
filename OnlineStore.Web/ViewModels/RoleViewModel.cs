using Microsoft.AspNetCore.Identity;

namespace OnlineStore.Web.ViewModels
{
    public class RoleViewModel:IdentityRole
    {
        public string RoleName { get; set; }
    }
}
