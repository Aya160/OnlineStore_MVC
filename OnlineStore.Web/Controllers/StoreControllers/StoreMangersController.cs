﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.Entities.StoreEntity;
using OnlineStore.Infrastructure.EntityConfigs.General;
using OnlineStore.Infrastructure.Repository.StoreEntity;

namespace OnlineStore.Web.Controllers.StoreControllers
{
    public class StoreMangersController : Controller
    {
        private readonly StoreMangerRepo<StoreManager> storeMangerRepo;
        private readonly SelectListHelper selectListHelper;

        public StoreMangersController(StoreMangerRepo<StoreManager> _storeMangerRepo, SelectListHelper selectListHelper)
        {
            storeMangerRepo = _storeMangerRepo;
            this.selectListHelper = selectListHelper;
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
        public async Task<ActionResult> Create()
        {
            ViewBag.Stores = await selectListHelper.GetStoresListAsync();
            ViewBag.Vendors = await selectListHelper.GetVendorsListAsync();
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
            ViewBag.Stores = await selectListHelper.GetStoresListAsync();
            ViewBag.Vendors = await selectListHelper.GetVendorsListAsync();
            var manger = storeMangerRepo.GetById(id).Result;
            return View(manger);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, StoreManager storeManager)
        {
            try
            {
                var oldManger = await storeMangerRepo.GetById(id);
                oldManger.StartAt = storeManager.StartAt;
                oldManger.StoreId = storeManager.StoreId;
                oldManger.VenderId = storeManager.VenderId;

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
