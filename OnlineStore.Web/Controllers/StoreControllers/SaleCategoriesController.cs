using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.Entities.StoreEntity;
using OnlineStore.Infrastructure.Repository.StoreEntity;

namespace OnlineStore.Web.Controllers.StoreControllers
{
    public class SaleCategoriesController : Controller
    {
        private readonly SaleCategoryRepo<SaleCategory> saleCategoryRepo;

        public SaleCategoriesController(SaleCategoryRepo<SaleCategory> _saleCategoryRepo)
        {
            saleCategoryRepo = _saleCategoryRepo;
        }
        public ActionResult Index()
        {
            var saleCategories = saleCategoryRepo.GetAllAsync().Result;
            return View(saleCategories);
        }
        public ActionResult Details(int id)
        {
            return View(saleCategoryRepo.GetById(id).Result);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(SaleCategory saleCategory)
        {
            await saleCategoryRepo.CreateAsync(saleCategory);
            return RedirectToAction(nameof(Index));
        }
        public async Task<ActionResult> Edit(int id)
        {
            var sale = await saleCategoryRepo.GetById(id);
            return View(sale);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, SaleCategory sale)
        {
            try
            {
                var oldSale = await saleCategoryRepo.GetById(id);
                oldSale.StartSale = sale.StartSale;
                oldSale.EndSale = sale.EndSale;
                oldSale.StoreId = sale.StoreId;
                await saleCategoryRepo.UpdateAsync(id, oldSale);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(sale);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await saleCategoryRepo.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(nameof(Index));
            }
        }
    }
}
