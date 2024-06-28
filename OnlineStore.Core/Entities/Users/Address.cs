using OnlineStore.Core.Entities.General;
using OnlineStore.Core.Entities.Shipping;
using OnlineStore.Core.Entities.StoreEntity;

namespace OnlineStore.Core.Entities.Users
{
    public class Address: BaseEntity
    {
        public string StreetAdderss { get; set; }
        public string State { get; set; }
        public string Zip {  get; set; }
        public string City { get; set; }
        public string ApplicationUserId  { get; set; }
        public Account Account { get; set; }
        public DeliverCart DeliverCart { get; set; }
        public ICollection<Store> Stores { get; set; }
        
    }
}
