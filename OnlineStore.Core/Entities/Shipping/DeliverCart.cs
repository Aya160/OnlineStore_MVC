using OnlineStore.Core.Entities.General;
using OnlineStore.Core.Entities.StoreEntity;
using OnlineStore.Core.Entities.Users;

namespace OnlineStore.Core.Entities.Shipping
{
    public class DeliverCart : BaseEntity
    {
        public string DeliverLocation { get; set; }
        public DateOnly DateArrival { get; set; }
        public int? OrderId { get; set; }
        public Order Order { get; set; }
        public int? AddersId { get; set; }
        public Address Address { get; set; }
        public int? CompanyId { get; set; }
        public ShippingCompanies Company { get; set; }
    }
}
