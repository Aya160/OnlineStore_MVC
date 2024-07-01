using OnlineStore.Core.Entities.General;
using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Core.Entities.StoreEntity
{
    public class Sale : BaseEntity
    {
        public DateOnly StartSale { get; set; }
        public DateOnly EndSale { get; set; }
        [Range(1, 100)]
        public int Discount { get; set; }
        public int? StoreId { get; set; }
        public Store Store { get; set; }
        public ICollection<Category> Categories { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
