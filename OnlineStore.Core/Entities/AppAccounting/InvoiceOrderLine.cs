using OnlineStore.Core.Entities.General;
using OnlineStore.Core.Entities.StoreEntity;

namespace OnlineStore.Core.Entities.AppAccounting
{
    public class InvoiceOrderLine : BaseEntity
    {
        public int Quantity { get; set; }
        public int? ProductId { get; set; }
        public Product Product { get; set; }
        public int? InvoiceOrderId { get; set; }
        public InvoiceOrder InvoiceOrder { get; set; }
    }
}
