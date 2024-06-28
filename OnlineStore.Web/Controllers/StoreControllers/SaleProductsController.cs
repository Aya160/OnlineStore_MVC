using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OnlineStore.Web.Controllers.StoreControllers
{
    public class SaleProductsController : Controller
    {
        // GET: SaleProductsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: SaleProductsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SaleProductsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SaleProductsController/Create
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

        // GET: SaleProductsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SaleProductsController/Edit/5
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

        // GET: SaleProductsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SaleProductsController/Delete/5
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
