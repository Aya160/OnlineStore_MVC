using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.Entities.StoreEntity;
using OnlineStore.Infrastructure.Repository.StoreEntity;

namespace OnlineStore.Web.Controllers.StoreControllers
{
    public class ProductImagesController : Controller
    {
        private readonly ProductImageRepo<ProductImage> imageRepo;

        public ProductImagesController(ProductImageRepo<ProductImage> _imageRepo)
        {
            imageRepo = _imageRepo;
        }
        public ActionResult Index()
        {
            return View();
        }

        // GET: ProductImagesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductImagesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductImagesController/Create
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

        // GET: ProductImagesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductImagesController/Edit/5
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

        // GET: ProductImagesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductImagesController/Delete/5
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
