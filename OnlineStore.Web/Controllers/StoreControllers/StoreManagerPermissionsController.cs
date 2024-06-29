using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.Entities.StoreEntity;
using OnlineStore.Infrastructure.Repository.StoreEntity;

namespace OnlineStore.Web.Controllers.StoreControllers
{
    public class StoreManagerPermissionsController : Controller
    {
        private readonly StoreMangerPermissionRepo<StoreManagerPermissions> sMPsRepo;

        public StoreManagerPermissionsController(StoreMangerPermissionRepo<StoreManagerPermissions> _sMPsRepo)
        {
            sMPsRepo = _sMPsRepo;
        }
        public ActionResult Index()
        {
            var permissions = sMPsRepo.GetAllAsync().Result;
            return View(permissions);
        }
        public ActionResult Details(int id)
        {
            return View(sMPsRepo.GetById(id).Result);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(StoreManagerPermissions storeManagerPermissions)
        {
            try
            {
               await sMPsRepo.CreateAsync(storeManagerPermissions);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(storeManagerPermissions);
            }
        }
        public async Task<ActionResult> Edit(int id)
        {
            var permission = await sMPsRepo.GetById(id);
            return View(permission);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, StoreManagerPermissions storeManagerPermissions)
        {
            try
            {
                var permission = await sMPsRepo.GetById(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Delete(int id)
        {
            return View();
        }
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
