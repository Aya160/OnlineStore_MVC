using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OnlineStore.Web.Controllers.ShippingControllers
{
    public class ShippingCompaniesPermissionsController : Controller
    {
        // GET: ShippingCompaniesPermissionsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ShippingCompaniesPermissionsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
