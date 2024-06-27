using OnlineStore.Core.Entities.AppAccounting;
using OnlineStore.Core.Entities.General;
using OnlineStore.Core.Entities.StoreEntity;

namespace OnlineStore.Core.Entities.Users
{
    public class Vendor: BaseEntity
    {
        public string Name { get; set; }
        public string SSN { get; set; }
        public decimal Salary { get; set; }
        public int? AccountId { get; set; }
        public Account Account { get; set; }
        // public int? ManagerId { get; set; }
        public StoreManager StoreManager { get; set; }
         public int? StoreId { get; set; }
        public Store Store { get; set; }
        public ICollection<InvoiceOrder> InvoiceOrders { get; set; }
    }
}
