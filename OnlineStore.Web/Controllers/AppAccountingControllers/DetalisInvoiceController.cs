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
        public async Task<ActionResult> Create(DetailsInvoice detailsInvoice)
        {
            try
            {
                await detailsInvoiceRepo.CreateAsync(detailsInvoice);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(detailsInvoice);
            }
        }

        // GET: DetalisInvoiceController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return View( detailsInvoiceRepo.GetById(id).Result);
        }

        // POST: DetalisInvoiceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, DetailsInvoice detailsInvoic)
        {
            try
            {
                var oldInvoice = await detailsInvoiceRepo.GetById(id);
                oldInvoice.PayCash = detailsInvoic.PayCash;
                oldInvoice.Postpaid = detailsInvoic.Postpaid;
                oldInvoice.DueDate = detailsInvoic.DueDate;
                oldInvoice.InvoiceId = detailsInvoic.InvoiceId;
                oldInvoice.PurchaseBill = detailsInvoic.PurchaseBill;
                oldInvoice.SupplierId = detailsInvoic.SupplierId;
                oldInvoice.Supplier = detailsInvoic.Supplier;

                await detailsInvoiceRepo.UpdateAsync(id, oldInvoice);   
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(detailsInvoic);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await detailsInvoiceRepo.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(nameof(Index));
            }
        }
    }
}
