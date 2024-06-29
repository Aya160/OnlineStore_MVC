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
        public ActionResult Index()
        {
            return View(invoiceLineRepo.GetAllAsync().Result);
        }
        public ActionResult Details(int id)
        {
            return View(invoiceLineRepo.GetById(id).Result);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(InvoiceLine invoiceLine)
        {
            try
            {
                await invoiceLineRepo.CreateAsync(invoiceLine);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(invoiceLine);
            }
        }
        public async Task<ActionResult> Edit(int id)
        {
            return View(invoiceLineRepo.GetById(id).Result);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, InvoiceLine invoiceLine)
        {
            try
            {
                var oldinvoiceLine = await invoiceLineRepo.GetById(id);
                oldinvoiceLine.Price = invoiceLine.Price;
                oldinvoiceLine.Quantity = invoiceLine.Quantity;
                oldinvoiceLine.InvoiceId = invoiceLine.InvoiceId;
                oldinvoiceLine.PurchaseBill = invoiceLine.PurchaseBill;
                oldinvoiceLine.ProductId = invoiceLine.ProductId;
                oldinvoiceLine.Product = invoiceLine.Product;
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(invoiceLine);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await invoiceLineRepo.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(nameof(Index));
            }
        }
    }
}
