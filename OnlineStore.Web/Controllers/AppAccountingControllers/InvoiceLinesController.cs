using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.Entities.AppAccounting;
using OnlineStore.Infrastructure.Repository.AppAccouting;

namespace OnlineStore.Web.Controllers.AppAccountingControllers
{
    public class InvoiceLinesController : Controller
    {
        private readonly InvoiceLineRepo<InvoiceLine> invoiceLineRepo;

        public InvoiceLinesController(InvoiceLineRepo<InvoiceLine> invoiceLineRepo) 
        {
            this.invoiceLineRepo = invoiceLineRepo;
        }
        // GET: InvoiceLinesController
        public ActionResult Index()
        {
            return View(invoiceLineRepo.GetAllAsync().Result);
        }

        // GET: InvoiceLinesController/Details/5
        public ActionResult Details(int id)
        {
            return View(invoiceLineRepo.GetById(id).Result);
        }

        // GET: InvoiceLinesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InvoiceLinesController/Create
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

        // GET: InvoiceLinesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InvoiceLinesController/Edit/5
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

        // GET: InvoiceLinesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InvoiceLinesController/Delete/5
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
