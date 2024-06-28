using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OnlineStore.Web.Controllers.UsersControllers
{
    public class AdministratorsController : Controller
    {
        // GET: AdministratorsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AdministratorsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdministratorsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdministratorsController/Create
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

        // GET: AdministratorsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdministratorsController/Edit/5
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

        // GET: AdministratorsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdministratorsController/Delete/5
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
