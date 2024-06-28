using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OnlineStore.Web.Controllers.StoreControllers
{
    public class StoreManagerPermissionsController : Controller
    {
        // GET: StoreManagerPermissionsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: StoreManagerPermissionsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StoreManagerPermissionsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StoreManagerPermissionsController/Create
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

        // GET: StoreManagerPermissionsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StoreManagerPermissionsController/Edit/5
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

        // GET: StoreManagerPermissionsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StoreManagerPermissionsController/Delete/5
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
