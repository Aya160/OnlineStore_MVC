using OnlineStore.Core.Entities.General;

namespace OnlineStore.Core.Entities.AppAccounting
{
    public class Supplier : BaseEntity
    {
        public string SupplierName { get; set; }
        public string Email { get; set; }
        public string PhoneNO { get; set; }
        public string MaterialSupplied {  get; set; }
        public ICollection<DetailsInvoice> DetailsInvoices {  get; set; }
    }
}
