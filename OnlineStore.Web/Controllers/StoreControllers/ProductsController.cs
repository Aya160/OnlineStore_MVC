using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.Entities.StoreEntity;
using OnlineStore.Infrastructure.Repository.StoreEntity;

namespace OnlineStore.Web.Controllers.StoreControllers
{
    public class ProductsController : Controller
    {
        private readonly ProductRepo<Product> productRepo;

        public ProductsController(ProductRepo<Product> _productRepo)
        {
            productRepo = _productRepo;
        }
        public ActionResult Index()
        {
            var products = productRepo.GetAllAsync().Result;
            return View(products);
        }
        public ActionResult Details(int id)
        {
            return View(productRepo.GetById(id).Result);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Product product)
        {
            try
            {
               await productRepo.CreateAsync(product);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(product);
            }
        }
        public async Task<ActionResult> Edit(int id)
        {

            return View(productRepo.GetById(id).Result);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Product product)
        {
            try
            {
                var oldProduct = await productRepo.GetById(id);
                oldProduct.SaleProductId = product.SaleProductId;
                oldProduct.Name = product.Name;
                oldProduct.Price = product.Price;
                await productRepo.UpdateAsync(id, oldProduct);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(product);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            try
            {
                await productRepo.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(nameof(Index));
            }
        }
    }
}
