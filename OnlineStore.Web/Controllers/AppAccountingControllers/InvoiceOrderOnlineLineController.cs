using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.Entities.AppAccounting;
using OnlineStore.Infrastructure.Repository.AppAccouting;

namespace OnlineStore.Web.Controllers.AppAccountingControllers
{
    public class InvoiceOrderOnlineLineController : Controller
    {
        private readonly InvoiceOrderOnlineLineRepo<InvoiceOrderOnlineLine> invoiceOrderOnlineLine;

        public InvoiceOrderOnlineLineController(InvoiceOrderOnlineLineRepo<InvoiceOrderOnlineLine> invoiceOrderOnlineLine) 
        {
            this.invoiceOrderOnlineLine = invoiceOrderOnlineLine;
        }
        // GET: InvoiceOrderOnlineLineController
        public ActionResult Index()
        {
            return View(invoiceOrderOnlineLine.GetAllAsync().Result);
        }

        // GET: InvoiceOrderOnlineLineController/Details/5
        public ActionResult Details(int id)
        {
            return View(invoiceOrderOnlineLine.GetById(id).Result);
        }

        // GET: InvoiceOrderOnlineLineController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InvoiceOrderOnlineLineController/Create
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

        // GET: InvoiceOrderOnlineLineController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InvoiceOrderOnlineLineController/Edit/5
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

        // GET: InvoiceOrderOnlineLineController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InvoiceOrderOnlineLineController/Delete/5
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
