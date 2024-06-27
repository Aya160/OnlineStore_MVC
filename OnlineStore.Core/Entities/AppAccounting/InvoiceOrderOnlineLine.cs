using OnlineStore.Core.Entities.General;
using OnlineStore.Core.Entities.StoreEntity;

namespace OnlineStore.Core.Entities.AppAccounting
{
    public class InvoiceOrderOnlineLine : BaseEntity
    {
        public int Quantity { get; set; }
        public int? OrderId { get; set; }
        public Order Order { get; set; }
        public int? ProductId { get; set; }
        public Product Product { get; set; }
    }
}
