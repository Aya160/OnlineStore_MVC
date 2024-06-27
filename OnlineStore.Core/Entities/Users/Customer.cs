using OnlineStore.Core.Entities.General;
using OnlineStore.Core.Entities.StoreEntity;

namespace OnlineStore.Core.Entities.Users
{
    public class Customer: BaseEntity
    {
        public string Image {  get; set; }
        public int? AccountId { get; set; }
        public Account Account { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
