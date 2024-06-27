using OnlineStore.Core.Entities.General;

namespace OnlineStore.Core.Entities.Users
{
    public class Account: BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public string PhoneNO1 { get; set; }
        public string PhoneNO2 {  get; set; }
        //public ICollection<PhoneNOForAccount> phoneNOs { get; set; }
        public int? AddressId { get; set; }
        public Address Address { get; set; }
        public Administrator Administrator { get; set; }
        public Customer Customer { get; set; }
        public Vendor Vendor { get; set; }
    }
}
