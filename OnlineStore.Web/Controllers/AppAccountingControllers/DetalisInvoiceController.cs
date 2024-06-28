using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OnlineStore.Web.Controllers.AppAccountingControllers
{
    public class DetalisInvoiceController : Controller
    {
        // GET: DetalisInvoiceController
        public ActionResult Index()
        {
            return View();
        }

        // GET: DetalisInvoiceController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DetalisInvoiceController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DetalisInvoiceController/Create
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

        // GET: DetalisInvoiceController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DetalisInvoiceController/Edit/5
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

        // GET: DetalisInvoiceController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DetalisInvoiceController/Delete/5
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
