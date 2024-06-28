using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.Entities.AppAccounting;
using OnlineStore.Infrastructure.Repository.AppAccouting;

namespace OnlineStore.Web.Controllers.AppAccountingControllers
{
    public class InvoiceOrderController : Controller
    {
        private readonly InvoiceOrderRepo<InvoiceOrder> invoiceOrderRepo;

        public InvoiceOrderController(InvoiceOrderRepo<InvoiceOrder> invoiceOrderRepo) 
        {
            this.invoiceOrderRepo = invoiceOrderRepo;
        }
        // GET: InvoiceOrderController
        public ActionResult Index()
        {
            return View(invoiceOrderRepo.GetAllAsync().Result);
        }

        // GET: InvoiceOrderController/Details/5
        public ActionResult Details(int id)
        {
            return View(invoiceOrderRepo.GetById(id).Result);
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
