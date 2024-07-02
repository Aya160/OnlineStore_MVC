using OnlineStore.Core.Entities.AppAccounting;
using OnlineStore.Core.Entities.General;
using OnlineStore.Core.Entities.StoreEntity;

namespace OnlineStore.Core.Entities.Users
{
    public class Administrator : BaseEntity
    {
        public string SSN { get; set; }
        public ICollection<AdministratorPermission> Permissions { get; set; }
        public ICollection<Store> Stores { get; set; }
        public ICollection<PurchaseBill> PurchaseBills { get; set; }
    }
}
