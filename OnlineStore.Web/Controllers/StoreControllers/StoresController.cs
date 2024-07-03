using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.Entities.StoreEntity;
using OnlineStore.Core.Entities.Users;
using OnlineStore.Infrastructure.EntityConfigs.General;
using OnlineStore.Infrastructure.Repository.StoreEntity;
using OnlineStore.Infrastructure.Repository.Users;
using OnlineStore.Web.ViewModels;

namespace OnlineStore.Web.Controllers.StoreControllers
{
	public class StoresController : Controller
    {
        private readonly StoreRepo<Store> storeRepo;
        private readonly SelectListHelper selectListHelper;
		private readonly AddressRepo<Address> addressRepo;

		public StoresController(StoreRepo<Store> _storeRepo, SelectListHelper selectListHelper, AddressRepo<Address> _addressRepo)
        {
            storeRepo = _storeRepo;
            this.selectListHelper = selectListHelper;
			addressRepo = _addressRepo;
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
            //ViewBag.Address = await selectListHelper.GetAddressListAsync();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(StoreViewModel viewModel)
        {
            try
            {
				var store = new Store
				{
					Name = viewModel.Name,
					Location = viewModel.Location,
					AddressId = viewModel.AddressId,
					AdministratorId = viewModel.AdministratorId,
					Administrator = viewModel.Administrator
				};
                    var address = new Address
					{
						StreetAdderss = viewModel.StreetAddress,
						State = viewModel.State,
						Zip = viewModel.Zip,
						City = viewModel.City
					};
                await addressRepo.CreateAsync(address);
                store.Address = address;
                
					await storeRepo.CreateAsync(store);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(viewModel);
            }
        }
        public async Task<ActionResult> Edit(int id)
        {
            ViewBag.Admins = await selectListHelper.GetAdministratorListAsync();
           //ViewBag.Address = await selectListHelper.GetAddressListAsync();
            var store = storeRepo.GetById(id).Result;

			var viewModel = new StoreViewModel
			{
				Name = store.Name,
				Location = store.Location,
				AddressId = store.AddressId,
				AdministratorId = store.AdministratorId,
				Administrator = store.Administrator
			};

			if (store.Address != null)
			{
				viewModel.StreetAddress = store.Address.StreetAdderss;
				viewModel.State = store.Address.State;
				viewModel.Zip = store.Address.Zip;
				viewModel.City = store.Address.City;
			}
			return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, StoreViewModel viewModel)
        {
            try
            {
                var oldStore = await storeRepo.GetById(id);
                oldStore.Name = viewModel.Name;
                oldStore.Location = viewModel.Location;
                //oldStore.StoreManager = store.StoreManager;
               // oldStore.Address = viewModel.Adderss;
                oldStore.AddressId = viewModel.AddressId;
                oldStore.Administrator = viewModel.Administrator;
                oldStore.AdministratorId = viewModel.AdministratorId;

                await storeRepo.UpdateAsync(id, oldStore);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(viewModel);
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
