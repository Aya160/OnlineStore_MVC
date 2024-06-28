using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OnlineStore.Web.Controllers.StoreControllers
{
    public class SaleCategoriesController : Controller
    {
        // GET: SaleCategoriesController
        public ActionResult Index()
        {
            return View();
        }

        // GET: SaleCategoriesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SaleCategoriesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SaleCategoriesController/Create
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

        // GET: SaleCategoriesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SaleCategoriesController/Edit/5
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

        // GET: SaleCategoriesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SaleCategoriesController/Delete/5
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
