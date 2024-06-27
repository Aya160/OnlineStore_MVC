using OnlineStore.Core.Entities.AppAccounting;
using OnlineStore.Core.Entities.General;

namespace OnlineStore.Core.Entities.StoreEntity
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<ProductImage> Images { get; set; }
        public ICollection<ContaintProduct> ContaintProducts { get; set; }
        public ICollection<InvoiceLine> InvoiceLines { get; set; }
        public ICollection<InvoiceOrderLine> InvoiceOrderLines { get; set; }
        public int? SaleProductId { get; set; }
        public SaleProduct SaleProduct { get; set; }
        public ICollection<InvoiceOrderOnlineLine> InvoiceOrderOnlineLines { get; set; } 
    }
}
