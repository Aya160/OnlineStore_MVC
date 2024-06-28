using OnlineStore.Core.Entities.General;

namespace OnlineStore.Core.Entities.StoreEntity
{
    public class ProductImage : BaseEntity
    {
        public string Image {  get; set; }
        public int? ProductId { get; set; }
        public Product Product { get; set; }
    }
}
