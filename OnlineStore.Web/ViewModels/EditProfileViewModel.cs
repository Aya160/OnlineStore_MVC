namespace OnlineStore.Web.ViewModels
{
    public class EditProfileViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public IFormFile ProfileImage { get; set; }
        public string Profile { get; set; }
    }
}