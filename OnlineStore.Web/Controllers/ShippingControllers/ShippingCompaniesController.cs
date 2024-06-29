using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.Entities.Shipping;
using OnlineStore.Infrastructure.Repository.Shipping;

namespace OnlineStore.Web.Controllers.ShippingControllers
{
    public class ShippingCompaniesController : Controller
    {
        private readonly ShippingCompaniesRepo<ShippingCompanies> shippingCompaniesRepo;

        public ShippingCompaniesController(ShippingCompaniesRepo<ShippingCompanies> shippingCompaniesRepo)
        {
            this.shippingCompaniesRepo = shippingCompaniesRepo;
        }
        public ActionResult Index()
        {
            return View(shippingCompaniesRepo.GetAllAsync().Result);
        }
        public ActionResult Details(int id)
        {
            return View(shippingCompaniesRepo.GetById(id).Result);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ShippingCompanies shippingCompanies)
        {
            try
            {
                await shippingCompaniesRepo.CreateAsync(shippingCompanies);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(shippingCompanies);
            }
        }
        public async Task<ActionResult> Edit(int id)
        {
            return View(shippingCompaniesRepo.GetById(id).Result);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, ShippingCompanies shippingCompanies)
        {
            try
            {
                var oldCompanies = shippingCompaniesRepo.GetById(id).Result;
                oldCompanies.CompanyName = shippingCompanies.CompanyName;
                oldCompanies.CompanyName = shippingCompanies.CompanyNO;
                oldCompanies.ContractStartDate = shippingCompanies.ContractStartDate;
                oldCompanies.ContractEndDate = shippingCompanies.ContractEndDate;
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(shippingCompanies);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await shippingCompaniesRepo.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(nameof(Index));
            }
        }
    }
}
