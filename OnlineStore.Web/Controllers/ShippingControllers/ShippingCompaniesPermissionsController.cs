
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.Entities.Shipping;
using OnlineStore.Infrastructure.EntityConfigs.General;
using OnlineStore.Infrastructure.Repository.Shipping;

namespace OnlineStore.Web.Controllers.ShippingControllers
{
    public class ShippingCompaniesPermissionsController : Controller
    {
        private readonly ShippingCompaniesPermissionsRepo<ShippingCompaniesPermissions> shippingCompaniesPermissionsRepo;
        private readonly ShippingCompaniesRepo<ShippingCompanies> shippingCompaniesRepo;
        private readonly SelectListHelper selectListHelper;

        public ShippingCompaniesPermissionsController(ShippingCompaniesPermissionsRepo<ShippingCompaniesPermissions> shippingCompaniesPermissionsRepo,
            ShippingCompaniesRepo<ShippingCompanies> shippingCompaniesRepo, SelectListHelper selectListHelper)
        {
            this.shippingCompaniesPermissionsRepo = shippingCompaniesPermissionsRepo;
            this.shippingCompaniesRepo = shippingCompaniesRepo;
            this.selectListHelper = selectListHelper;
        }
        public ActionResult Index()
        {
            return View(shippingCompaniesPermissionsRepo.GetAllAsync().Result);
        }
        public ActionResult Details(int id)
        {
            return View(shippingCompaniesPermissionsRepo.GetById(id).Result);
        }
        public async Task<ActionResult> Create()
        {
            ViewBag.Companies = await selectListHelper.GetCompaniesListAsync();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ShippingCompaniesPermissions shippingCompaniesPermissions)
        {
            try
            {
                await shippingCompaniesPermissionsRepo.CreateAsync(shippingCompaniesPermissions);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ShippingCompaniesPermissionsController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            ViewBag.Companies = await selectListHelper.GetCompaniesListAsync();
            return View(shippingCompaniesPermissionsRepo.GetById(id).Result);
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
                oldPermissions.CompanyId = shippingCompaniesPermissions.CompanyId;
                oldPermissions.DeliverPrice = shippingCompaniesPermissions.DeliverPrice;
                await shippingCompaniesPermissionsRepo.UpdateAsync(id, oldPermissions);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(shippingCompaniesPermissions);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await shippingCompaniesPermissionsRepo.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(nameof(Index));
            }
        }
    }
}
