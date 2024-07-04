using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineStore.Core.Entities.StoreEntity;
using OnlineStore.Infrastructure.Repository.StoreEntity;

namespace OnlineStore.Web.Controllers.StoreControllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryRepo<Category> categoryRepo;
        private readonly SaleRepo<Sale> saleRepo;

        public CategoryController(CategoryRepo<Category> _categoryRepo, SaleRepo<Sale> _saleRepo)
        {
            categoryRepo = _categoryRepo;
            saleRepo = _saleRepo;
        }
        public ActionResult Index()
        {
            var Catrgories = categoryRepo.GetAllAsync().Result;
            return View(Catrgories);
        }
        public ActionResult Details(int id)
        {
            var category = categoryRepo.GetById(id);
            return View(category.Result);
        }
        public ActionResult GetList()
        {
            var category = categoryRepo.GetProductListByIdAsync();
            return View(category);
        }
        public async Task<ActionResult> CreateAsync()
        {
            var salesList = await saleRepo.GetAllAsync();
            SelectList categoryList = new SelectList(salesList, "Id", "Discount");
            ViewBag.Sales = categoryList;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Category category)
        {

            await categoryRepo.CreateAsync(category);
            return RedirectToAction(nameof(Index));
        }
        public async Task<ActionResult> Edit(int id)
        {
            var salesList = await saleRepo.GetAllAsync();
            SelectList categoryList = new SelectList(salesList, "Id", "Discount");
            ViewBag.Sales = categoryList;
            return View(categoryRepo.GetById(id).Result);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Category category)
        {
            try
            {
                var oldCategory = categoryRepo.GetById(id).Result;
                oldCategory.Name = category.Name;
                oldCategory.SaleId = category.SaleId;
                oldCategory.Sale = category.Sale;
                await categoryRepo.UpdateAsync(id, oldCategory);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(category);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await categoryRepo.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
