using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.Entities.AppAccounting;
using OnlineStore.Infrastructure.Repository.AppAccouting;

namespace OnlineStore.Web.Controllers.AppAccountingControllers
{
    public class DetalisInvoiceController : Controller
    {
        private readonly DetailsInvoiceRepo<DetailsInvoice> detailsInvoiceRepo;

        public DetalisInvoiceController(DetailsInvoiceRepo<DetailsInvoice> detailsInvoiceRepo) 
        {
            this.detailsInvoiceRepo = detailsInvoiceRepo;
        }
        // GET: DetalisInvoiceController
        public ActionResult Index()
        {
            return View(detailsInvoiceRepo.GetAllAsync().Result);
        }

        // GET: DetalisInvoiceController/Details/5
        public ActionResult Details(int id)
        {
            return View(detailsInvoiceRepo.GetById(id).Result);
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
