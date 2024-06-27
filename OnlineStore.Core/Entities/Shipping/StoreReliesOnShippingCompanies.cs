using OnlineStore.Core.Entities.StoreEntity;

namespace OnlineStore.Core.Entities.Shipping
{
    public class StoreReliesOnShippingCompanies
    {
        public int? StoreId { get; set; }
        public Store Store { get; set; }
        public int? CompanyId { get; set; }
        public ShippingCompanies ShippingCompanies { get; set; }
    }
}
