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
        public async Task<ActionResult> Create(InvoiceOrderLine invoiceOrderLine)
        {
            try
            {
                await invoiceOrderLineRepo.CreateAsync(invoiceOrderLine);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(invoiceOrderLine);
            }
        }

        // GET: InvoiceOrderLineController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return View(invoiceOrderLineRepo.GetById(id));
        }

        // POST: InvoiceOrderLineController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, InvoiceOrderLine invoiceOrderLine)
        {
            try
            {
                var oldInvoiceOrderLine = await invoiceOrderLineRepo.GetById(id);
                oldInvoiceOrderLine.Quantity = invoiceOrderLine.Quantity;
                oldInvoiceOrderLine.ProductId = invoiceOrderLine.ProductId;
                oldInvoiceOrderLine.Product = invoiceOrderLine.Product;
                oldInvoiceOrderLine.InvoiceOrderId = invoiceOrderLine.InvoiceOrderId;
                oldInvoiceOrderLine.InvoiceOrder = invoiceOrderLine.InvoiceOrder;
                await invoiceOrderLineRepo.UpdateAsync(id, oldInvoiceOrderLine);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(invoiceOrderLine);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await invoiceOrderLineRepo.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(nameof(Index));
            }
        }
    }
}
