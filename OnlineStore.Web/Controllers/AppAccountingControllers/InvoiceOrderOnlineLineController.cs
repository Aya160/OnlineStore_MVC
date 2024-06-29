using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.Entities.AppAccounting;
using OnlineStore.Infrastructure.Repository.AppAccouting;

namespace OnlineStore.Web.Controllers.AppAccountingControllers
{
    public class InvoiceOrderOnlineLineController : Controller
    {
        private readonly InvoiceOrderOnlineLineRepo<InvoiceOrderOnlineLine> invoiceOrderOnlineLineRepo;

        public InvoiceOrderOnlineLineController(InvoiceOrderOnlineLineRepo<InvoiceOrderOnlineLine> invoiceOrderOnlineLineRepo)
        {
            this.invoiceOrderOnlineLineRepo = invoiceOrderOnlineLineRepo;
        }
        // GET: InvoiceOrderOnlineLineController
        public ActionResult Index()
        {
            return View(invoiceOrderOnlineLineRepo.GetAllAsync().Result);
        }

        // GET: InvoiceOrderOnlineLineController/Details/5
        public ActionResult Details(int id)
        {
            return View(invoiceOrderOnlineLineRepo.GetById(id).Result);
        }

        // GET: InvoiceOrderOnlineLineController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InvoiceOrderOnlineLineController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(InvoiceOrderOnlineLine invoiceOrderOnlineLine)
        {
            try
            {
                await invoiceOrderOnlineLineRepo.CreateAsync(invoiceOrderOnlineLine);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(invoiceOrderOnlineLine);
            }
        }

        // GET: InvoiceOrderOnlineLineController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return View(invoiceOrderOnlineLineRepo.GetById(id).Result);
        }

        // POST: InvoiceOrderOnlineLineController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, InvoiceOrderOnlineLine invoiceOrderOnlineLine)
        {
            try
            {
                var oldInvoiceOrderLine = await invoiceOrderOnlineLineRepo.GetById(id);
                oldInvoiceOrderLine.Quantity = invoiceOrderOnlineLine.Quantity;
                oldInvoiceOrderLine.ProductId = invoiceOrderOnlineLine.ProductId;
                oldInvoiceOrderLine.Product = invoiceOrderOnlineLine.Product;
                oldInvoiceOrderLine.OrderId = invoiceOrderOnlineLine.OrderId;
                oldInvoiceOrderLine.Order = invoiceOrderOnlineLine.Order;
                await invoiceOrderOnlineLineRepo.UpdateAsync(id, oldInvoiceOrderLine);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(invoiceOrderOnlineLine);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await invoiceOrderOnlineLineRepo.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(nameof(Index));
            }
        }
    }
}
