using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.Entities.Users;
using OnlineStore.Infrastructure.Repository.Users;

namespace OnlineStore.Web.Controllers.UsersControllers
{
    public class AdministratorPermissionsController : Controller
    {
        private readonly AdministratorPermissionRepo<AdministratorPermission> adminPermissionsRepo;

        public AdministratorPermissionsController(AdministratorPermissionRepo<AdministratorPermission> _adminPermissionsRepo)
        {
            adminPermissionsRepo = _adminPermissionsRepo;
        }
        public ActionResult Index()
        {
            var adminPermissions = adminPermissionsRepo.GetAllAsync().Result;
            return View(adminPermissions);
        }
        public ActionResult Details(int id)
        {
            return View(adminPermissionsRepo.GetById(id).Result);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AdministratorPermission adminPermission)
        {
            try
            {
                await adminPermissionsRepo.CreateAsync(adminPermission);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(adminPermission);
            }
        }
        public ActionResult Edit(int id)
        {
            var permission = adminPermissionsRepo.GetById(id).Result;
            return View(permission);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, AdministratorPermission adminPermission)
        {
            try
            {
                var oldPermission = adminPermissionsRepo.GetById(id).Result;
                oldPermission.Administrator = adminPermission.Administrator;
                oldPermission.Permission = adminPermission.Permission;
                oldPermission.AdministratorId = adminPermission.Id;
                await adminPermissionsRepo.UpdateAsync(id, oldPermission);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(adminPermission);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await adminPermissionsRepo.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(nameof(Index));
            }
        }
    }
}
