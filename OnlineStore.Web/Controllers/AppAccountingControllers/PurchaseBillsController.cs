using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.Entities.AppAccounting;
using OnlineStore.Infrastructure.EntityConfigs.General;
using OnlineStore.Infrastructure.Repository.AppAccouting;

namespace OnlineStore.Web.Controllers.AppAccountingControllers
{
    public class PurchaseBillsController : Controller
    {
        private readonly PurchaseBillRepo<PurchaseBill> purchaseBillRepo;
        private readonly SelectListHelper selectListHelper;

        public PurchaseBillsController(PurchaseBillRepo<PurchaseBill> purchaseBillRepo, SelectListHelper selectListHelper)
        {
            this.purchaseBillRepo = purchaseBillRepo;
            this.selectListHelper = selectListHelper;
        }
        public ActionResult Index()
        {
            return View(purchaseBillRepo.GetAllAsync().Result);
        }
        public ActionResult Details(int id)
        {
            return View(purchaseBillRepo.GetById(id).Result);
        }
        public async Task<ActionResult> Create()
        {
            ViewBag.Admins = await selectListHelper.GetAdministratorListAsync();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PurchaseBill purchaseBill)
        {
            try
            {
                await purchaseBillRepo.CreateAsync(purchaseBill);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(purchaseBill);
            }
        }
        public async Task<ActionResult> Edit(int id)
        {
            ViewBag.Admins = await selectListHelper.GetAdministratorListAsync();
            return View(purchaseBillRepo.GetById(id).Result);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, PurchaseBill purchaseBill)
        {
            try
            {
                var oldPurchaseBill = await purchaseBillRepo.GetById(id);
                oldPurchaseBill.InvoiceName = purchaseBill.InvoiceName;
                oldPurchaseBill.CashPayment = purchaseBill.CashPayment;
                oldPurchaseBill.CreditPayment = purchaseBill.CreditPayment;
                oldPurchaseBill.DateInvoice = purchaseBill.DateInvoice;
                oldPurchaseBill.Tax = purchaseBill.Tax;
                oldPurchaseBill.TotalAmount = purchaseBill.TotalAmount;
                oldPurchaseBill.CreateDate = purchaseBill.CreateDate;
                oldPurchaseBill.DateInvoice = purchaseBill.DateInvoice;
                await purchaseBillRepo.UpdateAsync(id, oldPurchaseBill);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(purchaseBill);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await purchaseBillRepo.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(nameof(Index));
            }
        }
    }
}
