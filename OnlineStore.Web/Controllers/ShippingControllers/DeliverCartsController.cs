using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OnlineStore.Web.Controllers.ShippingControllers
{
    public class DeliverCartsController : Controller
    {
        // GET: DeliverCartsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: DeliverCartsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DeliverCartsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DeliverCartsController/Create
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

        // GET: DeliverCartsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DeliverCartsController/Edit/5
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

        // GET: DeliverCartsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DeliverCartsController/Delete/5
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
