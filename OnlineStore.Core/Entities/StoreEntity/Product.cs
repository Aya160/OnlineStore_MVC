using OnlineStore.Core.Entities.AppAccounting;
using OnlineStore.Core.Entities.General;

namespace OnlineStore.Core.Entities.StoreEntity
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<ContaintProduct> ContaintProducts { get; set; }
        public ICollection<InvoiceLine> InvoiceLines { get; set; }
        public ICollection<InvoiceOrderLine> InvoiceOrderLines { get; set; }
        public int? SaleId { get; set; }
        public Sale Sale { get; set; }
        public ICollection<InvoiceOrderOnlineLine> InvoiceOrderOnlineLines { get; set; } 
    }
}
