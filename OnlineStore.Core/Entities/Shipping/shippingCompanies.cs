using OnlineStore.Core.Entities.General;

namespace OnlineStore.Core.Entities.Shipping
{
    public class ShippingCompanies : BaseEntity
    {
        public string CompanyName { get; set; }
        public string CompanyNO { get; set; }
        public DateTime ContractStartDate { get; set; }
        public DateTime ContractEndDate { get; set; }
        public ICollection<DeliverCart> DeliverCarts { get; set; }
        public ICollection<ShippingCompaniesPermissions> ShippingCompaniesPermissions { get; set; }
        public ICollection<StoreReliesOnShippingCompanies> StoreReliesOnShippingCompanies { get; set; }
    }
}
