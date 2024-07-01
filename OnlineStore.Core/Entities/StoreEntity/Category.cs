using OnlineStore.Core.Entities.General;

namespace OnlineStore.Core.Entities.StoreEntity
{
    public class Category : BaseEntity
    {
        public  string Name {  get; set; }
        public ICollection<IncludeCategory> IncludeCategories { get; set; }
        public ICollection<Product> Products { get; set; }
        public int? SaleId { get; set; }
        public Sale Sale { get; set;}
    }
}
