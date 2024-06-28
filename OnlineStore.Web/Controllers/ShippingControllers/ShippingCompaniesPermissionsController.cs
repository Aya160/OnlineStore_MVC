using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.Entities.Shipping;
using OnlineStore.Infrastructure.Repository.Shipping;

namespace OnlineStore.Web.Controllers.ShippingControllers
{
    public class ShippingCompaniesPermissionsController : Controller
    {
        private readonly ShippingCompaniesPermissionsRepo<ShippingCompaniesPermissions> shippingCompaniesPermissionsRepo;

        public ShippingCompaniesPermissionsController(ShippingCompaniesPermissionsRepo<ShippingCompaniesPermissions> shippingCompaniesPermissionsRepo) 
        {
            this.shippingCompaniesPermissionsRepo = shippingCompaniesPermissionsRepo;
        }
        // GET: ShippingCompaniesPermissionsController
        public ActionResult Index()
        {
            return View(shippingCompaniesPermissionsRepo.GetAllAsync().Result);
        }

        // GET: ShippingCompaniesPermissionsController/Details/5
        public ActionResult Details(int id)
        {
            return View(shippingCompaniesPermissionsRepo.GetById(id).Result);
        }

        // GET: ShippingCompaniesPermissionsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShippingCompaniesPermissionsController/Create
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

        // GET: ShippingCompaniesPermissionsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ShippingCompaniesPermissionsController/Edit/5
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

        // GET: ShippingCompaniesPermissionsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ShippingCompaniesPermissionsController/Delete/5
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
