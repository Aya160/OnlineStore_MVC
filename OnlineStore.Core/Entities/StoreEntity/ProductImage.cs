using OnlineStore.Core.Entities.General;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineStore.Core.Entities.StoreEntity
{
    [NotMapped]
    public class ProductImage : BaseEntity
    {
        public string Image {  get; set; }
        public int? ProductId { get; set; }
        public Product Product { get; set; }
    }
}
