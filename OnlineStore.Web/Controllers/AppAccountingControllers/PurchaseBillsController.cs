using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OnlineStore.Web.Controllers.AppAccountingControllers
{
    public class PurchaseBillsController : Controller
    {
        // GET: PurchaseBillsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PurchaseBillsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PurchaseBillsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PurchaseBillsController/Create
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

        // GET: PurchaseBillsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PurchaseBillsController/Edit/5
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

        // GET: PurchaseBillsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PurchaseBillsController/Delete/5
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
