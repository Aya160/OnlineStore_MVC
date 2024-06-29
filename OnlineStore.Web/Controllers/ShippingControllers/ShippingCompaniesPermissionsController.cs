using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.Entities.Shipping;
using OnlineStore.Infrastructure.Repository.Shipping;

namespace OnlineStore.Web.Controllers.ShippingControllers
{
    public class ShippingCompaniesPermissionsController : Controller
    {
        private readonly ShippingCompaniesPermissionsRepo<ShippingCompaniesPermissions> shippingCompaniesPermissionsRepo;
        private readonly ShippingCompaniesRepo<ShippingCompanies> shippingCompaniesRepo;

        public ShippingCompaniesPermissionsController(ShippingCompaniesPermissionsRepo<ShippingCompaniesPermissions> shippingCompaniesPermissionsRepo,
            ShippingCompaniesRepo<ShippingCompanies> shippingCompaniesRepo) 
        {
            this.shippingCompaniesPermissionsRepo = shippingCompaniesPermissionsRepo;
            this.shippingCompaniesRepo = shippingCompaniesRepo;
        }
        public ActionResult Index()
        {
            return View(shippingCompaniesPermissionsRepo.GetAllAsync().Result);
        }
        public ActionResult Details(int id)
        {
            return View(shippingCompaniesPermissionsRepo.GetById(id).Result);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ShippingCompaniesPermissions shippingCompaniesPermissions)
        {
            try
            {
                var companyList = shippingCompaniesRepo.GetAllAsync().Result;
                ViewBag.companyList = companyList;
                await shippingCompaniesPermissionsRepo.CreateAsync(shippingCompaniesPermissions);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ShippingCompaniesPermissionsController/Edit/5
        public ActionResult Edit(int id)
        {
            var companyList = shippingCompaniesRepo.GetAllAsync().Result;
            ViewBag.companyList = companyList;
            return View();
        }

        // POST: ShippingCompaniesPermissionsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, ShippingCompaniesPermissions shippingCompaniesPermissions)
        {
            try
            {
                var oldPermissions = shippingCompaniesPermissionsRepo.GetById(id).Result;
                oldPermissions.Permission = shippingCompaniesPermissions.Permission;
                oldPermissions.DeliverPrice = shippingCompaniesPermissions.DeliverPrice;
                await shippingCompaniesPermissionsRepo.UpdateAsync(id, oldPermissions);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(shippingCompaniesPermissions);
            }
        }

        // GET: ShippingCompaniesPermissionsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ShippingCompaniesPermissionsController/Delete/5
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
