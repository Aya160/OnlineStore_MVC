using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.Entities.StoreEntity;
using OnlineStore.Infrastructure.Repository.StoreEntity;

namespace OnlineStore.Web.Controllers.StoreControllers
{
    public class OrdersController : Controller
    {
        private readonly OrderRepo<Order> orderRepo;

        public OrdersController(OrderRepo<Order> _orderRepo)
        {
            orderRepo = _orderRepo;
        }
        public ActionResult Index()
        {
            var orders = orderRepo.GetAllAsync().Result;
            return View(orders);
        }
        public ActionResult Details(int id)
        {
            return View(orderRepo.GetById(id).Result);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Order order)
        {
            try
            {
               await orderRepo.CreateAsync(order);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(order);
            }
        }
        public async Task<ActionResult> Edit(int id)
        {
           var order = await orderRepo.GetById(id);
            return View(order);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Order order)
        {
            try
            {
                var oldOrder = await orderRepo.GetById(id);
                oldOrder.RequstDate = order.RequstDate;
                oldOrder.Customer = order.Customer;
                oldOrder.CustomerId = order.CustomerId;

                await orderRepo.UpdateAsync(id, oldOrder);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(order);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
               await orderRepo.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(nameof(Index));
            }
        }
    }
}
