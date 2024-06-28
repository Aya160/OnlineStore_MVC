using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.Entities.AppAccounting;
using OnlineStore.Infrastructure.Repository.AppAccouting;

namespace OnlineStore.Web.Controllers.AppAccountingControllers
{
    public class InvoiceOrderLineController : Controller
    {
        private readonly InvoiceOrderLineRepo<InvoiceOrderLine> invoiceOrderLineRepo;

        public InvoiceOrderLineController(InvoiceOrderLineRepo<InvoiceOrderLine> invoiceOrderLineRepo) 
        {
            this.invoiceOrderLineRepo = invoiceOrderLineRepo;
        }
        // GET: InvoiceOrderLineController
        public ActionResult Index()
        {
            return View(invoiceOrderLineRepo.GetAllAsync().Result);
        }

        // GET: InvoiceOrderLineController/Details/5
        public ActionResult Details(int id)
        {
            return View(invoiceOrderLineRepo.GetById(id).Result);
        }

        // GET: InvoiceOrderLineController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InvoiceOrderLineController/Create
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

        // GET: InvoiceOrderLineController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InvoiceOrderLineController/Edit/5
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

        // GET: InvoiceOrderLineController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InvoiceOrderLineController/Delete/5
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
