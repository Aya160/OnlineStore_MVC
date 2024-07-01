using OnlineStore.Core.Entities.AppAccounting;
using OnlineStore.Core.Entities.General;
using OnlineStore.Core.Entities.Shipping;
using OnlineStore.Core.Entities.Users;

namespace OnlineStore.Core.Entities.StoreEntity
{
    public class Store : BaseEntity
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public int? AddressId { get; set; }
        public Address Address { get; set; }
        public StoreManager StoreManager { get; set; }
        public int? AdministratorId { get; set; }
        public Administrator Administrator { get; set; }
        public ICollection<IncludeCategory> IncludeCategories { get; set; }
        public ICollection<StoreReliesOnShippingCompanies> ShippingCompanies { get; set; }
        public ICollection<InvoiceOrder> InvoiceOrders { get; set; }
        public ICollection<Sale> Sales { get; set; }
        public ICollection<Vendor> Vendors { get; set; }
    }
}
