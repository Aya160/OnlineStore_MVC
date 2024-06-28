using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OnlineStore.Web.Controllers.StoreControllers
{
    public class StoreMangersController : Controller
    {
        // GET: StoreMangersController
        public ActionResult Index()
        {
            return View();
        }

        // GET: StoreMangersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StoreMangersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StoreMangersController/Create
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

        // GET: StoreMangersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StoreMangersController/Edit/5
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

        // GET: StoreMangersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StoreMangersController/Delete/5
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
