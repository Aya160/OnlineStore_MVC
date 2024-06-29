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
        public ActionResult Edit(int id)
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ShippingCompanies shippingCompanies)
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

        // GET: ShippingCompaniesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ShippingCompaniesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
