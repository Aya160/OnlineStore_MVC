using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineStore.Core.Entities.StoreEntity;
using OnlineStore.Infrastructure.Repository.StoreEntity;
using OnlineStore.Web.ViewModels;

namespace OnlineStore.Web.Controllers.StoreControllers
{
    public class ProductsController : Controller
    {
        private readonly ProductRepo<Product> productRepo;
        private readonly SaleProductRepo<SaleProduct> saleProductRepo;
        private readonly CategoryRepo<Category> categoryRepo;
        private readonly ProductImagesController productImages;

        public ProductsController(ProductRepo<Product> _productRepo, SaleProductRepo<SaleProduct> saleProductRepo,
            CategoryRepo<Category> categoryRepo,ProductImagesController _productImages)
        {
            productRepo = _productRepo;
            this.saleProductRepo = saleProductRepo;
            this.categoryRepo = categoryRepo;
            productImages = _productImages;
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
        public async Task<ActionResult> Create(ProductViewModel productViewModel)
        {
            try
            {
                var product = new Product()
                {
                    Name = productViewModel.Name,
                    Price = productViewModel.Price,
                    SaleProductId = productViewModel.SaleProductId,
                    CategoryId = productViewModel.CategoryId,
                    ImageUrl = productViewModel.Image.FileName,
                };
                productImages.UploadImage(productViewModel.Image);
                await productRepo.CreateAsync(product);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(productViewModel);
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

            var product = productRepo.GetById(id).Result;
            var productVM = new ProductViewModel
            {
                Name = product.Name,
                Price = product.Price,
                SaleProductId = product.SaleProductId,
                CategoryId = product.CategoryId,
                ImageUrl = product.ImageUrl,
            };
            return View(productVM);
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
