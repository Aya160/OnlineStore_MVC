using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.Entities.AppAccounting;
using OnlineStore.Infrastructure.Repository.AppAccouting;

namespace OnlineStore.Web.Controllers.AppAccountingControllers
{
    public class SuppliersController : Controller
    {
        private readonly SupplierRepo<Supplier> supplierRepo;

        public SuppliersController(SupplierRepo<Supplier> supplierRepo)
        {
            this.supplierRepo = supplierRepo;
        }
        // GET: SuppliersController
        public ActionResult Index()
        {
            return View(supplierRepo.GetAllAsync().Result);
        }

        // GET: SuppliersController/Details/5
        public ActionResult Details(int id)
        {
            return View(supplierRepo.GetById(id).Result);
        }

        // GET: SuppliersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SuppliersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Supplier supplier)
        {
            try
            {
                await supplierRepo.CreateAsync(supplier);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(supplier);
            }
        }

        // GET: SuppliersController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return View(supplierRepo.GetById(id).Result);
        }

        // POST: SuppliersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Supplier supplier)
        {
            try
            {
                var oldSupplier = await supplierRepo.GetById(id);
                oldSupplier.SupplierName = supplier.SupplierName;
                oldSupplier.PhoneNO = supplier.PhoneNO;
                oldSupplier.Email = supplier.Email;
                oldSupplier.MaterialSupplied = supplier.MaterialSupplied;
                await supplierRepo.UpdateAsync(id, oldSupplier);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(supplier);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await supplierRepo.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(nameof(Index));
            }
        }
    }
}
