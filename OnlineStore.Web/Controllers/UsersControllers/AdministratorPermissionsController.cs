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
        public ActionResult Create(IFormCollection collection)
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
        public ActionResult Edit(int id)
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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
