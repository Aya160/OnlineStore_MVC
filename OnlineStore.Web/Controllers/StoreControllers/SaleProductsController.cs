using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.Entities.StoreEntity;
using OnlineStore.Infrastructure.Repository.StoreEntity;

namespace OnlineStore.Web.Controllers.StoreControllers
{
    public class SaleProductsController : Controller
    {
        private readonly SaleProductRepo<SaleProduct> saleProductRepo;

        public SaleProductsController(SaleProductRepo<SaleProduct> _saleProductRepo)
        {
            saleProductRepo = _saleProductRepo;
        }
        public ActionResult Index()
        {
            var saleProducts = saleProductRepo.GetAllAsync().Result;
            return View(saleProducts);
        }
        public ActionResult Details(int id)
        {
            return View(saleProductRepo.GetById(id).Result);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(SaleProduct saleProduct)
        {
            try
            {
                await saleProductRepo.CreateAsync(saleProduct);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(saleProduct);
            }
        }
        public async Task<ActionResult> Edit(int id)
        {
            var sale = await saleProductRepo.GetById(id);
            return View(sale);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, SaleProduct saleProduct)
        {
            try
            {
                var oldSale = await saleProductRepo.GetById(id);
                oldSale.StartSale = saleProduct.StartSale;
                oldSale.EndSale = saleProduct.EndSale;
                oldSale.Store = saleProduct.Store;
                oldSale.StoreId = saleProduct.StoreId;
                await saleProductRepo.UpdateAsync(id, oldSale);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(saleProduct);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await saleProductRepo.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(nameof(Index));
            }
        }
    }
}
