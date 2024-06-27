using OnlineStore.Core.Entities.General;

namespace OnlineStore.Core.Entities.Shipping
{
    public class ShippingCompaniesPermissions : BaseEntity
    {
        public string Permission {  get; set; }
        public decimal DeliverPrice { get; set; }
        public int? CompanyId { get; set; }
        public ShippingCompanies ShippingCompanies { get; set; }
    }
}
