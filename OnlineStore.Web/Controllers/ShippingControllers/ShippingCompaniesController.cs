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
        // GET: ShippingCompaniesController
        public ActionResult Index()
        {
            return View(shippingCompaniesRepo.GetAllAsync().Result);
        }

        // GET: ShippingCompaniesController/Details/5
        public ActionResult Details(int id)
        {
            return View(shippingCompaniesRepo.GetById(id).Result);
        }

        // GET: ShippingCompaniesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShippingCompaniesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: ShippingCompaniesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ShippingCompaniesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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
