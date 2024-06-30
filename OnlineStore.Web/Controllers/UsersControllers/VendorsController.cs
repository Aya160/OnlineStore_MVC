using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.Entities.Users;
using OnlineStore.Infrastructure.EntityConfigs.General;
using OnlineStore.Infrastructure.Repository.Users;

namespace OnlineStore.Web.Controllers.UsersControllers
{
    public class VendorsController : Controller
    {
        private readonly VendorRepo<Vendor> vendorRepo;
        private readonly SelectListHelper selectListHelper;

        public VendorsController(VendorRepo<Vendor> _vendorRepo, SelectListHelper selectListHelper)
        {
            vendorRepo = _vendorRepo;
            this.selectListHelper = selectListHelper;
        }
        public ActionResult Index()
        {
            var vendors = vendorRepo.GetAllAsync().Result;
            return View(vendors);
        }
        public ActionResult Details(int id)
        {
            return View(vendorRepo.GetById(id).Result);
        }
        public async Task<ActionResult> Create()
        {
            ViewBag.Stores = await selectListHelper.GetStoresListAsync();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Vendor vendor)
        {
            try
            {
                await vendorRepo.CreateAsync(vendor);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(vendor);
            }
        }
        public async Task<ActionResult> Edit(int id)
        {
            ViewBag.Stores = await selectListHelper.GetStoresListAsync();
            var vendor = vendorRepo.GetById(id).Result;
            return View(vendor);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Vendor vendor)
        {
            try
            {
                var oldVendor = vendorRepo.GetById(id).Result;
                oldVendor.Store = vendor.Store;
                oldVendor.StoreId = vendor.StoreId;
                oldVendor.StoreManager = vendor.StoreManager;
                oldVendor.Salary = vendor.Salary;
                oldVendor.Name = vendor.Name;
                oldVendor.SSN = vendor.SSN;

                await vendorRepo.UpdateAsync(id, oldVendor);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(vendor);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await vendorRepo.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(nameof(Index));
            }
        }
    }
}
