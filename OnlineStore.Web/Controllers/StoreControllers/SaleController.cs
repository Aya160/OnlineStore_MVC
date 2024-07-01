using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.Entities.StoreEntity;
using OnlineStore.Infrastructure.Repository.StoreEntity;

namespace OnlineStore.Web.Controllers.StoreControllers
{
    public class SaleController : Controller
    {
        private readonly SaleRepo<Sale> saleRepo;

        public SaleController(SaleRepo<Sale> _saleRepo)
        {
            saleRepo = _saleRepo;
        }
        public ActionResult Index()
        {
            var saleCategories = saleRepo.GetAllAsync().Result;
            return View(saleCategories);
        }
        public ActionResult Details(int id)
        {
            return View(saleRepo.GetById(id).Result);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Sale saleCategory)
        {
            await saleRepo.CreateAsync(saleCategory);
            return RedirectToAction(nameof(Index));
        }
        public async Task<ActionResult> Edit(int id)
        {
            var sale = await saleRepo.GetById(id);
            return View(sale);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Sale sale)
        {
            try
            {
                var oldSale = await saleRepo.GetById(id);
                oldSale.StartSale = sale.StartSale;
                oldSale.EndSale = sale.EndSale;
                oldSale.StoreId = sale.StoreId;
                await saleRepo.UpdateAsync(id, oldSale);
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
                await saleRepo.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(nameof(Index));
            }
        }
    }
}
