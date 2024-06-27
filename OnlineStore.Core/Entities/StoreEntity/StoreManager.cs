using OnlineStore.Core.Entities.General;
using OnlineStore.Core.Entities.Users;

namespace OnlineStore.Core.Entities.StoreEntity
{
    public class StoreManager : BaseEntity
    {
        public DateTime StartAt { get; set; }
        public int? VenderId { get; set; }
        public Vendor Vendor { get; set; }
        public int? StoreId { get; set; }
        public Store Store { get; set; }
        public ICollection<StoreManagerPermissions> Permissions { get; set; }
    }
}
