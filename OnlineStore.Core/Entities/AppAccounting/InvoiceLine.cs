using OnlineStore.Core.Entities.General;
using OnlineStore.Core.Entities.StoreEntity;

namespace OnlineStore.Core.Entities.AppAccounting
{
    public class InvoiceLine : BaseEntity
    {
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int? InvoiceId { get; set; }
        public PurchaseBill PurchaseBill { get; set; }
        public int? ProductId { get; set; }
        public Product Product { get; set; }
    }
}
