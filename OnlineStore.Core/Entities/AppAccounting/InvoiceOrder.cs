using OnlineStore.Core.Entities.General;
using OnlineStore.Core.Entities.StoreEntity;
using OnlineStore.Core.Entities.Users;

namespace OnlineStore.Core.Entities.AppAccounting
{
    public class InvoiceOrder : BaseEntity
    {
        public bool CashPayment { get; set; }
        public bool OnlinePayment { get; set; }
        public int Tax { get; set; }
        public decimal TotalAmount { get; set; }
        public DateOnly CreateDate { get; set; }
        public int? StoreId { get; set; }
        public Store Store { get; set; }
        public int? VendorId { get; set; }
        public Vendor Vendor { get; set; }
        public ICollection<InvoiceOrderLine> InvoiceOrderLines { get; set; }
    }
}
