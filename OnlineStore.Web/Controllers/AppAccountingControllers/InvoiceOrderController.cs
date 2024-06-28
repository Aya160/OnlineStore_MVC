using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OnlineStore.Web.Controllers.AppAccountingControllers
{
    public class InvoiceOrderController : Controller
    {
        // GET: InvoiceOrderController
        public ActionResult Index()
        {
            return View();
        }

        // GET: InvoiceOrderController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: InvoiceOrderController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InvoiceOrderController/Create
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

        // GET: InvoiceOrderController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InvoiceOrderController/Edit/5
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

        // GET: InvoiceOrderController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InvoiceOrderController/Delete/5
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
