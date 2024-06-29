using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.Entities.Users;
using OnlineStore.Infrastructure.Repository.StoreEntity;
using OnlineStore.Infrastructure.Repository.Users;

namespace OnlineStore.Web.Controllers.UsersControllers
{
    public class AddressesController : Controller
    {
        private readonly AddressRepo<Address> addressRepo;

        public AddressesController(AddressRepo<Address> _addressRepo)
        {
            this.addressRepo = _addressRepo;
        }
        public ActionResult Index()
        {
            var adresses = addressRepo.GetAllAsync().Result;
            return View(adresses);
        }

        public ActionResult Details(int id)
        {
            return View(addressRepo.GetById(id).Result);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Address address)
        {
            try
            {
               await addressRepo.CreateAsync(address);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(address);
            }
        }
        public async Task<ActionResult> Edit(int id)
        {
            var address= addressRepo.GetById(id).Result;
            return View(address);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Address address)
        {
            try
            {
                var oldAddress = addressRepo.GetById(id).Result;
                oldAddress.StreetAdderss = address.StreetAdderss;
                oldAddress.City = address.City;
                oldAddress.State = address.State;
                oldAddress.DeliverCart = address.DeliverCart;
                await addressRepo.UpdateAsync(id, oldAddress);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(address);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await addressRepo.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(nameof(Index));
            }
        }
    }
}
