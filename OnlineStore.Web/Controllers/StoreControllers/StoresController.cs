﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.Entities.StoreEntity;
using OnlineStore.Infrastructure.EntityConfigs.General;
using OnlineStore.Infrastructure.Repository.StoreEntity;

namespace OnlineStore.Web.Controllers.StoreControllers
{
    public class StoresController : Controller
    {
        private readonly StoreRepo<Store> storeRepo;
        private readonly SelectListHelper selectListHelper;

        public StoresController(StoreRepo<Store> _storeRepo, SelectListHelper selectListHelper)
        {
            storeRepo = _storeRepo;
            this.selectListHelper = selectListHelper;
        }
        public ActionResult Index()
        {
            var stores = storeRepo.GetAllAsync().Result;

            return View(stores);
        }
        public ActionResult Details(int id)
        {
            return View(storeRepo.GetById(id).Result);
        }
        public async Task<ActionResult> Create()
        {
            ViewBag.Admins = await selectListHelper.GetAdministratorListAsync();
            ViewBag.Address = await selectListHelper.GetAddressListAsync();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Store store)
        {
            try
            {
                await storeRepo.CreateAsync(store);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(store);
            }
        }
        public async Task<ActionResult> Edit(int id)
        {
            ViewBag.Admins = await selectListHelper.GetAdministratorListAsync();
            ViewBag.Address = await selectListHelper.GetAddressListAsync();
            var store = storeRepo.GetById(id).Result;
            return View(store);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Store store)
        {
            try
            {
                var oldStore = await storeRepo.GetById(id);
                oldStore.Name = store.Name;
                oldStore.Location = store.Location;
                oldStore.StoreManager = store.StoreManager;
                oldStore.Address = store.Address;
                oldStore.AddressId = store.AddressId;
                oldStore.Administrator = store.Administrator;
                oldStore.AdministratorId = store.AdministratorId;

                await storeRepo.UpdateAsync(id, oldStore);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(store);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await storeRepo.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(nameof(Index));
            }
        }
    }
}
