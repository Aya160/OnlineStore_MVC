﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.Entities.AppAccounting;
using OnlineStore.Infrastructure.EntityConfigs.General;
using OnlineStore.Infrastructure.Repository.AppAccouting;

namespace OnlineStore.Web.Controllers.AppAccountingControllers
{
    public class InvoiceOrderController : Controller
    {
        private readonly InvoiceOrderRepo<InvoiceOrder> invoiceOrderRepo;
        private readonly SelectListHelper selectListHelper;

        public InvoiceOrderController(InvoiceOrderRepo<InvoiceOrder> invoiceOrderRepo, SelectListHelper selectListHelper)
        {
            this.invoiceOrderRepo = invoiceOrderRepo;
            this.selectListHelper = selectListHelper;
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
        public async Task<ActionResult> Create()
        {
            ViewBag.Stores = await selectListHelper.GetStoresListAsync();
            ViewBag.Vendors = await selectListHelper.GetVendorsListAsync();
            return View();
        }

        // POST: InvoiceOrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(InvoiceOrder invoiceOrder)
        {
            try
            {
                await invoiceOrderRepo.CreateAsync(invoiceOrder);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(invoiceOrder);
            }
        }

        // GET: InvoiceOrderController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            ViewBag.Stores = await selectListHelper.GetStoresListAsync();
            ViewBag.Vendors = await selectListHelper.GetVendorsListAsync();
            return View(invoiceOrderRepo.GetById(id).Result);
        }

        // POST: InvoiceOrderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, InvoiceOrder invoiceOrder)
        {
            try
            {
                var oldInvoiceOrder = await invoiceOrderRepo.GetById(id);
                oldInvoiceOrder.CashPayment = invoiceOrder.CashPayment;
                oldInvoiceOrder.OnlinePayment = invoiceOrder.OnlinePayment;
                oldInvoiceOrder.Tax = invoiceOrder.Tax;
                oldInvoiceOrder.TotalAmount = invoiceOrder.TotalAmount;
                oldInvoiceOrder.VendorId = invoiceOrder.VendorId;
                await invoiceOrderRepo.UpdateAsync(id, oldInvoiceOrder);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(invoiceOrder);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await invoiceOrderRepo.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(nameof(Index));
            }
        }
    }
}
