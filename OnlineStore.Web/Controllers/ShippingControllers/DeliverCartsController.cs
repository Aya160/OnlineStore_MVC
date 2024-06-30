using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.Entities.Shipping;
using OnlineStore.Infrastructure.Repository.Shipping;

namespace OnlineStore.Web.Controllers.ShippingControllers
{
    public class DeliverCartsController : Controller
    {
        private readonly DeliverCartRepo<DeliverCart> deliverCartRepo;

        public ShippingCompaniesRepo<ShippingCompanies> shippingCompaniesRepo { get; }

        public DeliverCartsController(DeliverCartRepo<DeliverCart> deliverCartRepo, ShippingCompaniesRepo<ShippingCompanies> shippingCompaniesRepo)
        {
            this.deliverCartRepo = deliverCartRepo;
            this.shippingCompaniesRepo = shippingCompaniesRepo;
        }
        // GET: DeliverCartsController
        public ActionResult Index()
        {
            var AllDeliverCarts = deliverCartRepo.GetAllAsync().Result;
            return View(AllDeliverCarts);
        }

        // GET: DeliverCartsController/Details/5
        public ActionResult Details(int id)
        {
            return View(deliverCartRepo.GetById(id).Result);
        }

        // GET: DeliverCartsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DeliverCartsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(DeliverCart deliverCart)
        {
            try
            {
                var companyList = shippingCompaniesRepo.GetAllAsync().Result;
                ViewBag.companyList = companyList;
                await deliverCartRepo.CreateAsync(deliverCart);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(deliverCart);
            }
        }

        // GET: DeliverCartsController/Edit/5
        public ActionResult Edit(int id)
        {
            var deliverCart= deliverCartRepo.GetById(id).Result;
            return View(deliverCart);
        }

        // POST: DeliverCartsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, DeliverCart deliverCart)
        {
            try
            {
                var oldDeliver = deliverCartRepo.GetById(id).Result;
                oldDeliver.DeliverLocation = deliverCart.DeliverLocation;
                oldDeliver.DateArrival = deliverCart.DateArrival;
                oldDeliver.CompanyId = deliverCart.CompanyId;
                oldDeliver.OrderId = deliverCart.OrderId;
                await deliverCartRepo.UpdateAsync(id, oldDeliver);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(deliverCart);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await deliverCartRepo.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(nameof(Index));
            }
        }
    }
}
