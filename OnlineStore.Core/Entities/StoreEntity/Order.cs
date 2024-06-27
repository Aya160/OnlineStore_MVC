using OnlineStore.Core.Entities.AppAccounting;
using OnlineStore.Core.Entities.General;
using OnlineStore.Core.Entities.Shipping;
using OnlineStore.Core.Entities.Users;

namespace OnlineStore.Core.Entities.StoreEntity
{
    public class Order : BaseEntity
    {
        public DateTime RequstDate { get; set; }
        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }
        public ICollection<ContaintProduct> ContaintProducts { get; set; }
        public DeliverCart DeliverCart { get; set; }
        public ICollection<InvoiceOrderOnlineLine> InvoiceOrderOnlineLines { get; set; }
    }
}
