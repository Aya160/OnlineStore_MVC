using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.Entities.Users;
using OnlineStore.Infrastructure.Repository.Users;

namespace OnlineStore.Web.Controllers.UsersControllers
{
    public class AdministratorsController : Controller
    {
        private readonly AdministratorRepo<Administrator> administratorRepo;

        public AdministratorsController(AdministratorRepo<Administrator> _administratorRepo)
        {
            administratorRepo = _administratorRepo;
        }
        public ActionResult Index()
        {
            var admins = administratorRepo.GetAllAsync().Result;
            return View(admins);
        }
        public ActionResult Details(int id)
        {
            return View(administratorRepo.GetById(id).Result);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Administrator administrator)
        {
            try
            {
                await administratorRepo.CreateAsync(administrator);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(administrator);
            }
        }
        public ActionResult Edit(int id)
        {
            var admin = administratorRepo.GetById(id).Result;
            return View(admin);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Administrator administrator)
        {
            try
            {
                var oldAdmin = administratorRepo.GetById(id).Result;
                oldAdmin.SSN = administrator.SSN;
                await administratorRepo.UpdateAsync(id, oldAdmin);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(administrator);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await administratorRepo.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(nameof(Index));
            }
        }
    }
}
