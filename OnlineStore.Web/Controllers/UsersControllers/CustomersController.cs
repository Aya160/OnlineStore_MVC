using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.Entities.Users;
using OnlineStore.Infrastructure.Repository.Users;

namespace OnlineStore.Web.Controllers.UsersControllers
{
    public class CustomersController : Controller
    {
        private readonly CustomerRepo<Customer> customerRepo;

        public CustomersController(CustomerRepo<Customer> _customerRepo)
        {
            customerRepo = _customerRepo;
        }
        public ActionResult Index()
        {
            var customers = customerRepo.GetAllAsync().Result;
            return View(customers);
        }
        public ActionResult Details(int id)
        {
            return View(customerRepo.GetById(id).Result);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Customer customer)
        {
            try
            {
               await customerRepo.CreateAsync(customer);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(customer);
            }
        }
        public ActionResult Edit(int id)
        {
            var customer = customerRepo.GetById(id).Result;
            return View(customer);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Customer customer)
        {
            try
            {
                var oldCustomer = customerRepo.GetById(id).Result;
                oldCustomer.Image = customer.Image;
                await customerRepo.UpdateAsync(id, oldCustomer);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(customer);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
               await customerRepo.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(nameof(Index));
            }
        }
    }
}
