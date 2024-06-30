using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineStore.Core.Entities.AppAccounting;
using OnlineStore.Infrastructure.Repository.AppAccouting;
using OnlineStore.Infrastructure.Repository.StoreEntity;

namespace OnlineStore.Web.Controllers.AppAccountingControllers
{
    public class DetalisInvoiceController : Controller
    {
        private readonly DetailsInvoiceRepo<DetailsInvoice> detailsInvoiceRepo;
        private readonly SupplierRepo<Supplier> supplierRepo;

        public DetalisInvoiceController(DetailsInvoiceRepo<DetailsInvoice> detailsInvoiceRepo, SupplierRepo<Supplier> supplierRepo)
        {
            this.detailsInvoiceRepo = detailsInvoiceRepo;
            this.supplierRepo = supplierRepo;
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
        public async Task<ActionResult> Create()
        {
            var supplierList = await supplierRepo.GetAllAsync();
            SelectList supplierNameList = new SelectList(supplierList, "Id", "SupplierName");
            ViewBag.Suppliers = supplierNameList;
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
            var supplierList = await supplierRepo.GetAllAsync();
            SelectList supplierNameList = new SelectList(supplierList, "Id", "SupplierName");
            ViewBag.Suppliers = supplierNameList;
            return View(detailsInvoiceRepo.GetById(id).Result);
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
