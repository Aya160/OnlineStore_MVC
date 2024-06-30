using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineStore.Core.Entities.StoreEntity;
using OnlineStore.Infrastructure.Repository.StoreEntity;

namespace OnlineStore.Web.Controllers.StoreControllers
{
    public class ProductsController : Controller
    {
        private readonly ProductRepo<Product> productRepo;
        private readonly SaleProductRepo<SaleProduct> saleProductRepo;
        private readonly CategoryRepo<Category> categoryRepo;

        public ProductsController(ProductRepo<Product> _productRepo, SaleProductRepo<SaleProduct> saleProductRepo,
            CategoryRepo<Category> categoryRepo)
        {
            productRepo = _productRepo;
            this.saleProductRepo = saleProductRepo;
            this.categoryRepo = categoryRepo;
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
        public async Task<ActionResult> Create()
        {
            var salesList = await saleProductRepo.GetAllAsync();
            SelectList saleList = new SelectList(salesList, "Id", "Discount");
            ViewBag.Sales = saleList;
            var categoriesList = await categoryRepo.GetAllAsync();
            SelectList categoriesNameList = new SelectList(categoriesList, "Id", "Name");
            ViewBag.Categories = categoriesNameList;
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
            var salesList = await saleProductRepo.GetAllAsync();
            SelectList saleList = new SelectList(salesList, "Id", "Discount");
            ViewBag.Sales = saleList;
            var categoriesList = await categoryRepo.GetAllAsync();
            SelectList categoriesNameList = new SelectList(categoriesList, "Id", "Name");
            ViewBag.Categories = categoriesNameList;
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
