using OnlineStore.Core.Entities.AppAccounting;
using OnlineStore.Core.Entities.StoreEntity;

namespace OnlineStore.Web.ViewModels
{
    public class ProductViewModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public IFormFile Image { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
        public int? SaleId { get; set; }
        public Sale Sale { get; set; }
    }
}
