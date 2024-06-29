using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.Entities.StoreEntity;
using OnlineStore.Infrastructure.Repository.StoreEntity;

namespace OnlineStore.Web.Controllers.StoreControllers
{
    public class StoreMangersController : Controller
    {
        private readonly StoreMangerRepo<StoreManager> storeMangerRepo;

        public StoreMangersController(StoreMangerRepo<StoreManager> _storeMangerRepo)
        {
            storeMangerRepo = _storeMangerRepo;
        }
        public ActionResult Index()
        {
            var storeMangers = storeMangerRepo.GetAllAsync().Result;
            return View(storeMangers);
        }
        public ActionResult Details(int id)
        {
            return View(storeMangerRepo.GetById(id).Result);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(StoreManager storeManager)
        {
            try
            {
                await storeMangerRepo.CreateAsync(storeManager);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(storeManager);
            }
        }
        public async Task<ActionResult> Edit(int id)
        {
            var manger = await storeMangerRepo.GetById(id);
            return View(manger);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, StoreManager storeManager)
        {
            try
            {
                var oldManger = await storeMangerRepo.GetById(id);
                oldManger.Vendor = storeManager.Vendor;
                oldManger.StartAt = storeManager.StartAt;
                oldManger.Store = storeManager.Store;
                oldManger.StoreId = storeManager.StoreId;

                await storeMangerRepo.UpdateAsync(id, oldManger);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(storeManager);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await storeMangerRepo.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(nameof(Index));
            }
        }
    }
}
